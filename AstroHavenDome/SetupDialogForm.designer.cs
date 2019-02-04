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
            this.components = new System.ComponentModel.Container();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.btOpenLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btCloseLeft = new System.Windows.Forms.Button();
            this.btCloseRight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btOpenRight = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbLeftShutterStatus = new System.Windows.Forms.Label();
            this.lbRightShutterStatus = new System.Windows.Forms.Label();
            this.btOpenBoth = new System.Windows.Forms.Button();
            this.btCloseBoth = new System.Windows.Forms.Button();
            this.lbConnectedStatus = new System.Windows.Forms.Label();
            this.gpControl = new System.Windows.Forms.GroupBox();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.gpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(230, 219);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(59, 24);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(156, 219);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(59, 25);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.AstroHaven.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(385, 9);
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
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comm Port";
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(182, 15);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(69, 17);
            this.chkTrace.TabIndex = 6;
            this.chkTrace.Text = "Trace on";
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
            // btOpenLeft
            // 
            this.btOpenLeft.Location = new System.Drawing.Point(126, 34);
            this.btOpenLeft.Name = "btOpenLeft";
            this.btOpenLeft.Size = new System.Drawing.Size(52, 23);
            this.btOpenLeft.TabIndex = 8;
            this.btOpenLeft.Text = "Open";
            this.btOpenLeft.UseVisualStyleBackColor = true;
            this.btOpenLeft.Click += new System.EventHandler(this.btOpenLeft_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Left shutter";
            // 
            // btCloseLeft
            // 
            this.btCloseLeft.Location = new System.Drawing.Point(184, 34);
            this.btCloseLeft.Name = "btCloseLeft";
            this.btCloseLeft.Size = new System.Drawing.Size(54, 23);
            this.btCloseLeft.TabIndex = 10;
            this.btCloseLeft.Text = "Close";
            this.btCloseLeft.UseVisualStyleBackColor = true;
            this.btCloseLeft.Click += new System.EventHandler(this.btCloseLeft_Click);
            // 
            // btCloseRight
            // 
            this.btCloseRight.Location = new System.Drawing.Point(184, 78);
            this.btCloseRight.Name = "btCloseRight";
            this.btCloseRight.Size = new System.Drawing.Size(54, 23);
            this.btCloseRight.TabIndex = 13;
            this.btCloseRight.Text = "Close";
            this.btCloseRight.UseVisualStyleBackColor = true;
            this.btCloseRight.Click += new System.EventHandler(this.btCloseRight_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Right shutter";
            // 
            // btOpenRight
            // 
            this.btOpenRight.Location = new System.Drawing.Point(126, 78);
            this.btOpenRight.Name = "btOpenRight";
            this.btOpenRight.Size = new System.Drawing.Size(52, 23);
            this.btOpenRight.TabIndex = 11;
            this.btOpenRight.Text = "Open";
            this.btOpenRight.UseVisualStyleBackColor = true;
            this.btOpenRight.Click += new System.EventHandler(this.btOpenRight_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Status";
            // 
            // lbLeftShutterStatus
            // 
            this.lbLeftShutterStatus.AutoSize = true;
            this.lbLeftShutterStatus.Location = new System.Drawing.Point(290, 39);
            this.lbLeftShutterStatus.Name = "lbLeftShutterStatus";
            this.lbLeftShutterStatus.Size = new System.Drawing.Size(103, 13);
            this.lbLeftShutterStatus.TabIndex = 15;
            this.lbLeftShutterStatus.Text = "{Left Shutter Status}";
            // 
            // lbRightShutterStatus
            // 
            this.lbRightShutterStatus.AutoSize = true;
            this.lbRightShutterStatus.Location = new System.Drawing.Point(290, 83);
            this.lbRightShutterStatus.Name = "lbRightShutterStatus";
            this.lbRightShutterStatus.Size = new System.Drawing.Size(110, 13);
            this.lbRightShutterStatus.TabIndex = 16;
            this.lbRightShutterStatus.Text = "{Right Shutter Status}";
            // 
            // btOpenBoth
            // 
            this.btOpenBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btOpenBoth.Location = new System.Drawing.Point(84, 34);
            this.btOpenBoth.Name = "btOpenBoth";
            this.btOpenBoth.Size = new System.Drawing.Size(36, 67);
            this.btOpenBoth.TabIndex = 19;
            this.btOpenBoth.Text = "OPEN";
            this.btOpenBoth.UseVisualStyleBackColor = true;
            this.btOpenBoth.Click += new System.EventHandler(this.btOpenBoth_Click);
            // 
            // btCloseBoth
            // 
            this.btCloseBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btCloseBoth.Location = new System.Drawing.Point(241, 34);
            this.btCloseBoth.Name = "btCloseBoth";
            this.btCloseBoth.Size = new System.Drawing.Size(43, 67);
            this.btCloseBoth.TabIndex = 20;
            this.btCloseBoth.Text = "CLOSE";
            this.btCloseBoth.UseVisualStyleBackColor = true;
            this.btCloseBoth.Click += new System.EventHandler(this.btCloseBoth_Click);
            // 
            // lbConnectedStatus
            // 
            this.lbConnectedStatus.AutoSize = true;
            this.lbConnectedStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConnectedStatus.Location = new System.Drawing.Point(196, 61);
            this.lbConnectedStatus.Name = "lbConnectedStatus";
            this.lbConnectedStatus.Size = new System.Drawing.Size(97, 13);
            this.lbConnectedStatus.TabIndex = 23;
            this.lbConnectedStatus.Text = "{ConnectedStatus}";
            // 
            // gpControl
            // 
            this.gpControl.Controls.Add(this.btOpenBoth);
            this.gpControl.Controls.Add(this.btOpenLeft);
            this.gpControl.Controls.Add(this.label1);
            this.gpControl.Controls.Add(this.btCloseLeft);
            this.gpControl.Controls.Add(this.btCloseBoth);
            this.gpControl.Controls.Add(this.btOpenRight);
            this.gpControl.Controls.Add(this.label3);
            this.gpControl.Controls.Add(this.lbRightShutterStatus);
            this.gpControl.Controls.Add(this.btCloseRight);
            this.gpControl.Controls.Add(this.lbLeftShutterStatus);
            this.gpControl.Controls.Add(this.label4);
            this.gpControl.Enabled = false;
            this.gpControl.Location = new System.Drawing.Point(15, 92);
            this.gpControl.Name = "gpControl";
            this.gpControl.Size = new System.Drawing.Size(419, 112);
            this.gpControl.TabIndex = 24;
            this.gpControl.TabStop = false;
            this.gpControl.Text = "Shutter Control";
            // 
            // btDisconnect
            // 
            this.btDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btDisconnect.Location = new System.Drawing.Point(99, 55);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(80, 25);
            this.btDisconnect.TabIndex = 26;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.UseVisualStyleBackColor = true;
            // 
            // btConnect
            // 
            this.btConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btConnect.Location = new System.Drawing.Point(25, 55);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(59, 25);
            this.btConnect.TabIndex = 25;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            // 
            // timerStatus
            // 
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 255);
            this.Controls.Add(this.btDisconnect);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.gpControl);
            this.Controls.Add(this.lbConnectedStatus);
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
            this.gpControl.ResumeLayout(false);
            this.gpControl.PerformLayout();
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
        private System.Windows.Forms.Button btOpenLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCloseLeft;
        private System.Windows.Forms.Button btCloseRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btOpenRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbLeftShutterStatus;
        private System.Windows.Forms.Label lbRightShutterStatus;
        private System.Windows.Forms.Button btOpenBoth;
        private System.Windows.Forms.Button btCloseBoth;
        private System.Windows.Forms.Label lbConnectedStatus;
        private System.Windows.Forms.GroupBox gpControl;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Timer timerStatus;
    }
}