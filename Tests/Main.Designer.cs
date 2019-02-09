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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.gpControl.Size = new System.Drawing.Size(480, 112);
            this.gpControl.TabIndex = 28;
            this.gpControl.TabStop = false;
            this.gpControl.Text = "Shutter Control";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox2.Location = new System.Drawing.Point(406, 34);
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
            this.btOpenBoth.Location = new System.Drawing.Point(84, 34);
            this.btOpenBoth.Name = "btOpenBoth";
            this.btOpenBoth.Size = new System.Drawing.Size(24, 67);
            this.btOpenBoth.TabIndex = 19;
            this.btOpenBoth.Text = "OPEN";
            this.btOpenBoth.UseVisualStyleBackColor = true;
            this.btOpenBoth.Click += new System.EventHandler(this.btOpenBoth_Click);
            // 
            // btOpenLeft
            // 
            this.btOpenLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenLeft.Location = new System.Drawing.Point(126, 34);
            this.btOpenLeft.Name = "btOpenLeft";
            this.btOpenLeft.Size = new System.Drawing.Size(52, 23);
            this.btOpenLeft.TabIndex = 8;
            this.btOpenLeft.Text = "Open";
            this.btOpenLeft.UseVisualStyleBackColor = true;
            this.btOpenLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btOpenLeft_MouseDown);
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
            this.btCloseLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseLeft.Location = new System.Drawing.Point(184, 34);
            this.btCloseLeft.Name = "btCloseLeft";
            this.btCloseLeft.Size = new System.Drawing.Size(54, 23);
            this.btCloseLeft.TabIndex = 10;
            this.btCloseLeft.Text = "Close";
            this.btCloseLeft.UseVisualStyleBackColor = true;
            this.btCloseLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btCloseLeft_MouseDown);
            // 
            // btCloseBoth
            // 
            this.btCloseBoth.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCloseBoth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btCloseBoth.Location = new System.Drawing.Point(241, 34);
            this.btCloseBoth.Name = "btCloseBoth";
            this.btCloseBoth.Size = new System.Drawing.Size(31, 67);
            this.btCloseBoth.TabIndex = 20;
            this.btCloseBoth.Text = "CLOSE";
            this.btCloseBoth.UseVisualStyleBackColor = true;
            this.btCloseBoth.Click += new System.EventHandler(this.btCloseBoth_Click);
            // 
            // btOpenRight
            // 
            this.btOpenRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenRight.Location = new System.Drawing.Point(126, 78);
            this.btOpenRight.Name = "btOpenRight";
            this.btOpenRight.Size = new System.Drawing.Size(52, 23);
            this.btOpenRight.TabIndex = 11;
            this.btOpenRight.Text = "Open";
            this.btOpenRight.UseVisualStyleBackColor = true;
            this.btOpenRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btOpenRight_MouseDown);
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
            // lbRightShutterStatus
            // 
            this.lbRightShutterStatus.AutoSize = true;
            this.lbRightShutterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRightShutterStatus.Location = new System.Drawing.Point(290, 83);
            this.lbRightShutterStatus.Name = "lbRightShutterStatus";
            this.lbRightShutterStatus.Size = new System.Drawing.Size(132, 13);
            this.lbRightShutterStatus.TabIndex = 16;
            this.lbRightShutterStatus.Text = "{Right Shutter Status}";
            // 
            // btCloseRight
            // 
            this.btCloseRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseRight.Location = new System.Drawing.Point(184, 78);
            this.btCloseRight.Name = "btCloseRight";
            this.btCloseRight.Size = new System.Drawing.Size(54, 23);
            this.btCloseRight.TabIndex = 13;
            this.btCloseRight.Text = "Close";
            this.btCloseRight.UseVisualStyleBackColor = true;
            this.btCloseRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btCloseRight_MouseDown);
            // 
            // lbLeftShutterStatus
            // 
            this.lbLeftShutterStatus.AutoSize = true;
            this.lbLeftShutterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeftShutterStatus.Location = new System.Drawing.Point(290, 39);
            this.lbLeftShutterStatus.Name = "lbLeftShutterStatus";
            this.lbLeftShutterStatus.Size = new System.Drawing.Size(124, 13);
            this.lbLeftShutterStatus.TabIndex = 15;
            this.lbLeftShutterStatus.Text = "{Left Shutter Status}";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 248);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(500, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(436, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " ";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = " ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
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
            this.imageList1.Images.SetKeyName(0, "Both_Closed.jpg");
            this.imageList1.Images.SetKeyName(1, "Left_Open.jpg");
            this.imageList1.Images.SetKeyName(2, "Right_Open.jpg");
            this.imageList1.Images.SetKeyName(3, "Both_Open.jpg");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btCloseBoth;
            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.gpControl);
            this.Controls.Add(this.labelDriverId);
            this.Controls.Add(this.buttonChoose);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList imageList1;
    }
}

