namespace VideoSaver
{
    partial class SettingsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.maskedTextBoxVideoFolder = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.checkBoxPlayInRandomOrder = new System.Windows.Forms.CheckBox();
            this.checkBoxStartAtRandomLocation = new System.Windows.Forms.CheckBox();
            this.numericUpDownSecondsUntilNextClip = new System.Windows.Forms.NumericUpDown();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.checkBoxStartNextVideoAfterTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecondsUntilNextClip)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // maskedTextBoxVideoFolder
            // 
            this.maskedTextBoxVideoFolder.Location = new System.Drawing.Point(82, 12);
            this.maskedTextBoxVideoFolder.Name = "maskedTextBoxVideoFolder";
            this.maskedTextBoxVideoFolder.Size = new System.Drawing.Size(277, 20);
            this.maskedTextBoxVideoFolder.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Video Folder:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(365, 10);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(25, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // checkBoxPlayInRandomOrder
            // 
            this.checkBoxPlayInRandomOrder.AutoSize = true;
            this.checkBoxPlayInRandomOrder.Location = new System.Drawing.Point(83, 38);
            this.checkBoxPlayInRandomOrder.Name = "checkBoxPlayInRandomOrder";
            this.checkBoxPlayInRandomOrder.Size = new System.Drawing.Size(165, 17);
            this.checkBoxPlayInRandomOrder.TabIndex = 5;
            this.checkBoxPlayInRandomOrder.Text = "Play Videos In Random Order";
            this.checkBoxPlayInRandomOrder.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartAtRandomLocation
            // 
            this.checkBoxStartAtRandomLocation.AutoSize = true;
            this.checkBoxStartAtRandomLocation.Location = new System.Drawing.Point(83, 61);
            this.checkBoxStartAtRandomLocation.Name = "checkBoxStartAtRandomLocation";
            this.checkBoxStartAtRandomLocation.Size = new System.Drawing.Size(202, 17);
            this.checkBoxStartAtRandomLocation.TabIndex = 6;
            this.checkBoxStartAtRandomLocation.Text = "Start Each Video At Random Position";
            this.checkBoxStartAtRandomLocation.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSecondsUntilNextClip
            // 
            this.numericUpDownSecondsUntilNextClip.Location = new System.Drawing.Point(83, 105);
            this.numericUpDownSecondsUntilNextClip.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSecondsUntilNextClip.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSecondsUntilNextClip.Name = "numericUpDownSecondsUntilNextClip";
            this.numericUpDownSecondsUntilNextClip.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownSecondsUntilNextClip.TabIndex = 7;
            this.numericUpDownSecondsUntilNextClip.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(142, 108);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(118, 13);
            this.labelSeconds.TabIndex = 8;
            this.labelSeconds.Text = "Seconds Until Next Clip";
            // 
            // checkBoxStartNextVideoAfterTime
            // 
            this.checkBoxStartNextVideoAfterTime.AutoSize = true;
            this.checkBoxStartNextVideoAfterTime.Location = new System.Drawing.Point(83, 83);
            this.checkBoxStartNextVideoAfterTime.Name = "checkBoxStartNextVideoAfterTime";
            this.checkBoxStartNextVideoAfterTime.Size = new System.Drawing.Size(182, 17);
            this.checkBoxStartNextVideoAfterTime.TabIndex = 9;
            this.checkBoxStartNextVideoAfterTime.Text = "Start Next Video After Fixed Time";
            this.checkBoxStartNextVideoAfterTime.UseVisualStyleBackColor = true;
            this.checkBoxStartNextVideoAfterTime.CheckedChanged += new System.EventHandler(this.checkBoxStartNextVideoAfterTime_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 172);
            this.Controls.Add(this.checkBoxStartNextVideoAfterTime);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.numericUpDownSecondsUntilNextClip);
            this.Controls.Add(this.checkBoxStartAtRandomLocation);
            this.Controls.Add(this.checkBoxPlayInRandomOrder);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBoxVideoFolder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "VideoSaver Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecondsUntilNextClip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxVideoFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.CheckBox checkBoxPlayInRandomOrder;
        private System.Windows.Forms.CheckBox checkBoxStartAtRandomLocation;
        private System.Windows.Forms.NumericUpDown numericUpDownSecondsUntilNextClip;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.CheckBox checkBoxStartNextVideoAfterTime;
    }
}