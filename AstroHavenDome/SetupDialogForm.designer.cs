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
            this.txtBaud = new System.Windows.Forms.TextBox();
            this.ddMinDelayBetweenCommands = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOnOpeningPauseAfter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picAstroHavenLogo = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOnClosingOverfeedDuring = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOnOpeningPauseDuring = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddMinDelayBetweenCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAstroHavenLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(371, 232);
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
            this.btCancel.Location = new System.Drawing.Point(15, 231);
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
            this.picASCOM.Location = new System.Drawing.Point(382, 12);
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
            this.label2.Location = new System.Drawing.Point(11, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comm Port:";
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(345, 94);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(90, 17);
            this.chkTrace.TabIndex = 6;
            this.chkTrace.Text = "Enable Trace";
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(75, 92);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(90, 21);
            this.comboBoxComPort.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Speed (baud):";
            // 
            // txtBaud
            // 
            this.txtBaud.Location = new System.Drawing.Point(255, 92);
            this.txtBaud.Name = "txtBaud";
            this.txtBaud.Size = new System.Drawing.Size(74, 20);
            this.txtBaud.TabIndex = 9;
            this.txtBaud.Text = "9600";
            // 
            // ddMinDelayBetweenCommands
            // 
            this.ddMinDelayBetweenCommands.Location = new System.Drawing.Point(178, 126);
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
            50,
            0,
            0,
            0});
            this.ddMinDelayBetweenCommands.ValueChanged += new System.EventHandler(this.ddMinDelayBetweenCommands_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Min delay between commands :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "ms";
            // 
            // txtOnOpeningPauseAfter
            // 
            this.txtOnOpeningPauseAfter.Enabled = false;
            this.txtOnOpeningPauseAfter.Location = new System.Drawing.Point(138, 162);
            this.txtOnOpeningPauseAfter.Name = "txtOnOpeningPauseAfter";
            this.txtOnOpeningPauseAfter.Size = new System.Drawing.Size(29, 20);
            this.txtOnOpeningPauseAfter.TabIndex = 14;
            this.txtOnOpeningPauseAfter.Text = "2";
            this.txtOnOpeningPauseAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(11, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "On opening, pause after";
            // 
            // picAstroHavenLogo
            // 
            this.picAstroHavenLogo.BackColor = System.Drawing.Color.Transparent;
            this.picAstroHavenLogo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picAstroHavenLogo.Image = ((System.Drawing.Image)(resources.GetObject("picAstroHavenLogo.Image")));
            this.picAstroHavenLogo.Location = new System.Drawing.Point(7, 2);
            this.picAstroHavenLogo.Name = "picAstroHavenLogo";
            this.picAstroHavenLogo.Size = new System.Drawing.Size(216, 75);
            this.picAstroHavenLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAstroHavenLogo.TabIndex = 34;
            this.picAstroHavenLogo.TabStop = false;
            this.picAstroHavenLogo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Overfeed when closing during";
            // 
            // txtOnClosingOverfeedDuring
            // 
            this.txtOnClosingOverfeedDuring.Enabled = false;
            this.txtOnClosingOverfeedDuring.Location = new System.Drawing.Point(166, 196);
            this.txtOnClosingOverfeedDuring.Name = "txtOnClosingOverfeedDuring";
            this.txtOnClosingOverfeedDuring.Size = new System.Drawing.Size(30, 20);
            this.txtOnClosingOverfeedDuring.TabIndex = 36;
            this.txtOnClosingOverfeedDuring.Text = "3";
            this.txtOnClosingOverfeedDuring.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "seconds";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(174, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "seconds, for a duration of";
            // 
            // txtOnOpeningPauseDuring
            // 
            this.txtOnOpeningPauseDuring.Enabled = false;
            this.txtOnOpeningPauseDuring.Location = new System.Drawing.Point(307, 162);
            this.txtOnOpeningPauseDuring.Name = "txtOnOpeningPauseDuring";
            this.txtOnOpeningPauseDuring.Size = new System.Drawing.Size(36, 20);
            this.txtOnOpeningPauseDuring.TabIndex = 39;
            this.txtOnOpeningPauseDuring.Text = "3";
            this.txtOnOpeningPauseDuring.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(349, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "seconds,";
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 276);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOnOpeningPauseDuring);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOnClosingOverfeedDuring);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picAstroHavenLogo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOnOpeningPauseAfter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddMinDelayBetweenCommands);
            this.Controls.Add(this.txtBaud);
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
            this.Text = "AstroHaven Dome ASCOM Driver Setup";
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddMinDelayBetweenCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAstroHavenLogo)).EndInit();
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
        private System.Windows.Forms.TextBox txtBaud;
        private System.Windows.Forms.NumericUpDown ddMinDelayBetweenCommands;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOnOpeningPauseAfter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picAstroHavenLogo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOnClosingOverfeedDuring;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOnOpeningPauseDuring;
        private System.Windows.Forms.Label label10;
    }
}