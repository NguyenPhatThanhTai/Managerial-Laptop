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
        public DanhSachChucNang()
        {
            InitializeComponent();
        }

        public DanhSachChucNang(string role) : this()
        {
            Role = role;
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
        }

        private void btnChucNangSuaChua_Click(object sender, EventArgs e)
        {
            QuanLySuaChua suachua = new QuanLySuaChua(Role);
            suachua.Show();
            this.Hide();
        }

        private void btnChucNangLinhKien_Click(object sender, EventArgs e)
        {
            QuanLyLinhKien linhkien = new QuanLyLinhKien(Role);
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
            QuanLyNhanVien QLNV = new QuanLyNhanVien(Role);
            QLNV.Show();
            this.Hide();
        }
    }
}
