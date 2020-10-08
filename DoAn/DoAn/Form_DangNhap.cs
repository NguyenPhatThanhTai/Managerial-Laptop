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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=QuanLySuaChuaLaptop;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;


        private void DangNhap_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
        }
        public Boolean Login(string Account, string password)
        {
            ketnoi.Open();
            sql = @"select * from TableNhanVien where Account = '"+Account+"' and Password = '"+password+"'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string CheckRole(string Account)
        {
            ketnoi.Close();
            ketnoi.Open();
            sql = @"select Role from TableNhanVien where Account = '" + Account + "'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read() == true)
            {
                return docdulieu[0].ToString();
            }
            else
            {
                return null;
            }
        }

        public string GetUserName(string Account)
        {
            ketnoi.Close();
            ketnoi.Open();
            sql = @"select Name from TableNhanVien where Account = '" + Account + "'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read() == true)
            {
                return docdulieu[0].ToString();
            }
            else
            {
                return null;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ketnoi.Close();
            string Account = txtAccount.Text;
            string Password = txtPassword.Text;
            if(Account != "" && Password != "")
            {
                if (Login(Account, Password))
                {
                    DanhSachChucNang DSCN = new DanhSachChucNang(int.Parse(CheckRole(Account)), GetUserName(Account));
                    DSCN.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu vui lòng kiểm tra lại !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn thoát à?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(1);
            }
        }
    }
}
