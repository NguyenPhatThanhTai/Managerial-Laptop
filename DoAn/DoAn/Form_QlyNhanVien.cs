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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        int Role;
        string Name;

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            QlyThongTinNhanVien f = new QlyThongTinNhanVien(Role, Name);
            AddToForm(f);
        }

        public QuanLyNhanVien(int Role, string Name) : this()
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

        private void thôngTinChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QlyThongTinNhanVien f = new QlyThongTinNhanVien(Role, Name);
            AddToForm(f);
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachChucNang DSCN = new DanhSachChucNang(Role, Name);
            DSCN.Show();
            this.Hide();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QlyLuongNhanVien f = new QlyLuongNhanVien(Role, Name);
            AddToForm(f);
        }

        private void QuanLyNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn thoát à?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DanhSachChucNang dscn = new DanhSachChucNang(Role, Name);
                dscn.Show();
                this.Hide();
            }
        }

        private void TroGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QlyTroGiup f = new QlyTroGiup();
            AddToForm(f);
        }

        private void tàiKhoảnNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QlyTaiKhoanNhanVien f = new QlyTaiKhoanNhanVien(Role, Name);
            AddToForm(f);
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
