namespace NotAKeyloggerInterface
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.rtbKeylogger = new System.Windows.Forms.RichTextBox();
            this.btnToggleLogging = new System.Windows.Forms.Button();
            this.cKeystrokes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMouseLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cKeystrokes)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbKeylogger
            // 
            this.rtbKeylogger.Location = new System.Drawing.Point(12, 42);
            this.rtbKeylogger.Name = "rtbKeylogger";
            this.rtbKeylogger.ReadOnly = true;
            this.rtbKeylogger.Size = new System.Drawing.Size(537, 42);
            this.rtbKeylogger.TabIndex = 0;
            this.rtbKeylogger.Text = "";
            // 
            // btnToggleLogging
            // 
            this.btnToggleLogging.Location = new System.Drawing.Point(13, 13);
            this.btnToggleLogging.Name = "btnToggleLogging";
            this.btnToggleLogging.Size = new System.Drawing.Size(75, 23);
            this.btnToggleLogging.TabIndex = 1;
            this.btnToggleLogging.Text = "Start logging";
            this.btnToggleLogging.UseVisualStyleBackColor = true;
            this.btnToggleLogging.Click += new System.EventHandler(this.ToggleLoggingHook);
            // 
            // cKeystrokes
            // 
            chartArea1.AxisX.Maximum = 6D;
            chartArea1.AxisX2.MaximumAutoSize = 6F;
            chartArea1.Name = "ChartArea1";
            this.cKeystrokes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cKeystrokes.Legends.Add(legend1);
            this.cKeystrokes.Location = new System.Drawing.Point(13, 90);
            this.cKeystrokes.Name = "cKeystrokes";
            this.cKeystrokes.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Keystrokes";
            this.cKeystrokes.Series.Add(series1);
            this.cKeystrokes.Size = new System.Drawing.Size(536, 293);
            this.cKeystrokes.TabIndex = 2;
            this.cKeystrokes.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Keystrokes";
            this.cKeystrokes.Titles.Add(title1);
            // 
            // lblMouseLocation
            // 
            this.lblMouseLocation.AutoSize = true;
            this.lblMouseLocation.Location = new System.Drawing.Point(324, 13);
            this.lblMouseLocation.Name = "lblMouseLocation";
            this.lblMouseLocation.Size = new System.Drawing.Size(35, 13);
            this.lblMouseLocation.TabIndex = 3;
            this.lblMouseLocation.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 616);
            this.Controls.Add(this.lblMouseLocation);
            this.Controls.Add(this.cKeystrokes);
            this.Controls.Add(this.btnToggleLogging);
            this.Controls.Add(this.rtbKeylogger);
            this.Name = "Form1";
            this.Text = "Not so silent keylogger";
            this.Load += new System.EventHandler(this.InitializeHooks);
            ((System.ComponentModel.ISupportInitialize)(this.cKeystrokes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbKeylogger;
        private System.Windows.Forms.Button btnToggleLogging;
        private System.Windows.Forms.DataVisualization.Charting.Chart cKeystrokes;
        private System.Windows.Forms.Label lblMouseLocation;
    }
}

