namespace DoAn
{
    partial class QuanLyLinhKien
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quayLạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinChungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GboxContain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quayLạiToolStripMenuItem,
            this.thôngTinChungToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1623, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.thôngTinChungToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.thôngTinChungToolStripMenuItem.Text = "Thông tin chung";
            this.thôngTinChungToolStripMenuItem.Click += new System.EventHandler(this.thôngTinChungToolStripMenuItem_Click);
            // 
            // GboxContain
            // 
            this.GboxContain.Location = new System.Drawing.Point(-7, 31);
            this.GboxContain.Name = "GboxContain";
            this.GboxContain.Size = new System.Drawing.Size(1634, 619);
            this.GboxContain.TabIndex = 1;
            // 
            // QuanLyLinhKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1623, 644);
            this.Controls.Add(this.GboxContain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QuanLyLinhKien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Linh Kiện";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyLinhKien_FormClosing);
            this.Load += new System.EventHandler(this.QuanLyLinhKien_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quayLạiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinChungToolStripMenuItem;
        private System.Windows.Forms.Panel GboxContain;
    }
}