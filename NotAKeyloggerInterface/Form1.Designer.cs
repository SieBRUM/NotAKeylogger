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
            this.rtbKeylogger = new System.Windows.Forms.RichTextBox();
            this.btnToggleLogging = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbKeylogger
            // 
            this.rtbKeylogger.Location = new System.Drawing.Point(13, 42);
            this.rtbKeylogger.Name = "rtbKeylogger";
            this.rtbKeylogger.Size = new System.Drawing.Size(775, 396);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnToggleLogging);
            this.Controls.Add(this.rtbKeylogger);
            this.Name = "Form1";
            this.Text = "Not so silent keylogger";
            this.Load += new System.EventHandler(this.InitializeHooks);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbKeylogger;
        private System.Windows.Forms.Button btnToggleLogging;
    }
}

