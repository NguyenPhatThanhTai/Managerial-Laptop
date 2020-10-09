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

namespace DoAn
{
    public partial class QlyTaiKhoanNhanVien : Form
    {
        public QlyTaiKhoanNhanVien()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        int Role;
        int quyen;
        string Name;
        string Quyen;

        private void QlyTaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        public QlyTaiKhoanNhanVien(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }

        public void hienthi()
        {
            lsvAccount.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from Account_Staff";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                if(docdulieu[3].ToString() == "1")
                {
                    Quyen = "Admin";
                }
                else
                {
                    Quyen = "Nhân Viên";
                }
                lsvAccount.Items.Add((i + 1).ToString());
                lsvAccount.Items[i].SubItems.Add(docdulieu[0].ToString());
                lsvAccount.Items[i].SubItems.Add(docdulieu[1].ToString());
                lsvAccount.Items[i].SubItems.Add(docdulieu[2].ToString());
                lsvAccount.Items[i].SubItems.Add(Quyen);
                i++;
            }
            ketnoi.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                hienthi();
            }
            else
            {
                foreach (ListViewItem item in lsvAccount.Items)
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                        if (subitem.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            item.BackColor = SystemColors.Highlight;
                            item.ForeColor = SystemColors.HighlightText;
                            break;
                        }
            }
        }

        private void btnFeresh_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void QlyTaiKhoanNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            if (txtRole.Text == "Admin")
            {
                quyen = 1;
            }
            else
            {
                quyen = 2;
            }
            sql = @"UPDATE Account_Staff set Staff_Password = N'" + txtPassword.Text + @"', Staff_Role = N'" + quyen + @"' Where (Staff_Id = N'" + txtMaNv.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void lsvAccount_Click(object sender, EventArgs e)
        {
            lsvAccount.Enabled = false;
            btnClear.Enabled = true;
            btnSua.Enabled = true;
            txtRole.Enabled = true;
            txtPassword.Enabled = true;
            txtMaNv.Text = lsvAccount.SelectedItems[0].SubItems[1].Text;
            txtAccount.Text = lsvAccount.SelectedItems[0].SubItems[2].Text;
            txtPassword.Text = lsvAccount.SelectedItems[0].SubItems[3].Text;
            txtRole.Text = lsvAccount.SelectedItems[0].SubItems[4].Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lsvAccount.Enabled = true;
            ClearAll(false);
            hienthi();
        }

        private void ClearAll(bool Bool)
        {
            btnClear.Enabled = Bool;
            btnSua.Enabled = Bool;
            txtRole.Enabled = Bool;
            txtPassword.Enabled = Bool;
            txtAccount.Enabled = Bool;
            txtMaNv.Text = "";
            txtAccount.Text = "";
            txtPassword.Text = "";
            txtRole.Text = "";
        }
    }
}
