namespace DoAn
{
    partial class QlyLinhKien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QlyLinhKien));
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtNhaSanXuat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgayThemLinhKien = new System.Windows.Forms.TextBox();
            this.txtLocHang = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTenLinhKien = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Ly_Do = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ngay_Them = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nha_San_Xuat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.So_Luong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenLinhKien = new System.Windows.Forms.Label();
            this.Ten_Linh_Kien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.STT_txt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView3 = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFeresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(425, 468);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 80);
            this.btnClear.TabIndex = 17;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 473);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ngày thêm linh kiện";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DoAn.Properties.Resources.analytics;
            this.pictureBox4.Location = new System.Drawing.Point(659, 61);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(85, 48);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 519);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Ghi chú";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1099, 123);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 22);
            this.txtSearch.TabIndex = 26;
            // 
            // txtNhaSanXuat
            // 
            this.txtNhaSanXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaSanXuat.FormattingEnabled = true;
            this.txtNhaSanXuat.Items.AddRange(new object[] {
            "Lenovo",
            "Acer",
            "Apple",
            "Asus",
            "Msi",
            "Khac"});
            this.txtNhaSanXuat.Location = new System.Drawing.Point(170, 418);
            this.txtNhaSanXuat.Name = "txtNhaSanXuat";
            this.txtNhaSanXuat.Size = new System.Drawing.Size(216, 24);
            this.txtNhaSanXuat.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 421);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nhà sản xuất";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(170, 516);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(216, 22);
            this.txtGhiChu.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Lọc theo tên máy";
            // 
            // txtNgayThemLinhKien
            // 
            this.txtNgayThemLinhKien.Enabled = false;
            this.txtNgayThemLinhKien.Location = new System.Drawing.Point(170, 470);
            this.txtNgayThemLinhKien.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgayThemLinhKien.Name = "txtNgayThemLinhKien";
            this.txtNgayThemLinhKien.Size = new System.Drawing.Size(216, 22);
            this.txtNgayThemLinhKien.TabIndex = 11;
            // 
            // txtLocHang
            // 
            this.txtLocHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocHang.FormattingEnabled = true;
            this.txtLocHang.Items.AddRange(new object[] {
            "Lenovo",
            "Acer",
            "Apple",
            "Asus",
            "Msi",
            "Khac"});
            this.txtLocHang.Location = new System.Drawing.Point(218, 171);
            this.txtLocHang.Name = "txtLocHang";
            this.txtLocHang.Size = new System.Drawing.Size(216, 33);
            this.txtLocHang.TabIndex = 15;
            this.txtLocHang.TextChanged += new System.EventHandler(this.txtLocHang_TextChanged);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(170, 370);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(216, 22);
            this.txtSoLuong.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 373);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Số lượng";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(425, 302);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 77);
            this.btnThem.TabIndex = 6;
            this.btnThem.TabStop = false;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTenLinhKien
            // 
            this.txtTenLinhKien.Location = new System.Drawing.Point(170, 324);
            this.txtTenLinhKien.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenLinhKien.Name = "txtTenLinhKien";
            this.txtTenLinhKien.Size = new System.Drawing.Size(216, 22);
            this.txtTenLinhKien.TabIndex = 3;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Transparent;
            this.btnSua.Enabled = false;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(425, 398);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 63);
            this.btnSua.TabIndex = 7;
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Location = new System.Drawing.Point(1290, 123);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 29;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1025, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tìm Kiếm";
            // 
            // Ly_Do
            // 
            this.Ly_Do.Text = "Ghi chú";
            this.Ly_Do.Width = 560;
            // 
            // Ngay_Them
            // 
            this.Ngay_Them.Text = "Ngày thêm linh kiện";
            this.Ngay_Them.Width = 185;
            // 
            // Nha_San_Xuat
            // 
            this.Nha_San_Xuat.Text = "Nhà sản xuất";
            this.Nha_San_Xuat.Width = 203;
            // 
            // So_Luong
            // 
            this.So_Luong.Text = "Số lượng";
            this.So_Luong.Width = 206;
            // 
            // TenLinhKien
            // 
            this.TenLinhKien.AutoSize = true;
            this.TenLinhKien.Location = new System.Drawing.Point(30, 327);
            this.TenLinhKien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TenLinhKien.Name = "TenLinhKien";
            this.TenLinhKien.Size = new System.Drawing.Size(89, 17);
            this.TenLinhKien.TabIndex = 0;
            this.TenLinhKien.Text = "Tên linh kiện";
            // 
            // Ten_Linh_Kien
            // 
            this.Ten_Linh_Kien.Text = "Tên linh kiện";
            this.Ten_Linh_Kien.Width = 256;
            // 
            // STT_txt
            // 
            this.STT_txt.Text = "STT";
            this.STT_txt.Width = 53;
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT_txt,
            this.Ten_Linh_Kien,
            this.So_Luong,
            this.Nha_San_Xuat,
            this.Ngay_Them,
            this.Ly_Do});
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(555, 171);
            this.listView3.Margin = new System.Windows.Forms.Padding(4);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(904, 379);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.Click += new System.EventHandler(this.listView3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(322, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(331, 46);
            this.label8.TabIndex = 31;
            this.label8.Text = "Quản lý linh kiện";
            // 
            // btnFeresh
            // 
            this.btnFeresh.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFeresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFeresh.Location = new System.Drawing.Point(1371, 123);
            this.btnFeresh.Name = "btnFeresh";
            this.btnFeresh.Size = new System.Drawing.Size(75, 23);
            this.btnFeresh.TabIndex = 30;
            this.btnFeresh.Text = "Làm mới";
            this.btnFeresh.UseVisualStyleBackColor = false;
            this.btnFeresh.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // QlyLinhKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1472, 578);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtNhaSanXuat);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNgayThemLinhKien);
            this.Controls.Add(this.btnFeresh);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocHang);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTenLinhKien);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.TenLinhKien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QlyLinhKien";
            this.Text = "QlyLinhKien";
            this.Load += new System.EventHandler(this.QlyLinhKien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox txtNhaSanXuat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNgayThemLinhKien;
        private System.Windows.Forms.ComboBox txtLocHang;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTenLinhKien;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Ly_Do;
        private System.Windows.Forms.ColumnHeader Ngay_Them;
        private System.Windows.Forms.ColumnHeader Nha_San_Xuat;
        private System.Windows.Forms.ColumnHeader So_Luong;
        private System.Windows.Forms.Label TenLinhKien;
        private System.Windows.Forms.ColumnHeader Ten_Linh_Kien;
        private System.Windows.Forms.ColumnHeader STT_txt;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFeresh;
    }
}