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
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.btOpenNorth = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btCloseNorth = new System.Windows.Forms.Button();
            this.btCloseSouth = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btOpenSouth = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbStatusNorth = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ckStepByStep = new System.Windows.Forms.CheckBox();
            this.uiStep = new System.Windows.Forms.DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(208, 198);
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
            this.btCancel.Location = new System.Drawing.Point(134, 198);
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
            this.picASCOM.Location = new System.Drawing.Point(363, 9);
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
            // btOpenNorth
            // 
            this.btOpenNorth.Location = new System.Drawing.Point(77, 107);
            this.btOpenNorth.Name = "btOpenNorth";
            this.btOpenNorth.Size = new System.Drawing.Size(75, 23);
            this.btOpenNorth.TabIndex = 8;
            this.btOpenNorth.Text = "Open";
            this.btOpenNorth.UseVisualStyleBackColor = true;
            this.btOpenNorth.Click += new System.EventHandler(this.btOpenNorth_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "North";
            // 
            // btCloseNorth
            // 
            this.btCloseNorth.Location = new System.Drawing.Point(158, 107);
            this.btCloseNorth.Name = "btCloseNorth";
            this.btCloseNorth.Size = new System.Drawing.Size(75, 23);
            this.btCloseNorth.TabIndex = 10;
            this.btCloseNorth.Text = "Close";
            this.btCloseNorth.UseVisualStyleBackColor = true;
            this.btCloseNorth.Click += new System.EventHandler(this.btCloseNorth_Click);
            // 
            // btCloseSouth
            // 
            this.btCloseSouth.Location = new System.Drawing.Point(158, 138);
            this.btCloseSouth.Name = "btCloseSouth";
            this.btCloseSouth.Size = new System.Drawing.Size(75, 23);
            this.btCloseSouth.TabIndex = 13;
            this.btCloseSouth.Text = "Close";
            this.btCloseSouth.UseVisualStyleBackColor = true;
            this.btCloseSouth.Click += new System.EventHandler(this.btCloseSouth_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "South";
            // 
            // btOpenSouth
            // 
            this.btOpenSouth.Location = new System.Drawing.Point(77, 138);
            this.btOpenSouth.Name = "btOpenSouth";
            this.btOpenSouth.Size = new System.Drawing.Size(75, 23);
            this.btOpenSouth.TabIndex = 11;
            this.btOpenSouth.Text = "Open";
            this.btOpenSouth.UseVisualStyleBackColor = true;
            this.btOpenSouth.Click += new System.EventHandler(this.btOpenSouth_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(254, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Status";
            // 
            // lbStatusNorth
            // 
            this.lbStatusNorth.AutoSize = true;
            this.lbStatusNorth.Location = new System.Drawing.Point(254, 112);
            this.lbStatusNorth.Name = "lbStatusNorth";
            this.lbStatusNorth.Size = new System.Drawing.Size(105, 13);
            this.lbStatusNorth.TabIndex = 15;
            this.lbStatusNorth.Text = "{North Dome Status}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "{South Dome Status}";
            // 
            // ckStepByStep
            // 
            this.ckStepByStep.AutoSize = true;
            this.ckStepByStep.Location = new System.Drawing.Point(15, 48);
            this.ckStepByStep.Name = "ckStepByStep";
            this.ckStepByStep.Size = new System.Drawing.Size(85, 17);
            this.ckStepByStep.TabIndex = 17;
            this.ckStepByStep.Text = "Step by step";
            this.ckStepByStep.UseVisualStyleBackColor = true;
            this.ckStepByStep.CheckedChanged += new System.EventHandler(this.ckStepByStep_CheckedChanged);
            // 
            // uiStep
            // 
            this.uiStep.Items.Add("1");
            this.uiStep.Items.Add("5");
            this.uiStep.Items.Add("10");
            this.uiStep.Items.Add("20");
            this.uiStep.Items.Add("50");
            this.uiStep.Items.Add("100");
            this.uiStep.Location = new System.Drawing.Point(106, 47);
            this.uiStep.Name = "uiStep";
            this.uiStep.Size = new System.Drawing.Size(52, 20);
            this.uiStep.TabIndex = 18;
            this.uiStep.Text = "100";
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 234);
            this.Controls.Add(this.uiStep);
            this.Controls.Add(this.ckStepByStep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbStatusNorth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btCloseSouth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btOpenSouth);
            this.Controls.Add(this.btCloseNorth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btOpenNorth);
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
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
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
        private System.Windows.Forms.Button btOpenNorth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCloseNorth;
        private System.Windows.Forms.Button btCloseSouth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btOpenSouth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbStatusNorth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckStepByStep;
        private System.Windows.Forms.DomainUpDown uiStep;
    }
}