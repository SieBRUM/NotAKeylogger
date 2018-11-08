namespace NotAKeyloggerInterface
{
    partial class MainForm
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
            this.lblButtonPressed = new System.Windows.Forms.Label();
            this.gbKeyboardData = new System.Windows.Forms.GroupBox();
            this.gbMouseData = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.cKeystrokes)).BeginInit();
            this.gbKeyboardData.SuspendLayout();
            this.gbMouseData.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbKeylogger
            // 
            this.rtbKeylogger.BackColor = System.Drawing.SystemColors.Window;
            this.rtbKeylogger.Location = new System.Drawing.Point(6, 19);
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
            this.cKeystrokes.Location = new System.Drawing.Point(7, 67);
            this.cKeystrokes.Name = "cKeystrokes";
            this.cKeystrokes.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Keystrokes";
            this.cKeystrokes.Series.Add(series1);
            this.cKeystrokes.Size = new System.Drawing.Size(536, 293);
            this.cKeystrokes.TabIndex = 2;
            this.cKeystrokes.Text = "Keyboard not hooked!";
            title1.Name = "Title1";
            title1.Text = "Keystrokes";
            this.cKeystrokes.Titles.Add(title1);
            // 
            // lblMouseLocation
            // 
            this.lblMouseLocation.AutoSize = true;
            this.lblMouseLocation.Location = new System.Drawing.Point(6, 48);
            this.lblMouseLocation.Name = "lblMouseLocation";
            this.lblMouseLocation.Size = new System.Drawing.Size(99, 13);
            this.lblMouseLocation.TabIndex = 3;
            this.lblMouseLocation.Text = "Mouse not hooked!";
            // 
            // lblButtonPressed
            // 
            this.lblButtonPressed.AutoSize = true;
            this.lblButtonPressed.Location = new System.Drawing.Point(6, 19);
            this.lblButtonPressed.Name = "lblButtonPressed";
            this.lblButtonPressed.Size = new System.Drawing.Size(99, 13);
            this.lblButtonPressed.TabIndex = 4;
            this.lblButtonPressed.Text = "Mouse not hooked!";
            // 
            // gbKeyboardData
            // 
            this.gbKeyboardData.Controls.Add(this.rtbKeylogger);
            this.gbKeyboardData.Controls.Add(this.cKeystrokes);
            this.gbKeyboardData.Location = new System.Drawing.Point(13, 43);
            this.gbKeyboardData.Name = "gbKeyboardData";
            this.gbKeyboardData.Size = new System.Drawing.Size(556, 381);
            this.gbKeyboardData.TabIndex = 5;
            this.gbKeyboardData.TabStop = false;
            this.gbKeyboardData.Text = "Keyboard data";
            // 
            // gbMouseData
            // 
            this.gbMouseData.Controls.Add(this.lblButtonPressed);
            this.gbMouseData.Controls.Add(this.lblMouseLocation);
            this.gbMouseData.Location = new System.Drawing.Point(575, 43);
            this.gbMouseData.Name = "gbMouseData";
            this.gbMouseData.Size = new System.Drawing.Size(317, 381);
            this.gbMouseData.TabIndex = 6;
            this.gbMouseData.TabStop = false;
            this.gbMouseData.Text = "Mouse data";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 616);
            this.Controls.Add(this.gbMouseData);
            this.Controls.Add(this.gbKeyboardData);
            this.Controls.Add(this.btnToggleLogging);
            this.Name = "MainForm";
            this.Text = "Not so silent keylogger";
            this.Load += new System.EventHandler(this.InitializeHooks);
            ((System.ComponentModel.ISupportInitialize)(this.cKeystrokes)).EndInit();
            this.gbKeyboardData.ResumeLayout(false);
            this.gbMouseData.ResumeLayout(false);
            this.gbMouseData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbKeylogger;
        private System.Windows.Forms.Button btnToggleLogging;
        private System.Windows.Forms.DataVisualization.Charting.Chart cKeystrokes;
        private System.Windows.Forms.Label lblMouseLocation;
        private System.Windows.Forms.Label lblButtonPressed;
        private System.Windows.Forms.GroupBox gbKeyboardData;
        private System.Windows.Forms.GroupBox gbMouseData;
    }
}

