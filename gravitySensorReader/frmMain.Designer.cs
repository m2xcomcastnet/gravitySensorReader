namespace gravitySensorReader
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnRead = new System.Windows.Forms.Button();
			this.txtComPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtRawData = new System.Windows.Forms.TextBox();
			this.btnStop = new System.Windows.Forms.Button();
			this.txtX = new System.Windows.Forms.TextBox();
			this.txtY = new System.Windows.Forms.TextBox();
			this.txtZ = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.chkDebug = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtZMax = new System.Windows.Forms.TextBox();
			this.txtYMax = new System.Windows.Forms.TextBox();
			this.txtXMax = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtZMin = new System.Windows.Forms.TextBox();
			this.txtYMin = new System.Windows.Forms.TextBox();
			this.txtXMin = new System.Windows.Forms.TextBox();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label6 = new System.Windows.Forms.Label();
			this.cboPortSpeed = new System.Windows.Forms.ComboBox();
			this.cboSource = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBoxSerial = new System.Windows.Forms.GroupBox();
			this.groupBoxTcpIp = new System.Windows.Forms.GroupBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtIp = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.groupBoxSerial.SuspendLayout();
			this.groupBoxTcpIp.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(327, 18);
			this.btnRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(163, 33);
			this.btnRead.TabIndex = 0;
			this.btnRead.Text = "Start reading";
			this.btnRead.UseVisualStyleBackColor = true;
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// txtComPort
			// 
			this.txtComPort.Location = new System.Drawing.Point(195, 21);
			this.txtComPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtComPort.Name = "txtComPort";
			this.txtComPort.Size = new System.Drawing.Size(157, 27);
			this.txtComPort.TabIndex = 1;
			this.txtComPort.Text = "com3";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(88, 30);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "Port";
			// 
			// txtRawData
			// 
			this.txtRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtRawData.Location = new System.Drawing.Point(18, 475);
			this.txtRawData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRawData.Multiline = true;
			this.txtRawData.Name = "txtRawData";
			this.txtRawData.ReadOnly = true;
			this.txtRawData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRawData.Size = new System.Drawing.Size(1274, 135);
			this.txtRawData.TabIndex = 3;
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(327, 59);
			this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(163, 33);
			this.btnStop.TabIndex = 4;
			this.btnStop.Text = "Stop reading";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// txtX
			// 
			this.txtX.Location = new System.Drawing.Point(33, 270);
			this.txtX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtX.Name = "txtX";
			this.txtX.ReadOnly = true;
			this.txtX.Size = new System.Drawing.Size(148, 27);
			this.txtX.TabIndex = 5;
			// 
			// txtY
			// 
			this.txtY.Location = new System.Drawing.Point(191, 270);
			this.txtY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtY.Name = "txtY";
			this.txtY.ReadOnly = true;
			this.txtY.Size = new System.Drawing.Size(148, 27);
			this.txtY.TabIndex = 6;
			// 
			// txtZ
			// 
			this.txtZ.Location = new System.Drawing.Point(350, 270);
			this.txtZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtZ.Name = "txtZ";
			this.txtZ.ReadOnly = true;
			this.txtZ.Size = new System.Drawing.Size(148, 27);
			this.txtZ.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(33, 242);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(18, 19);
			this.label2.TabIndex = 8;
			this.label2.Text = "X";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(191, 242);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 19);
			this.label3.TabIndex = 9;
			this.label3.Text = "Y";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(350, 242);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(18, 19);
			this.label4.TabIndex = 10;
			this.label4.Text = "Z";
			// 
			// chkDebug
			// 
			this.chkDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkDebug.AutoSize = true;
			this.chkDebug.Location = new System.Drawing.Point(18, 444);
			this.chkDebug.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkDebug.Name = "chkDebug";
			this.chkDebug.Size = new System.Drawing.Size(203, 23);
			this.chkDebug.TabIndex = 11;
			this.chkDebug.Text = "Show raw data received";
			this.chkDebug.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(33, 303);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 19);
			this.label7.TabIndex = 15;
			this.label7.Text = "Max";
			// 
			// txtZMax
			// 
			this.txtZMax.Location = new System.Drawing.Point(350, 331);
			this.txtZMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtZMax.Name = "txtZMax";
			this.txtZMax.ReadOnly = true;
			this.txtZMax.Size = new System.Drawing.Size(148, 27);
			this.txtZMax.TabIndex = 14;
			this.txtZMax.Text = "0";
			// 
			// txtYMax
			// 
			this.txtYMax.Location = new System.Drawing.Point(191, 331);
			this.txtYMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtYMax.Name = "txtYMax";
			this.txtYMax.ReadOnly = true;
			this.txtYMax.Size = new System.Drawing.Size(148, 27);
			this.txtYMax.TabIndex = 13;
			this.txtYMax.Text = "0";
			// 
			// txtXMax
			// 
			this.txtXMax.Location = new System.Drawing.Point(33, 331);
			this.txtXMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtXMax.Name = "txtXMax";
			this.txtXMax.ReadOnly = true;
			this.txtXMax.Size = new System.Drawing.Size(148, 27);
			this.txtXMax.TabIndex = 12;
			this.txtXMax.Text = "0";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(33, 365);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 19);
			this.label10.TabIndex = 21;
			this.label10.Text = "Min";
			// 
			// txtZMin
			// 
			this.txtZMin.Location = new System.Drawing.Point(350, 392);
			this.txtZMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtZMin.Name = "txtZMin";
			this.txtZMin.ReadOnly = true;
			this.txtZMin.Size = new System.Drawing.Size(148, 27);
			this.txtZMin.TabIndex = 20;
			this.txtZMin.Text = "1000";
			// 
			// txtYMin
			// 
			this.txtYMin.Location = new System.Drawing.Point(191, 392);
			this.txtYMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtYMin.Name = "txtYMin";
			this.txtYMin.ReadOnly = true;
			this.txtYMin.Size = new System.Drawing.Size(148, 27);
			this.txtYMin.TabIndex = 19;
			this.txtYMin.Text = "1000";
			// 
			// txtXMin
			// 
			this.txtXMin.Location = new System.Drawing.Point(33, 392);
			this.txtXMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtXMin.Name = "txtXMin";
			this.txtXMin.ReadOnly = true;
			this.txtXMin.Size = new System.Drawing.Size(148, 27);
			this.txtXMin.TabIndex = 18;
			this.txtXMin.Text = "1000";
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
			chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX.LabelStyle.Enabled = false;
			chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(531, 18);
			this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "X";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
			series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "Y";
			series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
			series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.Legend = "Legend1";
			series3.Name = "Z";
			series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
			series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			this.chart1.Series.Add(series1);
			this.chart1.Series.Add(series2);
			this.chart1.Series.Add(series3);
			this.chart1.Size = new System.Drawing.Size(764, 449);
			this.chart1.TabIndex = 26;
			this.chart1.Text = "chart1";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(88, 71);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 19);
			this.label6.TabIndex = 28;
			this.label6.Text = "Speed";
			// 
			// cboPortSpeed
			// 
			this.cboPortSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPortSpeed.FormattingEnabled = true;
			this.cboPortSpeed.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600 ",
            "115200 "});
			this.cboPortSpeed.Location = new System.Drawing.Point(195, 68);
			this.cboPortSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cboPortSpeed.Name = "cboPortSpeed";
			this.cboPortSpeed.Size = new System.Drawing.Size(152, 27);
			this.cboPortSpeed.TabIndex = 29;
			// 
			// cboSource
			// 
			this.cboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSource.FormattingEnabled = true;
			this.cboSource.Items.AddRange(new object[] {
            "TCP/IP",
            "UDP",
            "Com Port"});
			this.cboSource.Location = new System.Drawing.Point(18, 64);
			this.cboSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cboSource.Name = "cboSource";
			this.cboSource.Size = new System.Drawing.Size(232, 27);
			this.cboSource.TabIndex = 30;
			this.cboSource.SelectedIndexChanged += new System.EventHandler(this.cboSource_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 19);
			this.label5.TabIndex = 31;
			this.label5.Text = "Source";
			// 
			// groupBoxSerial
			// 
			this.groupBoxSerial.Controls.Add(this.cboPortSpeed);
			this.groupBoxSerial.Controls.Add(this.label6);
			this.groupBoxSerial.Controls.Add(this.label1);
			this.groupBoxSerial.Controls.Add(this.txtComPort);
			this.groupBoxSerial.Location = new System.Drawing.Point(18, 106);
			this.groupBoxSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxSerial.Name = "groupBoxSerial";
			this.groupBoxSerial.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxSerial.Size = new System.Drawing.Size(474, 116);
			this.groupBoxSerial.TabIndex = 32;
			this.groupBoxSerial.TabStop = false;
			this.groupBoxSerial.Text = "Source Settings";
			// 
			// groupBoxTcpIp
			// 
			this.groupBoxTcpIp.Controls.Add(this.txtPort);
			this.groupBoxTcpIp.Controls.Add(this.label8);
			this.groupBoxTcpIp.Controls.Add(this.label9);
			this.groupBoxTcpIp.Controls.Add(this.txtIp);
			this.groupBoxTcpIp.Location = new System.Drawing.Point(18, 106);
			this.groupBoxTcpIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxTcpIp.Name = "groupBoxTcpIp";
			this.groupBoxTcpIp.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBoxTcpIp.Size = new System.Drawing.Size(474, 116);
			this.groupBoxTcpIp.TabIndex = 33;
			this.groupBoxTcpIp.TabStop = false;
			this.groupBoxTcpIp.Text = "Source Settings";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(195, 72);
			this.txtPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(157, 27);
			this.txtPort.TabIndex = 29;
			this.txtPort.Text = "2000";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(88, 71);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 19);
			this.label8.TabIndex = 28;
			this.label8.Text = "Port";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(88, 30);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 19);
			this.label9.TabIndex = 2;
			this.label9.Text = "IP";
			// 
			// txtIp
			// 
			this.txtIp.Location = new System.Drawing.Point(195, 21);
			this.txtIp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtIp.Name = "txtIp";
			this.txtIp.Size = new System.Drawing.Size(157, 27);
			this.txtIp.TabIndex = 1;
			this.txtIp.Text = "0.0.0.0";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1313, 628);
			this.Controls.Add(this.groupBoxSerial);
			this.Controls.Add(this.groupBoxTcpIp);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cboSource);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtZMin);
			this.Controls.Add(this.txtYMin);
			this.Controls.Add(this.txtXMin);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtZMax);
			this.Controls.Add(this.txtYMax);
			this.Controls.Add(this.txtXMax);
			this.Controls.Add(this.chkDebug);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtZ);
			this.Controls.Add(this.txtY);
			this.Controls.Add(this.txtX);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.txtRawData);
			this.Controls.Add(this.btnRead);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmMain";
			this.Text = "Sensor data displayer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.groupBoxSerial.ResumeLayout(false);
			this.groupBoxSerial.PerformLayout();
			this.groupBoxTcpIp.ResumeLayout(false);
			this.groupBoxTcpIp.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtComPort;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtRawData;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtZMax;
        private System.Windows.Forms.TextBox txtYMax;
        private System.Windows.Forms.TextBox txtXMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtZMin;
        private System.Windows.Forms.TextBox txtYMin;
        private System.Windows.Forms.TextBox txtXMin;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPortSpeed;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.GroupBox groupBoxTcpIp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIp;
    }
}

