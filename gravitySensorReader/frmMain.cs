using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gravitySensorReader
{
    public partial class frmMain : Form
    {
        const string logPath = @"d:\logs\accelerometer data.txt";

        private SerialPort serialPort;
        private GravityData gravityData = new GravityData();
        private CancellationTokenSource tcpSocketTokenSource;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Minimum = -2;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Size = 1F;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Interval = 1F;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Size = .25F;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Interval = .25F;
            chart1.ChartAreas[0].AxisY.Interval = 1.0F;
            chart1.ChartAreas[0].AxisY.Maximum = 2;            

            txtX.DataBindings.Add("Text", gravityData, "X");
            txtY.DataBindings.Add("Text", gravityData, "Y");
            txtZ.DataBindings.Add("Text", gravityData, "Z");
            txtXMax.DataBindings.Add("Text", gravityData, "XMax");
            txtYMax.DataBindings.Add("Text", gravityData, "YMax");
            txtZMax.DataBindings.Add("Text", gravityData, "ZMax");
            txtXMin.DataBindings.Add("Text", gravityData, "XMin");
            txtYMin.DataBindings.Add("Text", gravityData, "YMin");
            txtZMin.DataBindings.Add("Text", gravityData, "ZMin");

            // Select highest port speed by default
            cboPortSpeed.SelectedIndex = cboPortSpeed.Items.Count - 1;

            cboSource.SelectedIndex = 0;
        }

        private async void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                tcpSocketTokenSource = new CancellationTokenSource(); 

                btnRead.Enabled = false;
                btnStop.Enabled = true;

                if (cboSource.SelectedIndex == 0)
                {
                    var tcpPort = int.Parse(txtPort.Text);
                    await StartTcpListener(txtIp.Text, tcpPort);
                    btnRead.Enabled = true;
                    btnStop.Enabled = false;
                }
                else
                {
                    var portSpeed = int.Parse(cboPortSpeed.SelectedItem.ToString());
                    serialPort = new SerialPort(txtComPort.Text, portSpeed, Parity.None, 8, StopBits.One);
                    serialPort.ReadTimeout = 2000;
                    serialPort.Open();
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    serialPort.ErrorReceived += Port_ErrorReceived;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show($"Serial error {e.EventType.ToString()}");
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = null;

            try
            {
                if (serialPort.IsOpen)
                {
                    data = serialPort.ReadLine();
                }
            }
            catch (IOException) { }
            ProcessString(data);
        }

        private void ProcessString(string data)
        {
            if (string.IsNullOrEmpty(data)) return;

            var dataMessages = data.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var dataPoints = dataMessages[0].Split(',');
            if (dataPoints?.Length == 3 && decimal.TryParse(dataPoints[0], out decimal x) && decimal.TryParse(dataPoints[1], out decimal y) && decimal.TryParse(dataPoints[2], out decimal z))
            {
                // This causes UI updates so it has to happen in the main thread.
                this.Invoke(new Action(() =>
                {
                    gravityData.ProcessDataPoint(x, y, z);
                    UpdateChart(x, y, z);
                }));

                LogDataReceived(data);
            }
            else if (data?.StartsWith("ping") == true)
            {
                this.Invoke(new Action(() =>
                {
                    // Record passage of time with an empty data point.
                    UpdateChart(null, null, null);
                }));
            }

            if (chkDebug.Checked)
            {
                this.Invoke(new Action(() =>
                {
                    if (txtRawData.Text.Length > 500000) txtRawData.Text = "";

                    txtRawData.Text = data + Environment.NewLine + txtRawData.Text;
                }));
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort?.Close();
                tcpSocketTokenSource?.Cancel();
            }
            catch (IOException) { }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort?.Close();
                tcpSocketTokenSource.Cancel();
            }
            catch (IOException) { }
            btnRead.Enabled = true;
            btnStop.Enabled = false;
        }

        private void cboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxTcpIp.Visible = cboSource.SelectedIndex == 0;
            groupBoxSerial.Visible = cboSource.SelectedIndex == 1;
        }

        private void LogDataReceived(string data)
        {
            try
            {
                File.AppendAllText(logPath, $"{DateTime.Now.ToFileTimeUtc()} {data}\r\n");
            }
            catch { /* Ignore */ }
        }

        private void UpdateChart(decimal? xDataPoint, decimal? yDataPoint, decimal? zDataPoint)
        {
            var now = DateTime.Now.ToOADate();
            chart1.Series["X"].Points.AddXY(now, xDataPoint);
            chart1.Series["Y"].Points.AddXY(now, yDataPoint);
            chart1.Series["Z"].Points.AddXY(now, zDataPoint);

            chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-20).ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = now;

            // Remove undisplayed data points periodically.
            if (chart1.Series["X"].Points.Count > 100000)
            {
                chart1.Series["X"].Points.Clear();
                chart1.Series["Y"].Points.Clear();
                chart1.Series["Z"].Points.Clear();
            }
        }

        private async Task StartTcpListener(string ip, int port)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAddr = GetHostName(ip);

                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                string data = null;

                using (tcpSocketTokenSource.Token.Register(() => server.Stop())) 
                while (!tcpSocketTokenSource.IsCancellationRequested)
                {
                    Debug.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    var client = await server.AcceptTcpClientAsync();
                    Debug.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = await stream.ReadAsync(bytes, 0, bytes.Length, tcpSocketTokenSource.Token)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Debug.WriteLine($"Received: {data}");

                        ProcessString(data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("SocketException: {0}", ex);
            }
            catch (OperationCanceledException)  { /* Ignore */ }
            catch (ObjectDisposedException) { /* Ignore */ }
            finally
            {
                // Stop listening for new clients.
                server?.Stop();
            }
        }

        private static IPAddress GetHostName(string ipAddress)
        {
            if (ipAddress == "0.0.0.0") return IPAddress.Any;

            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null && entry.AddressList.Any(ip => ip.AddressFamily == AddressFamily.InterNetwork))
                {
                    return entry.AddressList.First(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                }
            }
            catch (SocketException) { /* Ignore */ }

            return null;
        }
    }
}
