namespace DoAn
{
    partial class QuanLyNhanVien
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
            this.quayLạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinChungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TroGiupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lươngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tàiKhoảnNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GboxContain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // quayLạiToolStripMenuItem
            // 
            this.quayLạiToolStripMenuItem.Name = "quayLạiToolStripMenuItem";
            this.quayLạiToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.quayLạiToolStripMenuItem.Text = "Quay lại";
            this.quayLạiToolStripMenuItem.Click += new System.EventHandler(this.quayLạiToolStripMenuItem_Click);
            // 
            // thôngTinChungToolStripMenuItem
            // 
            this.thôngTinChungToolStripMenuItem.Name = "thôngTinChungToolStripMenuItem";
            this.thôngTinChungToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.thôngTinChungToolStripMenuItem.Text = "Thông tin nhân viên";
            this.thôngTinChungToolStripMenuItem.Click += new System.EventHandler(this.thôngTinChungToolStripMenuItem_Click);
            // 
            // TroGiupToolStripMenuItem
            // 
            this.TroGiupToolStripMenuItem.Name = "TroGiupToolStripMenuItem";
            this.TroGiupToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.TroGiupToolStripMenuItem.Text = "Trợ giúp";
            this.TroGiupToolStripMenuItem.Click += new System.EventHandler(this.TroGiupToolStripMenuItem_Click);
            // 
            // lươngToolStripMenuItem
            // 
            this.lươngToolStripMenuItem.Name = "lươngToolStripMenuItem";
            this.lươngToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.lươngToolStripMenuItem.Text = "Lương nhân viên";
            this.lươngToolStripMenuItem.Click += new System.EventHandler(this.lươngToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quayLạiToolStripMenuItem,
            this.thôngTinChungToolStripMenuItem,
            this.tàiKhoảnNhânViênToolStripMenuItem,
            this.lươngToolStripMenuItem,
            this.TroGiupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1642, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tàiKhoảnNhânViênToolStripMenuItem
            // 
            this.tàiKhoảnNhânViênToolStripMenuItem.Name = "tàiKhoảnNhânViênToolStripMenuItem";
            this.tàiKhoảnNhânViênToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.tàiKhoảnNhânViênToolStripMenuItem.Text = "Tài khoản nhân viên";
            this.tàiKhoảnNhânViênToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnNhânViênToolStripMenuItem_Click);
            // 
            // GboxContain
            // 
            this.GboxContain.Location = new System.Drawing.Point(0, 27);
            this.GboxContain.Name = "GboxContain";
            this.GboxContain.Size = new System.Drawing.Size(1650, 713);
            this.GboxContain.TabIndex = 19;
            // 
            // QuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1642, 731);
            this.Controls.Add(this.GboxContain);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QuanLyNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.QuanLyNhanVien_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem quayLạiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinChungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TroGiupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lươngToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel GboxContain;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnNhânViênToolStripMenuItem;
    }
}