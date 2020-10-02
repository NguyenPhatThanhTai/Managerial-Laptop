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

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=QuanLySuaChuaLaptop;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string time = DateTime.Now.ToString();
        string Role;
        int i = 0;


        public QuanLySuaChua(string Role) : this()
        {
            this.Role = Role;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from TableSuaChua";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add((i + 1).ToString());
                listView1.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[5].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[6].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[7].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[8].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = false;
            txtThoiGian.Enabled = false;
            btnHoanTat.Enabled = true;
            btnSua.Enabled = true;
            txtHoTen.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtEmail.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtSDT.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtTenMay.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txtChiTiet.Text = listView1.SelectedItems[0].SubItems[5].Text;
            txtTinhTrang.Text = listView1.SelectedItems[0].SubItems[6].Text;
            txtGhiChu.Text = listView1.SelectedItems[0].SubItems[7].Text;
            txtSoTien.Text = listView1.SelectedItems[0].SubItems[8].Text;
            txtThoiGian.Text = listView1.SelectedItems[0].SubItems[9].Text;
        }

        public bool CheckUser(string User)
        {
            ketnoi.Open();
            sql = @"Select * from TableSuaChua where (name = N'"+ User+ @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                return false;
            }
                return true;
        }

        public void deleteUser(string User)
        {
            ketnoi.Open();
            sql = @"Delete from TableSuaChua where (name = N'" + User + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtHoTen.Text != "" && txtEmail.Text != "" && txtSDT.Text != "" && txtTenMay.Text != "" && txtChiTiet.Text != "" && txtTinhTrang.Text != ""
                                && txtGhiChu.Text != "" && txtSoTien.Text != "")
            {
                listView1.Items.Clear();
                if (CheckUser(txtHoTen.Text))
                {
                    ketnoi.Close();
                    ketnoi.Open();
                    sql = @"Insert into TableSuaChua (Name, Email, SDT, Kind, DetailFix, Status, Noti, Money, TimeStart) VALUES(N'" + txtHoTen.Text + @"',N'" + txtEmail.Text + @"',N'"
                            + txtSDT.Text + @"', N'" + txtTenMay.Text + @"', N'" + txtChiTiet.Text + @"', N'" + txtTinhTrang.Text + @"', N'" + txtGhiChu.Text + @"', N'" + txtSoTien.Text + @"', N'" + time + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.ExecuteNonQuery();
                    ketnoi.Close();
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại khách hàng này rồi, vui lòng cập nhật hoặc xóa đi !");
                    ketnoi.Close();
                    hienthi();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"UPDATE TableSuaChua set Name = N'" +txtHoTen.Text + @"', Email = N'" + txtEmail.Text + @"', 
                    SDT = N'"+ txtSDT.Text + @"', Kind = N'" + txtTenMay.Text + @"', DetailFix = N'" + txtChiTiet.Text + @"',
                        Status = N'" + txtTinhTrang.Text + @"', Noti = N'" + txtGhiChu.Text + @"', Money = N'" + txtSoTien.Text + @"',  TimeStart = N'" + txtThoiGian.Text + @"' Where (Name = N'" + txtHoTen.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            sql = @"Insert into History (Name, Email, SDT, Kind, DetailFix, Status, Noti, Money, TimeEnd) VALUES(N'" + txtHoTen.Text + @"',N'" + txtEmail.Text + @"',N'"
                    + txtSDT.Text + @"', N'" + txtTenMay.Text + @"', N'" + txtChiTiet.Text + @"', N'" + txtTinhTrang.Text + @"', N'" + txtGhiChu.Text + @"', N'" + txtSoTien.Text + @"', N'" + time + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
            deleteUser(txtHoTen.Text);
            ketnoi.Close();
            hienthi();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            LichSuSuaChua f2 = new LichSuSuaChua();
            f2.Show();
        }

       // private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
          //  foreach (ListViewItem item in listView1.Items)
            //    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
              //      if (subitem.Text.Equals(txtSearch.Text, StringComparison.OrdinalIgnoreCase))
                //    {
                  //      item.BackColor = SystemColors.Highlight;
                    //    item.ForeColor = SystemColors.HighlightText;
                   // }
        //}

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                hienthi();
            }
            else
            {
                foreach (ListViewItem item in listView1.Items)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtTenMay.Text = "";
            txtChiTiet.Text = "";
            txtTinhTrang.Text = "";
            txtGhiChu.Text = "";
            txtSoTien.Text = "";
            txtThoiGian.Text = "";
        }

        private void btnTurnBack_Click(object sender, EventArgs e)
        {
            DanhSachChucNang DSCN = new DanhSachChucNang(Role);
            DSCN.Show();
            this.Close();
        }

        private void QuanLySuaChua_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn thoát à?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
