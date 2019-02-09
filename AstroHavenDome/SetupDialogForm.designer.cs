namespace ASCOM.AstroHaven
{
    partial class SetupDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDialogForm));
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxBaud = new System.Windows.Forms.TextBox();
            this.chkAntiLooseBelt = new System.Windows.Forms.CheckBox();
            this.ddMinDelayBetweenCommands = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLooseBeltThresholdLeft = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLooseBeltThresholdRight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddMinDelayBetweenCommands)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(395, 218);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(59, 32);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(14, 217);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(59, 33);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = ((System.Drawing.Image)(resources.GetObject("picASCOM.Image")));
            this.picASCOM.Location = new System.Drawing.Point(406, 9);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comm Port:";
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(15, 86);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(90, 17);
            this.chkTrace.TabIndex = 6;
            this.chkTrace.Text = "Enable Trace";
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(76, 12);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(90, 21);
            this.comboBoxComPort.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Speed (baud):";
            // 
            // textboxBaud
            // 
            this.textboxBaud.Location = new System.Drawing.Point(92, 49);
            this.textboxBaud.Name = "textboxBaud";
            this.textboxBaud.Size = new System.Drawing.Size(74, 20);
            this.textboxBaud.TabIndex = 9;
            this.textboxBaud.Text = "9600";
            // 
            // chkAntiLooseBelt
            // 
            this.chkAntiLooseBelt.AutoSize = true;
            this.chkAntiLooseBelt.Location = new System.Drawing.Point(14, 120);
            this.chkAntiLooseBelt.Name = "chkAntiLooseBelt";
            this.chkAntiLooseBelt.Size = new System.Drawing.Size(142, 17);
            this.chkAntiLooseBelt.TabIndex = 10;
            this.chkAntiLooseBelt.Text = "Anti-loose belt protection";
            this.chkAntiLooseBelt.UseVisualStyleBackColor = true;
            this.chkAntiLooseBelt.CheckedChanged += new System.EventHandler(this.chkAntiLooseBelt_CheckedChanged);
            // 
            // ddMinDelayBetweenCommands
            // 
            this.ddMinDelayBetweenCommands.Location = new System.Drawing.Point(176, 183);
            this.ddMinDelayBetweenCommands.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ddMinDelayBetweenCommands.Name = "ddMinDelayBetweenCommands";
            this.ddMinDelayBetweenCommands.Size = new System.Drawing.Size(73, 20);
            this.ddMinDelayBetweenCommands.TabIndex = 11;
            this.ddMinDelayBetweenCommands.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ddMinDelayBetweenCommands.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.ddMinDelayBetweenCommands.ValueChanged += new System.EventHandler(this.ddMinDelayBetweenCommands_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Min delay between commands :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "ms";
            // 
            // txtLooseBeltThresholdLeft
            // 
            this.txtLooseBeltThresholdLeft.Enabled = false;
            this.txtLooseBeltThresholdLeft.Location = new System.Drawing.Point(229, 148);
            this.txtLooseBeltThresholdLeft.Name = "txtLooseBeltThresholdLeft";
            this.txtLooseBeltThresholdLeft.Size = new System.Drawing.Size(49, 20);
            this.txtLooseBeltThresholdLeft.TabIndex = 14;
            this.txtLooseBeltThresholdLeft.Text = "5";
            this.txtLooseBeltThresholdLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(30, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Commands to send before full opening :";
            // 
            // txtLooseBeltThresholdRight
            // 
            this.txtLooseBeltThresholdRight.Enabled = false;
            this.txtLooseBeltThresholdRight.Location = new System.Drawing.Point(319, 148);
            this.txtLooseBeltThresholdRight.Name = "txtLooseBeltThresholdRight";
            this.txtLooseBeltThresholdRight.Size = new System.Drawing.Size(49, 20);
            this.txtLooseBeltThresholdRight.TabIndex = 16;
            this.txtLooseBeltThresholdRight.Text = "5";
            this.txtLooseBeltThresholdRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(226, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Left panel";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(316, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Right panel";
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 262);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLooseBeltThresholdRight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLooseBeltThresholdLeft);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddMinDelayBetweenCommands);
            this.Controls.Add(this.chkAntiLooseBelt);
            this.Controls.Add(this.textboxBaud);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxComPort);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AstroHaven Setup";
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddMinDelayBetweenCommands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTrace;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxBaud;
        private System.Windows.Forms.CheckBox chkAntiLooseBelt;
        private System.Windows.Forms.NumericUpDown ddMinDelayBetweenCommands;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLooseBeltThresholdLeft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLooseBeltThresholdRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}