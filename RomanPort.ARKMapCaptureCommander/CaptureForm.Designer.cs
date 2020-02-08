namespace RomanPort.ARKMapCaptureCommander
{
    partial class CaptureForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.renderStatusText = new System.Windows.Forms.Label();
            this.renderStatusBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(144, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(153, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(9, 29);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(426, 14);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(190, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // renderStatusText
            // 
            this.renderStatusText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderStatusText.Location = new System.Drawing.Point(9, 81);
            this.renderStatusText.Name = "renderStatusText";
            this.renderStatusText.Size = new System.Drawing.Size(426, 14);
            this.renderStatusText.TabIndex = 4;
            this.renderStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // renderStatusBar
            // 
            this.renderStatusBar.Location = new System.Drawing.Point(144, 98);
            this.renderStatusBar.Name = "renderStatusBar";
            this.renderStatusBar.Size = new System.Drawing.Size(153, 23);
            this.renderStatusBar.TabIndex = 3;
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 162);
            this.Controls.Add(this.renderStatusText);
            this.Controls.Add(this.renderStatusBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressBar1);
            this.Name = "CaptureForm";
            this.Text = "CaptureForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label renderStatusText;
        private System.Windows.Forms.ProgressBar renderStatusBar;
    }
}