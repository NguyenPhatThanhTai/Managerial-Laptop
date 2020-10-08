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
    public partial class QlyLuongNhanVien : Form
    {
        public QlyLuongNhanVien()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string time = DateTime.Now.ToString();
        int Role;
        string name;
        int i = 0;

        public QlyLuongNhanVien(int Role, string name) : this()
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
            sql = @"Select * from Salary_Staff";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lsvLuong.Items.Add((i + 1).ToString());
                lsvLuong.Items[i].SubItems.Add(docdulieu[0].ToString());
                lsvLuong.Items[i].SubItems.Add(string.Format("{0:#,###}", docdulieu[1].ToString()));   
                lsvLuong.Items[i].SubItems.Add(string.Format("{0:#,###}", docdulieu[2].ToString()));
                lsvLuong.Items[i].SubItems.Add(string.Format("{0:#,###}", docdulieu[3].ToString()));
                lsvLuong.Items[i].SubItems.Add(string.Format("{0:#,###}", docdulieu[4].ToString()));
                i++;
            }
            ketnoi.Close();
        }

        private void lsvLuong_Click(object sender, EventArgs e)
        {
            ClearAll(true);
            txtMaNV.Text = lsvLuong.SelectedItems[0].SubItems[1].Text;
            txtLuongCoBan.Text = lsvLuong.SelectedItems[0].SubItems[2].Text;
            txtLuongTheoGio.Text = lsvLuong.SelectedItems[0].SubItems[3].Text;
            txtLamNgoaiGio.Text = lsvLuong.SelectedItems[0].SubItems[4].Text;
            txtTienThuong.Text = lsvLuong.SelectedItems[0].SubItems[5].Text;
            if (lsvLuong.SelectedItems[0].SubItems[3].Text == "" && lsvLuong.SelectedItems[0].SubItems[4].Text == "" && lsvLuong.SelectedItems[0].SubItems[5].Text == "" &&
                        lsvLuong.SelectedItems[0].SubItems[6].Text == "")
            {
                MessageBox.Show("Nhân viên này vẫn chưa cài đặt các thông số lương !");
                txtTongLuong.Text = "";
            }
            else
            {
                int TienCoBan = int.Parse(lsvLuong.SelectedItems[0].SubItems[2].Text);
                int TienThuong = int.Parse(lsvLuong.SelectedItems[0].SubItems[4].Text);
                int LamNgoaiGio = int.Parse(lsvLuong.SelectedItems[0].SubItems[5].Text);
                txtTongLuong.Text = string.Format("{0:#,###}VND", ((TienCoBan + TienThuong + LamNgoaiGio).ToString()));
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll(false);
            txtMaNV.Text = "";
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

        private void LuongNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            sql = @"UPDATE Salary_Staff set Staff_Default_Salary = N'" + txtLuongCoBan.Text + @"', Staff_Salary_Per_Hour = N'" + txtLuongTheoGio.Text + @"', Staff_OT = N'" + txtLamNgoaiGio.Text + @"', Staff_Reward = N'" + txtTienThuong.Text + @"' Where (Staff_Id = N'" + txtMaNV.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void ClearAll(bool Bool)
        {
            btnUpdate.Enabled = Bool;
            btnClear.Enabled = Bool;
            txtLuongCoBan.Enabled = Bool;
            txtLuongTheoGio.Enabled = Bool;
            txtTienThuong.Enabled = Bool;
            txtLamNgoaiGio.Enabled = Bool;
        }
    }
}
