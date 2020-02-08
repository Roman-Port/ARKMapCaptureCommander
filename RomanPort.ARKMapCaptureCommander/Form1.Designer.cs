namespace RomanPort.ARKMapCaptureCommander
{
    partial class ConfigForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.captureBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optionZoomLevels = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.optionCameraHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.optionMapSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.optionOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.optionOffsetY = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.processIdPicker = new System.Windows.Forms.NumericUpDown();
            this.processIdDiscoverButton = new System.Windows.Forms.Button();
            this.processStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.actorList = new System.Windows.Forms.ListBox();
            this.actorVisSetting = new System.Windows.Forms.CheckBox();
            this.actorName = new System.Windows.Forms.Label();
            this.actorType = new System.Windows.Forms.Label();
            this.actorSaveName = new System.Windows.Forms.Button();
            this.actorSaveType = new System.Windows.Forms.Button();
            this.actorLightInten = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.actorApplyToAllType = new System.Windows.Forms.Button();
            this.actorListSearch = new System.Windows.Forms.TextBox();
            this.actorEditPostProcessProps = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionZoomLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionCameraHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionMapSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionOffsetY)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processIdPicker)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actorLightInten)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 30);
            this.panel1.TabIndex = 0;
            // 
            // captureBtn
            // 
            this.captureBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.captureBtn.Enabled = false;
            this.captureBtn.Location = new System.Drawing.Point(521, 358);
            this.captureBtn.Name = "captureBtn";
            this.captureBtn.Size = new System.Drawing.Size(93, 23);
            this.captureBtn.TabIndex = 1;
            this.captureBtn.Text = "Capture";
            this.captureBtn.UseVisualStyleBackColor = true;
            this.captureBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.optionOffsetY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.optionOffsetX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.optionMapSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.optionCameraHeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.optionZoomLevels);
            this.groupBox1.Location = new System.Drawing.Point(414, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 151);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Settings";
            // 
            // optionZoomLevels
            // 
            this.optionZoomLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionZoomLevels.Location = new System.Drawing.Point(92, 19);
            this.optionZoomLevels.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.optionZoomLevels.Name = "optionZoomLevels";
            this.optionZoomLevels.Size = new System.Drawing.Size(102, 20);
            this.optionZoomLevels.TabIndex = 0;
            this.optionZoomLevels.ValueChanged += new System.EventHandler(this.optionZoomLevels_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zoom Levels";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Camera Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optionCameraHeight
            // 
            this.optionCameraHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionCameraHeight.Location = new System.Drawing.Point(92, 45);
            this.optionCameraHeight.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.optionCameraHeight.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.optionCameraHeight.Name = "optionCameraHeight";
            this.optionCameraHeight.Size = new System.Drawing.Size(102, 20);
            this.optionCameraHeight.TabIndex = 2;
            this.optionCameraHeight.ValueChanged += new System.EventHandler(this.optionCameraHeight_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Map Size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optionMapSize
            // 
            this.optionMapSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionMapSize.Location = new System.Drawing.Point(92, 71);
            this.optionMapSize.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.optionMapSize.Name = "optionMapSize";
            this.optionMapSize.Size = new System.Drawing.Size(102, 20);
            this.optionMapSize.TabIndex = 4;
            this.optionMapSize.ValueChanged += new System.EventHandler(this.optionMapSize_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Offset X";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optionOffsetX
            // 
            this.optionOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionOffsetX.Location = new System.Drawing.Point(92, 97);
            this.optionOffsetX.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.optionOffsetX.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.optionOffsetX.Name = "optionOffsetX";
            this.optionOffsetX.Size = new System.Drawing.Size(102, 20);
            this.optionOffsetX.TabIndex = 6;
            this.optionOffsetX.ValueChanged += new System.EventHandler(this.optionOffsetX_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Offset Y";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optionOffsetY
            // 
            this.optionOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionOffsetY.Location = new System.Drawing.Point(92, 123);
            this.optionOffsetY.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.optionOffsetY.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.optionOffsetY.Name = "optionOffsetY";
            this.optionOffsetY.Size = new System.Drawing.Size(102, 20);
            this.optionOffsetY.TabIndex = 8;
            this.optionOffsetY.ValueChanged += new System.EventHandler(this.optionOffsetY_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.processStatus);
            this.groupBox2.Controls.Add(this.processIdDiscoverButton);
            this.groupBox2.Controls.Add(this.processIdPicker);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(216, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 151);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process Settings";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(7, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 46);
            this.label6.TabIndex = 0;
            this.label6.Text = "To capture game images, you\'ll need to choose your ARK process. Type the process " +
    "ID in below.";
            // 
            // processIdPicker
            // 
            this.processIdPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processIdPicker.Location = new System.Drawing.Point(39, 69);
            this.processIdPicker.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.processIdPicker.Name = "processIdPicker";
            this.processIdPicker.Size = new System.Drawing.Size(120, 20);
            this.processIdPicker.TabIndex = 1;
            // 
            // processIdDiscoverButton
            // 
            this.processIdDiscoverButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processIdDiscoverButton.Location = new System.Drawing.Point(50, 99);
            this.processIdDiscoverButton.Name = "processIdDiscoverButton";
            this.processIdDiscoverButton.Size = new System.Drawing.Size(94, 23);
            this.processIdDiscoverButton.TabIndex = 2;
            this.processIdDiscoverButton.Text = "Discover";
            this.processIdDiscoverButton.UseVisualStyleBackColor = true;
            this.processIdDiscoverButton.Click += new System.EventHandler(this.processIdDiscoverButton_Click);
            // 
            // processStatus
            // 
            this.processStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processStatus.Location = new System.Drawing.Point(7, 129);
            this.processStatus.Name = "processStatus";
            this.processStatus.Size = new System.Drawing.Size(179, 13);
            this.processStatus.TabIndex = 3;
            this.processStatus.Text = "No Process Selected";
            this.processStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(10, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 151);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Settings";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.actorEditPostProcessProps);
            this.groupBox4.Controls.Add(this.actorListSearch);
            this.groupBox4.Controls.Add(this.actorApplyToAllType);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.actorLightInten);
            this.groupBox4.Controls.Add(this.actorSaveType);
            this.groupBox4.Controls.Add(this.actorSaveName);
            this.groupBox4.Controls.Add(this.actorType);
            this.groupBox4.Controls.Add(this.actorName);
            this.groupBox4.Controls.Add(this.actorVisSetting);
            this.groupBox4.Controls.Add(this.actorList);
            this.groupBox4.Location = new System.Drawing.Point(12, 193);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(602, 159);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Actor Settings";
            // 
            // actorList
            // 
            this.actorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actorList.FormattingEnabled = true;
            this.actorList.Location = new System.Drawing.Point(6, 45);
            this.actorList.Name = "actorList";
            this.actorList.Size = new System.Drawing.Size(324, 95);
            this.actorList.TabIndex = 0;
            this.actorList.SelectedValueChanged += new System.EventHandler(this.actorList_SelectedValueChanged);
            // 
            // actorVisSetting
            // 
            this.actorVisSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actorVisSetting.AutoSize = true;
            this.actorVisSetting.Enabled = false;
            this.actorVisSetting.Location = new System.Drawing.Point(336, 120);
            this.actorVisSetting.Name = "actorVisSetting";
            this.actorVisSetting.Size = new System.Drawing.Size(84, 17);
            this.actorVisSetting.TabIndex = 1;
            this.actorVisSetting.Text = "Actor Visible";
            this.actorVisSetting.UseVisualStyleBackColor = true;
            this.actorVisSetting.CheckedChanged += new System.EventHandler(this.actorVisSetting_CheckedChanged);
            // 
            // actorName
            // 
            this.actorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actorName.Location = new System.Drawing.Point(336, 20);
            this.actorName.Name = "actorName";
            this.actorName.Size = new System.Drawing.Size(260, 13);
            this.actorName.TabIndex = 2;
            this.actorName.Text = "--";
            // 
            // actorType
            // 
            this.actorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actorType.Location = new System.Drawing.Point(336, 33);
            this.actorType.Name = "actorType";
            this.actorType.Size = new System.Drawing.Size(260, 13);
            this.actorType.TabIndex = 3;
            this.actorType.Text = "--";
            // 
            // actorSaveName
            // 
            this.actorSaveName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.actorSaveName.Enabled = false;
            this.actorSaveName.Location = new System.Drawing.Point(479, 126);
            this.actorSaveName.Name = "actorSaveName";
            this.actorSaveName.Size = new System.Drawing.Size(117, 23);
            this.actorSaveName.TabIndex = 4;
            this.actorSaveName.Text = "Save by Name";
            this.actorSaveName.UseVisualStyleBackColor = true;
            this.actorSaveName.Click += new System.EventHandler(this.actorSaveName_Click);
            // 
            // actorSaveType
            // 
            this.actorSaveType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.actorSaveType.Enabled = false;
            this.actorSaveType.Location = new System.Drawing.Point(479, 97);
            this.actorSaveType.Name = "actorSaveType";
            this.actorSaveType.Size = new System.Drawing.Size(117, 23);
            this.actorSaveType.TabIndex = 5;
            this.actorSaveType.Text = "Save by Type";
            this.actorSaveType.UseVisualStyleBackColor = true;
            this.actorSaveType.Click += new System.EventHandler(this.actorSaveType_Click);
            // 
            // actorLightInten
            // 
            this.actorLightInten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actorLightInten.Enabled = false;
            this.actorLightInten.Location = new System.Drawing.Point(336, 94);
            this.actorLightInten.Name = "actorLightInten";
            this.actorLightInten.Size = new System.Drawing.Size(54, 20);
            this.actorLightInten.TabIndex = 6;
            this.actorLightInten.ValueChanged += new System.EventHandler(this.actorLightInten_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Light Intensity";
            // 
            // actorApplyToAllType
            // 
            this.actorApplyToAllType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.actorApplyToAllType.Enabled = false;
            this.actorApplyToAllType.Location = new System.Drawing.Point(479, 68);
            this.actorApplyToAllType.Name = "actorApplyToAllType";
            this.actorApplyToAllType.Size = new System.Drawing.Size(117, 23);
            this.actorApplyToAllType.TabIndex = 8;
            this.actorApplyToAllType.Text = "Apply to All Type";
            this.actorApplyToAllType.UseVisualStyleBackColor = true;
            this.actorApplyToAllType.Click += new System.EventHandler(this.actorApplyToAllType_Click);
            // 
            // actorListSearch
            // 
            this.actorListSearch.Location = new System.Drawing.Point(6, 20);
            this.actorListSearch.Name = "actorListSearch";
            this.actorListSearch.Size = new System.Drawing.Size(324, 20);
            this.actorListSearch.TabIndex = 9;
            this.actorListSearch.TextChanged += new System.EventHandler(this.actorListSearch_TextChanged);
            // 
            // actorEditPostProcessProps
            // 
            this.actorEditPostProcessProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actorEditPostProcessProps.Enabled = false;
            this.actorEditPostProcessProps.Location = new System.Drawing.Point(336, 65);
            this.actorEditPostProcessProps.Name = "actorEditPostProcessProps";
            this.actorEditPostProcessProps.Size = new System.Drawing.Size(132, 23);
            this.actorEditPostProcessProps.TabIndex = 10;
            this.actorEditPostProcessProps.Text = "Edit Post Process Props";
            this.actorEditPostProcessProps.UseVisualStyleBackColor = true;
            this.actorEditPostProcessProps.Click += new System.EventHandler(this.actorEditPostProcessProps_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(394, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save Profile";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(295, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Load Profile";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 393);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.captureBtn);
            this.Controls.Add(this.panel1);
            this.Name = "ConfigForm";
            this.Text = "ARK Map Capture Commander";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionZoomLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionCameraHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionMapSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionOffsetY)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processIdPicker)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actorLightInten)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button captureBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown optionZoomLevels;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown optionOffsetY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown optionOffsetX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown optionMapSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown optionCameraHeight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label processStatus;
        private System.Windows.Forms.Button processIdDiscoverButton;
        private System.Windows.Forms.NumericUpDown processIdPicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown actorLightInten;
        private System.Windows.Forms.Button actorSaveType;
        private System.Windows.Forms.Button actorSaveName;
        private System.Windows.Forms.Label actorType;
        private System.Windows.Forms.Label actorName;
        private System.Windows.Forms.CheckBox actorVisSetting;
        private System.Windows.Forms.ListBox actorList;
        private System.Windows.Forms.Button actorApplyToAllType;
        private System.Windows.Forms.TextBox actorListSearch;
        private System.Windows.Forms.Button actorEditPostProcessProps;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

