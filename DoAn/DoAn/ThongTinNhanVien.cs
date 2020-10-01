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
    public partial class ThongTinNhanVien : Form
    {
        public ThongTinNhanVien()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=QuanLySuaChuaLaptop;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string time = DateTime.Now.ToString("ddd/MM/yyyy");
        string Role;
        int i = 0;

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        public ThongTinNhanVien(string Role) : this()
        {
            this.Role = Role;
        }

        public void hienthi()
        {
            listView4.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from TableNhanVien";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView4.Items.Add((i + 1).ToString());
                listView4.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[5].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[6].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[7].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[8].ToString());
                i++;
            }
            ketnoi.Close();
        }

        public bool CheckUser(string User)
        {
            ketnoi.Open();
            sql = @"Select * from TableNhanVien where (name = N'" + User + @"')";
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
            sql = @"DELETE FROM TableLuongNhanVien, TableNhanVien where(Name = N'" + User + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            //ketnoi.Close();
            //ketnoi.Open();
            //sql = @"DELETE FROM TableLuongNhanVien where(name = N'" + User + @"')";
            //thuchien = new SqlCommand(sql, ketnoi);
            //docdulieu = thuchien.ExecuteReader();
            ketnoi.Close();
        }

        private void listView4_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = false;
            txtPassword.Enabled = false;
            btnSua.Enabled = true;
            btnDelete.Enabled = true;
            txtHoTen.Text = listView4.SelectedItems[0].SubItems[1].Text;
            txtGioiTinh.Text = listView4.SelectedItems[0].SubItems[2].Text;
            txtDoB.Text = listView4.SelectedItems[0].SubItems[3].Text;
            txtDiaChi.Text = listView4.SelectedItems[0].SubItems[4].Text;
            txtSDT.Text = listView4.SelectedItems[0].SubItems[5].Text;
            txtAccount.Text = listView4.SelectedItems[0].SubItems[6].Text;
            txtPassword.Text = listView4.SelectedItems[0].SubItems[7].Text;
            txtDepartment.Text = listView4.SelectedItems[0].SubItems[8].Text;
            txtRole.Text = listView4.SelectedItems[0].SubItems[9].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text != "" && txtGioiTinh.Text != "" && txtDoB.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "" && txtAccount.Text != ""
                                && txtRole.Text != "")
            {
                listView4.Items.Clear();
                if (CheckUser(txtHoTen.Text))
                {
                    ketnoi.Close();
                    ketnoi.Open();
                    sql = @"Insert into TableNhanVien (Name, Sex, DateOfBirth, Address, PhoneNumber, Account, Password, Department, Role, TimeStart) VALUES(N'" + txtHoTen.Text + @"',N'" + txtGioiTinh.Text + @"',N'"
                            + txtDoB.Text + @"', N'" + txtDiaChi.Text + @"', N'" + txtSDT.Text + @"', N'" + txtAccount.Text + @"' , N'" + txtPassword.Text + @"' ,  N'" + txtDepartment.Text + @"' , N'" + txtRole.Text + @"',  N'" + time + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.ExecuteNonQuery();
                    sql = @"Insert into TableLuongNhanVien(Name, Department) VALUES (N'" + txtHoTen.Text + @"', N'" + txtDepartment.Text + @"')";
                                        thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.ExecuteNonQuery();
                    ketnoi.Close();
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại nhân viên này rồi, vui lòng cập nhật hoặc xóa đi !");
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
            listView4.Items.Clear();
            ketnoi.Open();
            sql = @"UPDATE TableNhanVien set Name = N'" + txtHoTen.Text + @"', Sex = N'" + txtGioiTinh.Text + @"', 
                    DateOfBirth = N'" + txtDoB.Text + @"', Address = N'" + txtDiaChi.Text + @"', PhoneNumber = N'" + txtSDT.Text + @"',
                        Account = N'" + txtAccount.Text + @"', Password = N'" + txtPassword.Text + @"', Role = N'" + txtRole.Text + @"',  TimeStart = N'" + txtPassword.Text + @"' Where (Name = N'" + txtHoTen.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
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
                foreach (ListViewItem item in listView4.Items)
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
            btnDelete.Enabled = false;
            btnSua.Enabled = false;
            txtHoTen.Enabled = true;
            txtPassword.Enabled = true;
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            txtDoB.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtAccount.Text = "";
            txtPassword.Text = "";
            txtDepartment.Text = "";
            txtRole.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteUser(txtHoTen.Text);
            hienthi();
        }
    }
}
