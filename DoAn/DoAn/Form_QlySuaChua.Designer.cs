namespace DoAn
{
    partial class QuanLySuaChua
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
            this.quayLaijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinChungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửSửaChữaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GboxContain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quayLaijToolStripMenuItem,
            this.thôngTinChungToolStripMenuItem,
            this.lịchSửToolStripMenuItem,
            this.lịchSửSửaChữaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1618, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quayLaijToolStripMenuItem
            // 
            this.quayLaijToolStripMenuItem.Name = "quayLaijToolStripMenuItem";
            this.quayLaijToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.quayLaijToolStripMenuItem.Text = "Quay lại";
            this.quayLaijToolStripMenuItem.Click += new System.EventHandler(this.quayLaijToolStripMenuItem_Click);
            // 
            // thôngTinChungToolStripMenuItem
            // 
            this.thôngTinChungToolStripMenuItem.Name = "thôngTinChungToolStripMenuItem";
            this.thôngTinChungToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.thôngTinChungToolStripMenuItem.Text = "Thông tin khách hàng";
            this.thôngTinChungToolStripMenuItem.Click += new System.EventHandler(this.thôngTinChungToolStripMenuItem_Click);
            // 
            // lịchSửToolStripMenuItem
            // 
            this.lịchSửToolStripMenuItem.Name = "lịchSửToolStripMenuItem";
            this.lịchSửToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.lịchSửToolStripMenuItem.Text = "Thông tin sửa chữa";
            this.lịchSửToolStripMenuItem.Click += new System.EventHandler(this.lịchSửToolStripMenuItem_Click);
            // 
            // lịchSửSửaChữaToolStripMenuItem
            // 
            this.lịchSửSửaChữaToolStripMenuItem.Name = "lịchSửSửaChữaToolStripMenuItem";
            this.lịchSửSửaChữaToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.lịchSửSửaChữaToolStripMenuItem.Text = "Lịch sử sửa chữa";
            this.lịchSửSửaChữaToolStripMenuItem.Click += new System.EventHandler(this.lịchSửSửaChữaToolStripMenuItem_Click);
            // 
            // GboxContain
            // 
            this.GboxContain.Location = new System.Drawing.Point(0, 32);
            this.GboxContain.Name = "GboxContain";
            this.GboxContain.Size = new System.Drawing.Size(1618, 617);
            this.GboxContain.TabIndex = 1;
            // 
            // QuanLySuaChua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1618, 645);
            this.Controls.Add(this.GboxContain);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuanLySuaChua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sữa chữa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLySuaChua_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quayLaijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinChungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửToolStripMenuItem;
        private System.Windows.Forms.Panel GboxContain;
        private System.Windows.Forms.ToolStripMenuItem lịchSửSửaChữaToolStripMenuItem;
    }
}

