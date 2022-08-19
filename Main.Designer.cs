namespace CapNhatTonLoLem
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.numChuKy = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAn = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDemNguoc = new System.Windows.Forms.Label();
            this.chkKhoiDongCungWin = new System.Windows.Forms.CheckBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.tmrCapNhat = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrProccess = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLuuCauHinh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChuKy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(11, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 165);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sql Server";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(138, 121);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(470, 26);
            this.txtDatabase.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Database";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(138, 89);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(470, 26);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Pass";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(138, 57);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(470, 26);
            this.txtUser.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "User";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(138, 25);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(470, 26);
            this.txtServer.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Server";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(11, 410);
            this.progressBar.MarqueeAnimationSpeed = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 23);
            this.progressBar.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Phút";
            // 
            // numChuKy
            // 
            this.numChuKy.Location = new System.Drawing.Point(138, 25);
            this.numChuKy.Name = "numChuKy";
            this.numChuKy.Size = new System.Drawing.Size(63, 26);
            this.numChuKy.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Chu kì:";
            // 
            // btnAn
            // 
            this.btnAn.Location = new System.Drawing.Point(535, 410);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(90, 33);
            this.btnAn.TabIndex = 9;
            this.btnAn.Text = "Ẩn";
            this.btnAn.UseVisualStyleBackColor = true;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(439, 410);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(90, 33);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightCyan;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(637, 35);
            this.label1.TabIndex = 15;
            this.label1.Text = "CẬP NHẬT TỒN KHO HARAVAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDemNguoc);
            this.groupBox2.Controls.Add(this.chkKhoiDongCungWin);
            this.groupBox2.Controls.Add(this.numChuKy);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(11, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 96);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình";
            // 
            // lblDemNguoc
            // 
            this.lblDemNguoc.AutoSize = true;
            this.lblDemNguoc.Location = new System.Drawing.Point(375, 27);
            this.lblDemNguoc.Name = "lblDemNguoc";
            this.lblDemNguoc.Size = new System.Drawing.Size(0, 20);
            this.lblDemNguoc.TabIndex = 25;
            // 
            // chkKhoiDongCungWin
            // 
            this.chkKhoiDongCungWin.AutoSize = true;
            this.chkKhoiDongCungWin.Location = new System.Drawing.Point(138, 58);
            this.chkKhoiDongCungWin.Name = "chkKhoiDongCungWin";
            this.chkKhoiDongCungWin.Size = new System.Drawing.Size(202, 24);
            this.chkKhoiDongCungWin.TabIndex = 6;
            this.chkKhoiDongCungWin.Text = "Khởi động cùng windows";
            this.chkKhoiDongCungWin.UseVisualStyleBackColor = true;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(11, 387);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 20);
            this.lblThongBao.TabIndex = 24;
            // 
            // tmrCapNhat
            // 
            this.tmrCapNhat.Interval = 1000;
            this.tmrCapNhat.Tick += new System.EventHandler(this.tmrCapNhat_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            // 
            // tmrProccess
            // 
            this.tmrProccess.Tick += new System.EventHandler(this.tmrProccess_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtToken);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(11, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(614, 64);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Haravan";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(138, 25);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(470, 26);
            this.txtToken.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Token";
            // 
            // btnLuuCauHinh
            // 
            this.btnLuuCauHinh.Location = new System.Drawing.Point(317, 410);
            this.btnLuuCauHinh.Name = "btnLuuCauHinh";
            this.btnLuuCauHinh.Size = new System.Drawing.Size(116, 33);
            this.btnLuuCauHinh.TabIndex = 7;
            this.btnLuuCauHinh.Text = "Lưu cấu hình";
            this.btnLuuCauHinh.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 451);
            this.Controls.Add(this.btnLuuCauHinh);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnAn);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChuKy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numChuKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAn;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkKhoiDongCungWin;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label lblDemNguoc;
        private System.Windows.Forms.Timer tmrCapNhat;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer tmrProccess;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLuuCauHinh;
    }
}