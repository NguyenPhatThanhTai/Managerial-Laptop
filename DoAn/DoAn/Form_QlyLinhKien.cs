using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn
{
    public partial class QuanLyLinhKien : Form
    {
        public QuanLyLinhKien()
        {
            InitializeComponent();
        }

        int Role;
        string Name;

        public QuanLyLinhKien(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }

        private void AddToForm(Form f)
        {
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.GboxContain.Controls.Clear();
            this.GboxContain.Controls.Add(f);
            f.Show();
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void QuanLyLinhKien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn thoát à?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show();
                this.Hide();
            }
        }

        private void QuanLyLinhKien_Load(object sender, EventArgs e)
        {
            QlyLinhKien f = new QlyLinhKien(Role, Name);
            AddToForm(f);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DanhSachChucNang DSCN = new DanhSachChucNang(Role, Name);
            DSCN.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QlyLinhKien f = new QlyLinhKien(Role, Name);
            AddToForm(f);
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
