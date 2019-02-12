namespace ASCOM.AstroHaven
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonChoose = new System.Windows.Forms.Button();
            this.labelDriverId = new System.Windows.Forms.Label();
            this.btConnect = new System.Windows.Forms.Button();
            this.gpControl = new System.Windows.Forms.GroupBox();
            this.btAbort = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btOpenBoth = new System.Windows.Forms.Button();
            this.btOpenLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btCloseLeft = new System.Windows.Forms.Button();
            this.btCloseBoth = new System.Windows.Forms.Button();
            this.btOpenRight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRightShutterStatus = new System.Windows.Forms.Label();
            this.btCloseRight = new System.Windows.Forms.Button();
            this.lbLeftShutterStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.picAstroHaven = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAstroHaven)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonChoose
            // 
            this.buttonChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChoose.ForeColor = System.Drawing.Color.Red;
            this.buttonChoose.Location = new System.Drawing.Point(240, 88);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(25, 23);
            this.buttonChoose.TabIndex = 0;
            this.buttonChoose.Text = "... ";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // labelDriverId
            // 
            this.labelDriverId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDriverId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.AstroHaven.Properties.Settings.Default, "DriverId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelDriverId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDriverId.ForeColor = System.Drawing.Color.Red;
            this.labelDriverId.Location = new System.Drawing.Point(83, 90);
            this.labelDriverId.Name = "labelDriverId";
            this.labelDriverId.Size = new System.Drawing.Size(151, 21);
            this.labelDriverId.TabIndex = 2;
            this.labelDriverId.Text = global::ASCOM.AstroHaven.Properties.Settings.Default.DriverId;
            this.labelDriverId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btConnect
            // 
            this.btConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConnect.ForeColor = System.Drawing.Color.Red;
            this.btConnect.Location = new System.Drawing.Point(403, 81);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(85, 38);
            this.btConnect.TabIndex = 29;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // gpControl
            // 
            this.gpControl.Controls.Add(this.btAbort);
            this.gpControl.Controls.Add(this.pictureBox2);
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
            this.gpControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gpControl.ForeColor = System.Drawing.Color.Red;
            this.gpControl.Location = new System.Drawing.Point(8, 123);
            this.gpControl.Name = "gpControl";
            this.gpControl.Size = new System.Drawing.Size(480, 142);
            this.gpControl.TabIndex = 28;
            this.gpControl.TabStop = false;
            this.gpControl.Text = "Shutter Control";
            // 
            // btAbort
            // 
            this.btAbort.BackColor = System.Drawing.Color.Maroon;
            this.btAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btAbort.ForeColor = System.Drawing.Color.White;
            this.btAbort.Location = new System.Drawing.Point(96, 107);
            this.btAbort.Name = "btAbort";
            this.btAbort.Size = new System.Drawing.Size(174, 29);
            this.btAbort.TabIndex = 36;
            this.btAbort.Text = "STOP";
            this.btAbort.UseVisualStyleBackColor = false;
            this.btAbort.Click += new System.EventHandler(this.btAbort_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox2.Location = new System.Drawing.Point(395, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // btOpenBoth
            // 
            this.btOpenBoth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btOpenBoth.Location = new System.Drawing.Point(96, 19);
            this.btOpenBoth.Name = "btOpenBoth";
            this.btOpenBoth.Size = new System.Drawing.Size(24, 82);
            this.btOpenBoth.TabIndex = 19;
            this.btOpenBoth.Text = "OPEN";
            this.btOpenBoth.UseVisualStyleBackColor = true;
            this.btOpenBoth.Click += new System.EventHandler(this.btOpenBoth_Click);
            // 
            // btOpenLeft
            // 
            this.btOpenLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenLeft.Location = new System.Drawing.Point(126, 19);
            this.btOpenLeft.Name = "btOpenLeft";
            this.btOpenLeft.Size = new System.Drawing.Size(52, 33);
            this.btOpenLeft.TabIndex = 8;
            this.btOpenLeft.Text = "Open";
            this.btOpenLeft.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Left shutter";
            // 
            // btCloseLeft
            // 
            this.btCloseLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseLeft.Location = new System.Drawing.Point(184, 19);
            this.btCloseLeft.Name = "btCloseLeft";
            this.btCloseLeft.Size = new System.Drawing.Size(54, 33);
            this.btCloseLeft.TabIndex = 10;
            this.btCloseLeft.Text = "Close";
            this.btCloseLeft.UseVisualStyleBackColor = true;
            // 
            // btCloseBoth
            // 
            this.btCloseBoth.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCloseBoth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btCloseBoth.Location = new System.Drawing.Point(241, 19);
            this.btCloseBoth.Name = "btCloseBoth";
            this.btCloseBoth.Size = new System.Drawing.Size(29, 82);
            this.btCloseBoth.TabIndex = 20;
            this.btCloseBoth.Text = "CLOSE";
            this.btCloseBoth.UseVisualStyleBackColor = true;
            this.btCloseBoth.Click += new System.EventHandler(this.btCloseBoth_Click);
            // 
            // btOpenRight
            // 
            this.btOpenRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenRight.Location = new System.Drawing.Point(126, 70);
            this.btOpenRight.Name = "btOpenRight";
            this.btOpenRight.Size = new System.Drawing.Size(52, 31);
            this.btOpenRight.TabIndex = 11;
            this.btOpenRight.Text = "Open";
            this.btOpenRight.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Right shutter";
            // 
            // lbRightShutterStatus
            // 
            this.lbRightShutterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRightShutterStatus.Location = new System.Drawing.Point(282, 70);
            this.lbRightShutterStatus.Name = "lbRightShutterStatus";
            this.lbRightShutterStatus.Size = new System.Drawing.Size(80, 13);
            this.lbRightShutterStatus.TabIndex = 16;
            this.lbRightShutterStatus.Text = "{Right Shutter Status}";
            // 
            // btCloseRight
            // 
            this.btCloseRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseRight.Location = new System.Drawing.Point(184, 70);
            this.btCloseRight.Name = "btCloseRight";
            this.btCloseRight.Size = new System.Drawing.Size(54, 31);
            this.btCloseRight.TabIndex = 13;
            this.btCloseRight.Text = "Close";
            this.btCloseRight.UseVisualStyleBackColor = true;
            // 
            // lbLeftShutterStatus
            // 
            this.lbLeftShutterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeftShutterStatus.Location = new System.Drawing.Point(282, 29);
            this.lbLeftShutterStatus.Name = "lbLeftShutterStatus";
            this.lbLeftShutterStatus.Size = new System.Drawing.Size(80, 13);
            this.lbLeftShutterStatus.TabIndex = 15;
            this.lbLeftShutterStatus.Text = "{Left Shutter Status}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(282, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Status";
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = ((System.Drawing.Image)(resources.GetObject("picASCOM.Image")));
            this.picASCOM.Location = new System.Drawing.Point(440, 10);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 31;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.picASCOM_Click);
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(500, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(436, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " ";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = " ";
            // 
            // picAstroHaven
            // 
            this.picAstroHaven.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picAstroHaven.BackColor = System.Drawing.Color.Transparent;
            this.picAstroHaven.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picAstroHaven.Image = ((System.Drawing.Image)(resources.GetObject("picAstroHaven.Image")));
            this.picAstroHaven.Location = new System.Drawing.Point(8, 5);
            this.picAstroHaven.Name = "picAstroHaven";
            this.picAstroHaven.Size = new System.Drawing.Size(216, 75);
            this.picAstroHaven.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAstroHaven.TabIndex = 33;
            this.picAstroHaven.TabStop = false;
            this.picAstroHaven.Click += new System.EventHandler(this.picAstroHaven_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(8, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Dome Driver:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Both_Closed.png");
            this.imageList1.Images.SetKeyName(1, "Left_Open.png");
            this.imageList1.Images.SetKeyName(2, "Right_Open.png");
            this.imageList1.Images.SetKeyName(3, "Both_Open.png");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(8, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Tip: Shift-click on buttons to enable step by step actions.";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btCloseBoth;
            this.ClientSize = new System.Drawing.Size(500, 331);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.gpControl);
            this.Controls.Add(this.labelDriverId);
            this.Controls.Add(this.buttonChoose);
            this.Controls.Add(this.picAstroHaven);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "AstroHaven Dome Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpControl.ResumeLayout(false);
            this.gpControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAstroHaven)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Label labelDriverId;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.GroupBox gpControl;
        private System.Windows.Forms.Button btOpenBoth;
        private System.Windows.Forms.Button btOpenLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCloseLeft;
        private System.Windows.Forms.Button btCloseBoth;
        private System.Windows.Forms.Button btOpenRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRightShutterStatus;
        private System.Windows.Forms.Button btCloseRight;
        private System.Windows.Forms.Label lbLeftShutterStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.PictureBox picAstroHaven;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btAbort;
    }
}

