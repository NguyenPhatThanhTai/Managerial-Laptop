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
    public partial class QuanLyLinhKien : Form
    {
        public QuanLyLinhKien()
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


        public QuanLyLinhKien(string Role) : this()
        {
            this.Role = Role;
        }
        public void hienthi(string nameLK)
        {
            //Lenovo
            //Acer
            //Apple
            //Asus
            //Msi
            //Khác
            listView3.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from "+ nameLK + @"LK";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView3.Items.Add((i + 1).ToString());
                listView3.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[4].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void QuanLyLinhKien_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            txtLocHang.Text = "Acer";
        }

        private void txtLocHang_TextChanged(object sender, EventArgs e)
        {
            hienthi(txtLocHang.Text);
        }

        private void listView3_Click(object sender, EventArgs e)
        {
            txtTenLinhKien.Enabled = false;
            txtNgayThemLinhKien.Enabled = false;
            btnSua.Enabled = true;
            txtTenLinhKien.Text = listView3.SelectedItems[0].SubItems[1].Text;
            txtSoLuong.Text = listView3.SelectedItems[0].SubItems[2].Text;
            txtNhaSanXuat.Text = listView3.SelectedItems[0].SubItems[3].Text;
            txtNgayThemLinhKien.Text = listView3.SelectedItems[0].SubItems[4].Text;
            txtGhiChu.Text = listView3.SelectedItems[0].SubItems[5].Text;
        }

        public bool CheckLK(string LK, string nameLK)
        {
            ketnoi.Open();
            sql = @"Select * from " + nameLK + @"LK where (NameLK = N'" + LK + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLinhKien.Text != "" && txtSoLuong.Text != "" && txtNhaSanXuat.Text != "" && txtGhiChu.Text != "")
            {
                listView3.Items.Clear();
                if (CheckLK(txtTenLinhKien.Text, txtNhaSanXuat.Text))
                {
                    ketnoi.Close();
                    ketnoi.Open();
                    sql = @"Insert into "+txtNhaSanXuat.Text+ @"LK (NameLK, Number, Producer, TimeStart, Noti) VALUES(N'" + txtTenLinhKien.Text + @"',N'" + txtSoLuong.Text + @"',N'"
                            + txtNhaSanXuat.Text + @"', N'" + time + @"', N'" + txtGhiChu.Text + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.ExecuteNonQuery();
                    ketnoi.Close();
                    hienthi(txtNhaSanXuat.Text);
                }
                else
                {
                    MessageBox.Show("Đã tồn tại linh kiện này rồi, vui lòng cập nhật !");
                    ketnoi.Close();
                    hienthi(txtLocHang.Text);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenLinhKien.Enabled = true;
            txtTenLinhKien.Text = "";
            txtSoLuong.Text = "";
            txtNhaSanXuat.Text = "";
            txtNgayThemLinhKien.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnTurnBack_Click(object sender, EventArgs e)
        {
            DanhSachChucNang DSCN = new DanhSachChucNang(Role);
            DSCN.Show();
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            hienthi(txtLocHang.Text);
            if (txtSearch.Text == "")
            {
                hienthi(txtLocHang.Text);
            }
            else
            {
                foreach (ListViewItem item in listView3.Items)
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
            hienthi(txtLocHang.Text);
        }

        private void QuanLyLinhKien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn thoát à?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
