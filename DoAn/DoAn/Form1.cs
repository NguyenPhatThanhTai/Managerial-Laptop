using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class QuanLySuaChua : Form
    {
        public QuanLySuaChua()
        {
            InitializeComponent();
        }

        string Role;
        string Name;

        public QuanLySuaChua(string Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            QlySuaChua f = new QlySuaChua();
            AddToForm(f);
        }

        private void QuanLySuaChua_FormClosing(object sender, FormClosingEventArgs e)
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

        private void AddToForm(Form f)
        {
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.GboxContain.Controls.Clear();
            this.GboxContain.Controls.Add(f);
            f.Show();
        }

        private void thôngTinChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QlySuaChua f = new QlySuaChua(Role);
            AddToForm(f);
        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LichSuSuaChua f = new LichSuSuaChua(Role);
            AddToForm(f);
        }

        private void quayLaijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachChucNang DSCN = new DanhSachChucNang(Role, Name);
            DSCN.Show();
            this.Hide();
        }
    }
}
