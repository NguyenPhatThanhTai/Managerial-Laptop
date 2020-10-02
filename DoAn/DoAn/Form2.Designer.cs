namespace DoAn
{
    partial class LichSuSuaChua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichSuSuaChua));
            this.listView2 = new System.Windows.Forms.ListView();
            this.STT_txt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ho_Ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SDT_txt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ten_May = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ly_Do = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tinh_Trang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ghi_Chu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tong_Tien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thoi_Gian_Ket_Thuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT_txt,
            this.Ho_Ten,
            this.Email,
            this.SDT_txt,
            this.Ten_May,
            this.Ly_Do,
            this.Tinh_Trang,
            this.Ghi_Chu,
            this.Tong_Tien,
            this.Thoi_Gian_Ket_Thuc});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(24, 54);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1345, 571);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Click += new System.EventHandler(this.listView2_Click);
            // 
            // STT_txt
            // 
            this.STT_txt.Text = "STT";
            this.STT_txt.Width = 47;
            // 
            // Ho_Ten
            // 
            this.Ho_Ten.Text = "Họ và tên";
            this.Ho_Ten.Width = 235;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 217;
            // 
            // SDT_txt
            // 
            this.SDT_txt.Text = "SDT";
            this.SDT_txt.Width = 198;
            // 
            // Ten_May
            // 
            this.Ten_May.Text = "Tên Máy";
            this.Ten_May.Width = 212;
            // 
            // Ly_Do
            // 
            this.Ly_Do.Text = "Chi tiết sửa";
            this.Ly_Do.Width = 171;
            // 
            // Tinh_Trang
            // 
            this.Tinh_Trang.Text = "Tình Trạng";
            this.Tinh_Trang.Width = 126;
            // 
            // Ghi_Chu
            // 
            this.Ghi_Chu.Text = "Ghi Chú";
            this.Ghi_Chu.Width = 115;
            // 
            // Tong_Tien
            // 
            this.Tong_Tien.Text = "Tổng số tiền";
            this.Tong_Tien.Width = 127;
            // 
            // Thoi_Gian_Ket_Thuc
            // 
            this.Thoi_Gian_Ket_Thuc.Text = "Thời Gian Kết Thúc";
            this.Thoi_Gian_Ket_Thuc.Width = 122;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.Delete);
            this.groupBox1.Controls.Add(this.listView2);
            this.groupBox1.Location = new System.Drawing.Point(62, 82);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1415, 708);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lịch sử ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DoAn.Properties.Resources.remove;
            this.pictureBox1.Location = new System.Drawing.Point(1217, 654);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Delete.Enabled = false;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Delete.Location = new System.Drawing.Point(1269, 654);
            this.Delete.Margin = new System.Windows.Forms.Padding(4);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(100, 28);
            this.Delete.TabIndex = 4;
            this.Delete.Text = "Xóa";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(718, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lịch sử sửa chữa";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 68);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LichSuSuaChua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1545, 825);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LichSuSuaChua";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch Sử Sữa Chữa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LichSuSuaChua_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader STT_txt;
        private System.Windows.Forms.ColumnHeader Ho_Ten;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader SDT_txt;
        private System.Windows.Forms.ColumnHeader Ten_May;
        private System.Windows.Forms.ColumnHeader Ly_Do;
        private System.Windows.Forms.ColumnHeader Tinh_Trang;
        private System.Windows.Forms.ColumnHeader Ghi_Chu;
        private System.Windows.Forms.ColumnHeader Tong_Tien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader Thoi_Gian_Ket_Thuc;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}