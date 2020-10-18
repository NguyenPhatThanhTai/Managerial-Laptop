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

        int Role;
        string Name;

        public QuanLySuaChua(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            QlyThongTinKhachHang f = new QlyThongTinKhachHang();
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
                DanhSachChucNang dscn = new DanhSachChucNang();
                dscn.Show();
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
            QlyThongTinKhachHang f = new QlyThongTinKhachHang(Role, Name);
            AddToForm(f);
        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Qly_SuaChua f = new Qly_SuaChua(Role, Name);
            AddToForm(f);
        }

        private void quayLaijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachChucNang DSCN = new DanhSachChucNang(Role, Name);
            DSCN.Show();
            this.Hide();
        }

        private void lịchSửSửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QlyLichSuSuaChua f = new QlyLichSuSuaChua();
            AddToForm(f);
        }
    }
}
