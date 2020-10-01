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
    public partial class LuongNhanVien : Form
    {
        public LuongNhanVien()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=QuanLySuaChuaLaptop;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string time = DateTime.Now.ToString();
        string Role;
        int i = 0;

        public LuongNhanVien(string Role) : this()
        {
            this.Role = Role;
        }

        private void LuongNhanVien_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        public void hienthi()
        {
            lsvLuong.Items.Clear();
            ketnoi.Close();
            ketnoi.Open();
            sql = @"Select * from TableLuongNhanVien";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lsvLuong.Items.Add((i + 1).ToString());
                lsvLuong.Items[i].SubItems.Add(docdulieu[0].ToString());
                lsvLuong.Items[i].SubItems.Add(docdulieu[1].ToString());
                lsvLuong.Items[i].SubItems.Add(docdulieu[2].ToString());
                lsvLuong.Items[i].SubItems.Add(docdulieu[3].ToString());
                lsvLuong.Items[i].SubItems.Add(docdulieu[4].ToString());
                lsvLuong.Items[i].SubItems.Add(docdulieu[5].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void lsvLuong_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = lsvLuong.SelectedItems[0].SubItems[1].Text;
            txtPhongBan.Text = lsvLuong.SelectedItems[0].SubItems[2].Text;
            txtLuongCoBan.Text = lsvLuong.SelectedItems[0].SubItems[3].Text;
            txtLuongTheoGio.Text = lsvLuong.SelectedItems[0].SubItems[4].Text;
            txtTienThuong.Text = lsvLuong.SelectedItems[0].SubItems[5].Text;
            txtLamNgoaiGio.Text = lsvLuong.SelectedItems[0].SubItems[6].Text;
            if (lsvLuong.SelectedItems[0].SubItems[3].Text == "")
            {
                MessageBox.Show("Nhân viên này vẫn chưa cài đặt các thông số lương !");
                txtTongLuong.Text = "";
            }
            else
            {
                int TienCoBan = int.Parse(lsvLuong.SelectedItems[0].SubItems[3].Text);
                int TienThuong = int.Parse(lsvLuong.SelectedItems[0].SubItems[4].Text);
                int LamNgoaiGio = int.Parse(lsvLuong.SelectedItems[0].SubItems[5].Text);
                txtTongLuong.Text = (TienCoBan + TienThuong + LamNgoaiGio).ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            sql = @"UPDATE TableLuongNhanVien set SalaryDefault = N'" + txtLuongCoBan.Text + @"', SalaryPerHours = N'" + txtLuongTheoGio.Text + @"', 
                    Reward = N'" + txtTienThuong.Text + @"', OverTime = N'" + txtLamNgoaiGio.Text + @"' Where (Name = N'" + txtHoTen.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            hienthi();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtPhongBan.Text = "";
            txtLuongCoBan.Text = "";
            txtLuongTheoGio.Text = "";
            txtTienThuong.Text = "";
            txtLamNgoaiGio.Text = "";
            txtTongLuong.Text = "";
            hienthi();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                hienthi();
            }
            else
            {
                foreach (ListViewItem item in lsvLuong.Items)
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
    }
}
