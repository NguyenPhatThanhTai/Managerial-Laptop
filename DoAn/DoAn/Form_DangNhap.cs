﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace DoAn
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        Data_NV dnv;
        private void DangNhap_Load(object sender, EventArgs e)
        {
            // Cần sửa
            timer2.Start();
            dnv = new Data_NV();
            pbCheck.Hide();
            lbCheck.Hide();
            if (Properties.Settings.Default.userName != "")
            {
                txtAccount.Text = Properties.Settings.Default.userName;
                txtPassword.Text = Properties.Settings.Default.passUser;
                this.btnDangNhap_Click(null, null);
            }
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string Account = txtAccount.Text;
            string Password = txtPassword.Text;
            if (Account != "" && Password != "")
            {
                pbCheck.Show();
                lbCheck.Show();
                await Task.Delay(2000);
                if (dnv.DangNhap(Account, Password))
                {
                    DanhSachChucNang DSCN = new DanhSachChucNang(int.Parse(dnv.CheckRole(Account)), dnv.GetUserName(Account));
                    DSCN.Show();
                    this.Hide();
                    if (Ckb_SaveMyPass.Checked)
                    {
                        Properties.Settings.Default.userName = txtAccount.Text;
                        Properties.Settings.Default.passUser = txtPassword.Text;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    pbCheck.Hide();
                    lbCheck.Hide();
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

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Cần sửa
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 5.0)
            {
                this.Opacity += 0.75;
            }
        }
    }
}
