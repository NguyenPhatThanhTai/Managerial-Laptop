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

        string Role;

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            ThongTinNhanVien f = new ThongTinNhanVien();
            AddToForm(f);
        }

        public QuanLyNhanVien(string Role) : this()
        {
            this.Role = Role;
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
            ThongTinNhanVien f = new ThongTinNhanVien(Role);
            AddToForm(f);
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachChucNang DSCN = new DanhSachChucNang(Role);
            DSCN.Show();
            this.Hide();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuongNhanVien f = new LuongNhanVien(Role);
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
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show();
                this.Hide();
            }
        }

        private void TroGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TroGiup f = new TroGiup();
            AddToForm(f);
        }
    }
}
