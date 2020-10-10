namespace DoAn
{
    partial class QlyLichSuSuaChua
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
            this.lsvLichSu = new System.Windows.Forms.ListView();
            this.STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Customer_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Customer_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Customer_Sex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Customer_Birth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Customer_Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Customer_Phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Customer_TimeAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Repair_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Laptop_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Laptop_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Staff_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Repair_Reason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Repair_Note = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Repair_Appoinment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Repair_Money = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Repair_Time_End = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvLichSu
            // 
            this.lsvLichSu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.Customer_Id,
            this.Customer_Name,
            this.Customer_Sex,
            this.Customer_Birth,
            this.Customer_Email,
            this.Customer_Phone,
            this.Customer_TimeAdd,
            this.Repair_Id,
            this.Laptop_Name,
            this.Laptop_Status,
            this.Staff_Id,
            this.Repair_Reason,
            this.Repair_Note,
            this.Repair_Appoinment,
            this.Repair_Money,
            this.Repair_Time_End});
            this.lsvLichSu.FullRowSelect = true;
            this.lsvLichSu.GridLines = true;
            this.lsvLichSu.HideSelection = false;
            this.lsvLichSu.Location = new System.Drawing.Point(25, 152);
            this.lsvLichSu.Name = "lsvLichSu";
            this.lsvLichSu.Size = new System.Drawing.Size(1420, 361);
            this.lsvLichSu.TabIndex = 0;
            this.lsvLichSu.UseCompatibleStateImageBehavior = false;
            this.lsvLichSu.View = System.Windows.Forms.View.Details;
            this.lsvLichSu.Click += new System.EventHandler(this.lsvLichSu_Click);
            // 
            // STT
            // 
            this.STT.Text = "STT";
            // 
            // Customer_Id
            // 
            this.Customer_Id.Text = "Mã khách hàng";
            this.Customer_Id.Width = 120;
            // 
            // Customer_Name
            // 
            this.Customer_Name.Text = "Tên khách hàng";
            this.Customer_Name.Width = 119;
            // 
            // Customer_Sex
            // 
            this.Customer_Sex.Text = "Giới tính";
            this.Customer_Sex.Width = 74;
            // 
            // Customer_Birth
            // 
            this.Customer_Birth.Text = "Ngày sinh";
            this.Customer_Birth.Width = 89;
            // 
            // Customer_Email
            // 
            this.Customer_Email.Text = "Email";
            // 
            // Customer_Phone
            // 
            this.Customer_Phone.Text = "Điện thoại";
            this.Customer_Phone.Width = 86;
            // 
            // Customer_TimeAdd
            // 
            this.Customer_TimeAdd.Text = "Thời gian thêm";
            this.Customer_TimeAdd.Width = 110;
            // 
            // Repair_Id
            // 
            this.Repair_Id.Text = "Mã sửa chữa";
            this.Repair_Id.Width = 100;
            // 
            // Laptop_Name
            // 
            this.Laptop_Name.Text = "Tên laptop";
            this.Laptop_Name.Width = 101;
            // 
            // Laptop_Status
            // 
            this.Laptop_Status.Text = "Tình trạng laptop";
            this.Laptop_Status.Width = 127;
            // 
            // Staff_Id
            // 
            this.Staff_Id.Text = "Nhân viên tiếp nhận";
            this.Staff_Id.Width = 141;
            // 
            // Repair_Reason
            // 
            this.Repair_Reason.Text = "Lý do sửa";
            this.Repair_Reason.Width = 78;
            // 
            // Repair_Note
            // 
            this.Repair_Note.Text = "Ghi chú";
            this.Repair_Note.Width = 74;
            // 
            // Repair_Appoinment
            // 
            this.Repair_Appoinment.Text = "Lịch hẹn nhận máy";
            this.Repair_Appoinment.Width = 136;
            // 
            // Repair_Money
            // 
            this.Repair_Money.Text = "Tiền tạm tính";
            this.Repair_Money.Width = 96;
            // 
            // Repair_Time_End
            // 
            this.Repair_Time_End.Text = "Thời gian kết thúc";
            this.Repair_Time_End.Width = 132;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DoAn.Properties.Resources.fix;
            this.pictureBox2.Location = new System.Drawing.Point(485, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 38);
            this.label1.TabIndex = 50;
            this.label1.Text = "Quản lý lịch sử sữa chữa";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnXoa.Enabled = false;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Location = new System.Drawing.Point(1347, 77);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(98, 40);
            this.btnXoa.TabIndex = 52;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DoAn.Properties.Resources.remove;
            this.pictureBox1.Location = new System.Drawing.Point(1294, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(25, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 54;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QlyLichSuSuaChua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1468, 580);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvLichSu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QlyLichSuSuaChua";
            this.Text = "QlyLichSuSuaChua";
            this.Load += new System.EventHandler(this.QlyLichSuSuaChua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvLichSu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader STT;
        private System.Windows.Forms.ColumnHeader Customer_Id;
        private System.Windows.Forms.ColumnHeader Customer_Name;
        private System.Windows.Forms.ColumnHeader Customer_Sex;
        private System.Windows.Forms.ColumnHeader Customer_Birth;
        private System.Windows.Forms.ColumnHeader Customer_Email;
        private System.Windows.Forms.ColumnHeader Customer_Phone;
        private System.Windows.Forms.ColumnHeader Customer_TimeAdd;
        private System.Windows.Forms.ColumnHeader Repair_Id;
        private System.Windows.Forms.ColumnHeader Laptop_Name;
        private System.Windows.Forms.ColumnHeader Laptop_Status;
        private System.Windows.Forms.ColumnHeader Staff_Id;
        private System.Windows.Forms.ColumnHeader Repair_Reason;
        private System.Windows.Forms.ColumnHeader Repair_Note;
        private System.Windows.Forms.ColumnHeader Repair_Appoinment;
        private System.Windows.Forms.ColumnHeader Repair_Money;
        private System.Windows.Forms.ColumnHeader Repair_Time_End;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}