namespace DoAn
{
    partial class QlyKeToan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvKeToan = new System.Windows.Forms.ListView();
            this.STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RepairID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CusTimeAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CusTimeEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RepairMoney = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::DoAn.Properties.Resources.beautiful_color_gradients_backgrounds_075_clean_mirror;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtp2);
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Location = new System.Drawing.Point(-4, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1339, 196);
            this.panel1.TabIndex = 74;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lbTongTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.ForeColor = System.Drawing.Color.Tomato;
            this.lbTongTien.Location = new System.Drawing.Point(806, 136);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(245, 38);
            this.lbTongTien.TabIndex = 1;
            this.lbTongTien.Text = "000000000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.IndianRed;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(895, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng tiền";
            // 
            // lsvKeToan
            // 
            this.lsvKeToan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.RepairID,
            this.CusTimeAdd,
            this.CusTimeEnd,
            this.RepairMoney});
            this.lsvKeToan.FullRowSelect = true;
            this.lsvKeToan.GridLines = true;
            this.lsvKeToan.HideSelection = false;
            this.lsvKeToan.Location = new System.Drawing.Point(36, 263);
            this.lsvKeToan.Margin = new System.Windows.Forms.Padding(4);
            this.lsvKeToan.Name = "lsvKeToan";
            this.lsvKeToan.Size = new System.Drawing.Size(1168, 431);
            this.lsvKeToan.TabIndex = 75;
            this.lsvKeToan.UseCompatibleStateImageBehavior = false;
            this.lsvKeToan.View = System.Windows.Forms.View.Details;
            // 
            // STT
            // 
            this.STT.Text = "STT";
            // 
            // RepairID
            // 
            this.RepairID.Text = "Mã đơn sửa";
            this.RepairID.Width = 178;
            // 
            // CusTimeAdd
            // 
            this.CusTimeAdd.Text = "Thời gian bắt đầu";
            this.CusTimeAdd.Width = 179;
            // 
            // CusTimeEnd
            // 
            this.CusTimeEnd.Text = "Thời gian kết thúc";
            this.CusTimeEnd.Width = 178;
            // 
            // RepairMoney
            // 
            this.RepairMoney.Text = "Số tiền";
            this.RepairMoney.Width = 131;
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(163, 112);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(200, 22);
            this.dtp1.TabIndex = 76;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(460, 112);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(200, 22);
            this.dtp2.TabIndex = 77;
            this.dtp2.ValueChanged += new System.EventHandler(this.dtp2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(397, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = ">>>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(312, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 20);
            this.label3.TabIndex = 79;
            this.label3.Text = "Lọc theo thời gian kết thúc";
            // 
            // QlyKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 682);
            this.Controls.Add(this.lsvKeToan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QlyKeToan";
            this.Text = "QlyKeToan";
            this.Load += new System.EventHandler(this.QlyKeToan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvKeToan;
        private System.Windows.Forms.ColumnHeader STT;
        private System.Windows.Forms.ColumnHeader RepairID;
        private System.Windows.Forms.ColumnHeader CusTimeAdd;
        private System.Windows.Forms.ColumnHeader CusTimeEnd;
        private System.Windows.Forms.ColumnHeader RepairMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}