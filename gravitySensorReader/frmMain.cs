using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace gravitySensorReader
{
    public partial class frmMain : Form
    {
        const string logPath = @"d:\logs\accelerometer data.txt";

        private SerialPort serialPort;
        private GravityData GravityData = new GravityData();

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

            txtX.DataBindings.Add("Text", GravityData, "X");
            txtY.DataBindings.Add("Text", GravityData, "Y");
            txtZ.DataBindings.Add("Text", GravityData, "Z");
            txtXMax.DataBindings.Add("Text", GravityData, "XMax");
            txtYMax.DataBindings.Add("Text", GravityData, "YMax");
            txtZMax.DataBindings.Add("Text", GravityData, "ZMax");
            txtXMin.DataBindings.Add("Text", GravityData, "XMin");
            txtYMin.DataBindings.Add("Text", GravityData, "YMin");
            txtZMin.DataBindings.Add("Text", GravityData, "ZMin");

            // Select highest port speed by default
            cboPortSpeed.SelectedIndex = cboPortSpeed.Items.Count - 1;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                var portSpeed = int.Parse(cboPortSpeed.SelectedItem.ToString());
                serialPort = new SerialPort(txtComPort.Text, portSpeed, Parity.None, 8, StopBits.One);
                serialPort.ReadTimeout = 2000;
                serialPort.Open();
                serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                serialPort.ErrorReceived += Port_ErrorReceived;
                btnRead.Enabled = false;
                btnStop.Enabled = true;
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
            var dataPoints = data?.Split(',');
            if (dataPoints?.Length == 3 && decimal.TryParse(dataPoints[0], out decimal x) && decimal.TryParse(dataPoints[1], out decimal y) && decimal.TryParse(dataPoints[2], out decimal z))
            {
                // This causes UI updates so it has to happen in the main thread.
                this.Invoke(new Action(() =>
                {
                    GravityData.ProcessDataPoint(x, y, z);
                    UpdateChart(x, y, z);
                }));

                LogDataReceived(data);
            }
            else if(data?.StartsWith("ping") == true)
            {
                this.Invoke(new Action(() =>
                {
                    // Record passage of time with an empty data point.
                    UpdateChart(null,null,null); 
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


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort?.Close();
            }
            catch (IOException) { }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Close();
            }
            catch (IOException) { }
            btnRead.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
