namespace DoAn
{
    partial class QlyLuongNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QlyLuongNhanVien));
            this.lsvLuong = new System.Windows.Forms.ListView();
            this.Staff_STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Staff_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Staff_DFsalary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Staff_SalaryPerHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Staff_OT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Staff_Reward = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtLuongTheoGio = new System.Windows.Forms.TextBox();
            this.txtTienThuong = new System.Windows.Forms.TextBox();
            this.txtLamNgoaiGio = new System.Windows.Forms.TextBox();
            this.txtTongLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLuongCoBan = new System.Windows.Forms.TextBox();
            this.btnFeresh = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvLuong
            // 
            this.lsvLuong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Staff_STT,
            this.Staff_Id,
            this.Staff_DFsalary,
            this.Staff_SalaryPerHour,
            this.Staff_OT,
            this.Staff_Reward});
            this.lsvLuong.FullRowSelect = true;
            this.lsvLuong.GridLines = true;
            this.lsvLuong.HideSelection = false;
            this.lsvLuong.Location = new System.Drawing.Point(28, 314);
            this.lsvLuong.Name = "lsvLuong";
            this.lsvLuong.Size = new System.Drawing.Size(1205, 352);
            this.lsvLuong.TabIndex = 1;
            this.lsvLuong.UseCompatibleStateImageBehavior = false;
            this.lsvLuong.View = System.Windows.Forms.View.Details;
            this.lsvLuong.Click += new System.EventHandler(this.lsvLuong_Click);
            // 
            // Staff_STT
            // 
            this.Staff_STT.Text = "STT";
            // 
            // Staff_Id
            // 
            this.Staff_Id.Text = "Mã nhân viên";
            this.Staff_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Staff_Id.Width = 167;
            // 
            // Staff_DFsalary
            // 
            this.Staff_DFsalary.Text = "Lương cơ bản";
            this.Staff_DFsalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Staff_DFsalary.Width = 142;
            // 
            // Staff_SalaryPerHour
            // 
            this.Staff_SalaryPerHour.Text = "Lương theo giờ";
            this.Staff_SalaryPerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Staff_SalaryPerHour.Width = 168;
            // 
            // Staff_OT
            // 
            this.Staff_OT.Text = "Làm ngoài giờ";
            this.Staff_OT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Staff_OT.Width = 149;
            // 
            // Staff_Reward
            // 
            this.Staff_Reward.Text = "Tiền thưởng";
            this.Staff_Reward.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Staff_Reward.Width = 150;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(191, 73);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(208, 22);
            this.txtMaNV.TabIndex = 2;
            // 
            // txtLuongTheoGio
            // 
            this.txtLuongTheoGio.Enabled = false;
            this.txtLuongTheoGio.Location = new System.Drawing.Point(582, 73);
            this.txtLuongTheoGio.Name = "txtLuongTheoGio";
            this.txtLuongTheoGio.Size = new System.Drawing.Size(208, 22);
            this.txtLuongTheoGio.TabIndex = 8;
            // 
            // txtTienThuong
            // 
            this.txtTienThuong.Enabled = false;
            this.txtTienThuong.Location = new System.Drawing.Point(966, 76);
            this.txtTienThuong.Name = "txtTienThuong";
            this.txtTienThuong.Size = new System.Drawing.Size(208, 22);
            this.txtTienThuong.TabIndex = 9;
            // 
            // txtLamNgoaiGio
            // 
            this.txtLamNgoaiGio.Enabled = false;
            this.txtLamNgoaiGio.Location = new System.Drawing.Point(582, 131);
            this.txtLamNgoaiGio.Name = "txtLamNgoaiGio";
            this.txtLamNgoaiGio.Size = new System.Drawing.Size(208, 22);
            this.txtLamNgoaiGio.TabIndex = 10;
            // 
            // txtTongLuong
            // 
            this.txtTongLuong.Enabled = false;
            this.txtTongLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongLuong.ForeColor = System.Drawing.Color.Red;
            this.txtTongLuong.Location = new System.Drawing.Point(954, 136);
            this.txtTongLuong.Name = "txtTongLuong";
            this.txtTongLuong.Size = new System.Drawing.Size(237, 38);
            this.txtTongLuong.TabIndex = 11;
            this.txtTongLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(73, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(464, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Lương theo giờ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(848, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tiền thưởng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(464, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Làm ngoài giờ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1013, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tổng lương";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::DoAn.Properties.Resources.writing;
            this.pictureBox5.Location = new System.Drawing.Point(45, 74);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(22, 19);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::DoAn.Properties.Resources.salary;
            this.pictureBox3.Location = new System.Drawing.Point(820, 77);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::DoAn.Properties.Resources.salary;
            this.pictureBox4.Location = new System.Drawing.Point(436, 134);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(22, 19);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 52;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.Image = global::DoAn.Properties.Resources.time;
            this.pictureBox13.Location = new System.Drawing.Point(436, 74);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(22, 19);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 53;
            this.pictureBox13.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnUpdate.Image = global::DoAn.Properties.Resources.refresh__1_;
            this.btnUpdate.Location = new System.Drawing.Point(228, 211);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 83);
            this.btnUpdate.TabIndex = 54;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Enabled = false;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(622, 211);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 75);
            this.btnClear.TabIndex = 56;
            this.btnClear.TabStop = false;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::DoAn.Properties.Resources.salary;
            this.pictureBox2.Location = new System.Drawing.Point(45, 134);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(73, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 59;
            this.label8.Text = "Lương cơ bản";
            // 
            // txtLuongCoBan
            // 
            this.txtLuongCoBan.Enabled = false;
            this.txtLuongCoBan.Location = new System.Drawing.Point(191, 131);
            this.txtLuongCoBan.Name = "txtLuongCoBan";
            this.txtLuongCoBan.Size = new System.Drawing.Size(208, 22);
            this.txtLuongCoBan.TabIndex = 60;
            // 
            // btnFeresh
            // 
            this.btnFeresh.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFeresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFeresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeresh.Location = new System.Drawing.Point(1128, 275);
            this.btnFeresh.Name = "btnFeresh";
            this.btnFeresh.Size = new System.Drawing.Size(105, 33);
            this.btnFeresh.TabIndex = 64;
            this.btnFeresh.Text = "Làm mới";
            this.btnFeresh.UseVisualStyleBackColor = false;
            this.btnFeresh.Click += new System.EventHandler(this.btnFeresh_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(1047, 275);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 33);
            this.btnFind.TabIndex = 63;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(856, 281);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 22);
            this.txtSearch.TabIndex = 61;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(782, 284);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 62;
            this.label10.Text = "Tìm Kiếm";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::DoAn.Properties.Resources.beautiful_color_gradients_backgrounds_082_desert_hump;
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtLuongCoBan);
            this.panel1.Controls.Add(this.txtLamNgoaiGio);
            this.panel1.Controls.Add(this.txtLuongTheoGio);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.txtTongLuong);
            this.panel1.Controls.Add(this.pictureBox13);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTienThuong);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1338, 193);
            this.panel1.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "Sửa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(722, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 76;
            this.label3.Text = "Làm trống";
            // 
            // QlyLuongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1335, 678);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lsvLuong);
            this.Controls.Add(this.btnFeresh);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QlyLuongNhanVien";
            this.Text = "LuongNhanVien";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LuongNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.LuongNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lsvLuong;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtLuongTheoGio;
        private System.Windows.Forms.TextBox txtTienThuong;
        private System.Windows.Forms.TextBox txtLamNgoaiGio;
        private System.Windows.Forms.TextBox txtTongLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLuongCoBan;
        private System.Windows.Forms.Button btnFeresh;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader Staff_STT;
        private System.Windows.Forms.ColumnHeader Staff_Id;
        private System.Windows.Forms.ColumnHeader Staff_DFsalary;
        private System.Windows.Forms.ColumnHeader Staff_SalaryPerHour;
        private System.Windows.Forms.ColumnHeader Staff_OT;
        private System.Windows.Forms.ColumnHeader Staff_Reward;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}