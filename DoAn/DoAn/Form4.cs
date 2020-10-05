using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class DanhSachChucNang : Form
    {
        string Role;
        string Name;
        public DanhSachChucNang()
        {
            InitializeComponent();
        }

        public DanhSachChucNang(string role, string name) : this()
        {
            Role = role;
            Name = name;
        }

        private void DanhSachChucNang_Load(object sender, EventArgs e)
        {
            if (Role == "Admin")
            {
                btnChucNangQuanLyNV.Enabled = true;
            }
            else
            {
                btnChucNangQuanLyNV.Enabled = false;
            }
            HelloNV.Text = "Xin chào " + Name;
        }

        private void btnChucNangSuaChua_Click(object sender, EventArgs e)
        {
            QuanLySuaChua suachua = new QuanLySuaChua(Role, Name);
            suachua.Show();
            this.Hide();
        }

        private void btnChucNangLinhKien_Click(object sender, EventArgs e)
        {
            QuanLyLinhKien linhkien = new QuanLyLinhKien(Role, Name);
            linhkien.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangnhap = new DangNhap();
            dangnhap.Show();
        }

        private void btnChucNangQuanLyNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien QLNV = new QuanLyNhanVien(Role, Name);
            QLNV.Show();
            this.Hide();
        }

        private void DanhSachChucNang_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
