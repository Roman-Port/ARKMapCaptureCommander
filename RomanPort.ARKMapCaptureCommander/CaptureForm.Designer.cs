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
            this.label1 = new System.Windows.Forms.Label();
            this.statusTimeRemaining = new System.Windows.Forms.Label();
            this.statusLastProcessingTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusArkPing = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.statusResentCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.statWaterTiles = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(423, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(12, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(426, 18);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Processing";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(360, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estimated Time Remaining";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusTimeRemaining
            // 
            this.statusTimeRemaining.Location = new System.Drawing.Point(177, 60);
            this.statusTimeRemaining.Name = "statusTimeRemaining";
            this.statusTimeRemaining.Size = new System.Drawing.Size(146, 17);
            this.statusTimeRemaining.TabIndex = 7;
            this.statusTimeRemaining.Text = "00:00:00";
            this.statusTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLastProcessingTime
            // 
            this.statusLastProcessingTime.Location = new System.Drawing.Point(177, 77);
            this.statusLastProcessingTime.Name = "statusLastProcessingTime";
            this.statusLastProcessingTime.Size = new System.Drawing.Size(146, 17);
            this.statusLastProcessingTime.TabIndex = 9;
            this.statusLastProcessingTime.Text = "0";
            this.statusLastProcessingTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Last Processing Time (ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusArkPing
            // 
            this.statusArkPing.Location = new System.Drawing.Point(177, 94);
            this.statusArkPing.Name = "statusArkPing";
            this.statusArkPing.Size = new System.Drawing.Size(146, 17);
            this.statusArkPing.TabIndex = 11;
            this.statusArkPing.Text = "0";
            this.statusArkPing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "ARK Response Time (ms)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusResentCount
            // 
            this.statusResentCount.Location = new System.Drawing.Point(177, 111);
            this.statusResentCount.Name = "statusResentCount";
            this.statusResentCount.Size = new System.Drawing.Size(146, 17);
            this.statusResentCount.TabIndex = 13;
            this.statusResentCount.Text = "0";
            this.statusResentCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Resent Commands";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statWaterTiles
            // 
            this.statWaterTiles.Location = new System.Drawing.Point(177, 128);
            this.statWaterTiles.Name = "statWaterTiles";
            this.statWaterTiles.Size = new System.Drawing.Size(146, 17);
            this.statWaterTiles.TabIndex = 15;
            this.statWaterTiles.Text = "0 (0%)";
            this.statWaterTiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Water Tiles";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 212);
            this.Controls.Add(this.statWaterTiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusResentCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.statusArkPing);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusLastProcessingTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusTimeRemaining);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusTimeRemaining;
        private System.Windows.Forms.Label statusLastProcessingTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label statusArkPing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label statusResentCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label statWaterTiles;
        private System.Windows.Forms.Label label3;
    }
}