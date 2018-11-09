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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbKeylogger = new System.Windows.Forms.RichTextBox();
            this.cKeystrokes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMouseLocation = new System.Windows.Forms.Label();
            this.lblButtonPressed = new System.Windows.Forms.Label();
            this.gbKeyboardData = new System.Windows.Forms.GroupBox();
            this.gbMouseData = new System.Windows.Forms.GroupBox();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiToggleLogging = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cKeystrokes)).BeginInit();
            this.gbKeyboardData.SuspendLayout();
            this.gbMouseData.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbKeylogger
            // 
            this.rtbKeylogger.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbKeylogger.Location = new System.Drawing.Point(6, 19);
            this.rtbKeylogger.Name = "rtbKeylogger";
            this.rtbKeylogger.ReadOnly = true;
            this.rtbKeylogger.Size = new System.Drawing.Size(537, 42);
            this.rtbKeylogger.TabIndex = 0;
            this.rtbKeylogger.Text = "";
            // 
            // cKeystrokes
            // 
            this.cKeystrokes.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.Maximum = 6D;
            chartArea1.AxisX2.MaximumAutoSize = 6F;
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            this.cKeystrokes.ChartAreas.Add(chartArea1);
            this.cKeystrokes.ChartAreas.Add(chartArea2);
            this.cKeystrokes.Location = new System.Drawing.Point(-1, 88);
            this.cKeystrokes.Name = "cKeystrokes";
            this.cKeystrokes.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Name = "Keystrokes";
            series2.ChartArea = "ChartArea2";
            series2.IsValueShownAsLabel = true;
            series2.Name = "Words";
            this.cKeystrokes.Series.Add(series1);
            this.cKeystrokes.Series.Add(series2);
            this.cKeystrokes.Size = new System.Drawing.Size(556, 467);
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
            this.gbKeyboardData.Size = new System.Drawing.Size(560, 561);
            this.gbKeyboardData.TabIndex = 5;
            this.gbKeyboardData.TabStop = false;
            this.gbKeyboardData.Text = "Keyboard data";
            // 
            // gbMouseData
            // 
            this.gbMouseData.Controls.Add(this.lblButtonPressed);
            this.gbMouseData.Controls.Add(this.lblMouseLocation);
            this.gbMouseData.Location = new System.Drawing.Point(579, 43);
            this.gbMouseData.Name = "gbMouseData";
            this.gbMouseData.Size = new System.Drawing.Size(317, 381);
            this.gbMouseData.TabIndex = 6;
            this.gbMouseData.TabStop = false;
            this.gbMouseData.Text = "Mouse data";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1464, 24);
            this.msMain.TabIndex = 7;
            this.msMain.Text = "Menu";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiToggleLogging});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // tsmiToggleLogging
            // 
            this.tsmiToggleLogging.Name = "tsmiToggleLogging";
            this.tsmiToggleLogging.Size = new System.Drawing.Size(142, 22);
            this.tsmiToggleLogging.Text = "Start logging";
            this.tsmiToggleLogging.Click += new System.EventHandler(this.ToggleLoggingHook);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 616);
            this.Controls.Add(this.gbMouseData);
            this.Controls.Add(this.gbKeyboardData);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "MainForm";
            this.Text = "Not so silent keylogger";
            this.Load += new System.EventHandler(this.InitializeHooks);
            ((System.ComponentModel.ISupportInitialize)(this.cKeystrokes)).EndInit();
            this.gbKeyboardData.ResumeLayout(false);
            this.gbMouseData.ResumeLayout(false);
            this.gbMouseData.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbKeylogger;
        private System.Windows.Forms.DataVisualization.Charting.Chart cKeystrokes;
        private System.Windows.Forms.Label lblMouseLocation;
        private System.Windows.Forms.Label lblButtonPressed;
        private System.Windows.Forms.GroupBox gbKeyboardData;
        private System.Windows.Forms.GroupBox gbMouseData;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiToggleLogging;
    }
}

