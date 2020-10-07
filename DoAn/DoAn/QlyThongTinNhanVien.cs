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
    public partial class QlyThongTinNhanVien : Form
    {
        public QlyThongTinNhanVien()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string time = DateTime.Now.ToString("ddd/MM/yyyy");
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");
        int Role;
        string Name;
        string PhongBan;
        string Sex;
        int i = 0;

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        public QlyThongTinNhanVien(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }

        public void hienthi()
        {
            listView4.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from Inf_Staff";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                if(docdulieu[2].ToString() == "1")
                {
                    Sex = "Nam";
                }
                else if(docdulieu[2].ToString() == "2")
                {
                    Sex = "Nữ";
                }
                else
                {
                    Sex = "Khác";
                }

                if(docdulieu[6].ToString() == "1")
                {
                    PhongBan = "Quản lý";       
                }
                else if(docdulieu[6].ToString() == "2")
                {
                    PhongBan = "Kỹ Thuật";
                }
                else
                {
                    PhongBan = "Kế Toán";
                }
                listView4.Items.Add((i + 1).ToString());
                listView4.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView4.Items[i].SubItems.Add(Sex.ToString());
                listView4.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView4.Items[i].SubItems.Add(docdulieu[5].ToString());
                listView4.Items[i].SubItems.Add(PhongBan.ToString());
                listView4.Items[i].SubItems.Add(docdulieu[7].ToString());
                i++;
            }
            ketnoi.Close();
        }

        public bool CheckUser(string User)
        {
            ketnoi.Open();
            sql = @"Select * from Inf_Staff where (Staff_Name = N'" + User + @"')";
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
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa nhân viên " + txtHoTen.Text + " không !", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                ketnoi.Open();
                sql = @"DELETE FROM Account_Staff where(Staff_Id = N'" + User + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                sql = @"DELETE FROM Inf_Staff where(Staff_Id = N'" + User + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                docdulieu = thuchien.ExecuteReader();
                ketnoi.Close();
            }
            else
            {
                ketnoi.Close();
                hienthi();
            }
        }

        private void listView4_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnDelete.Enabled = true;
            if(listView4.SelectedItems[0].SubItems[2].Text == "Nguyễn Phát Thành Tài")
            {
                btnDelete.Enabled = false;
            }
            txtMaNv.Text = listView4.SelectedItems[0].SubItems[1].Text;
            txtHoTen.Text = listView4.SelectedItems[0].SubItems[2].Text;
            txtGioiTinh.Text = listView4.SelectedItems[0].SubItems[3].Text;
            txtDoB.Text = listView4.SelectedItems[0].SubItems[4].Text;
            txtDiaChi.Text = listView4.SelectedItems[0].SubItems[5].Text;
            txtSDT.Text = listView4.SelectedItems[0].SubItems[6].Text;
            txtDepartment.Text = listView4.SelectedItems[0].SubItems[7].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text != "" && txtGioiTinh.Text != "" && txtDoB.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "")
            {
                listView4.Items.Clear();
                if (CheckUser(txtHoTen.Text))
                {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn thêm nhân viên " + txtHoTen.Text + " không !", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        if(txtGioiTinh.Text == "Nam")
                        {
                            Sex = "1";
                        }
                        else
                        {
                            Sex = "2";
                        }
                        if(txtDepartment.Text == "Quản Lý")
                        {
                            PhongBan = "1";
                        }
                        else if(txtDepartment.Text == "Kỹ Thuật")
                        {
                            PhongBan = "2";
                        }
                        else
                        {
                            PhongBan = "3";
                        }
                        ketnoi.Close();
                        ketnoi.Open();
                        sql = @"Insert into Inf_Staff (Staff_Id, Staff_Name, Staff_Sex, Staff_Birth, Staff_Address, Staff_Phone, Staff_Deparment, Staff_TimeAdd) VALUES(N'"+day+""+Min+""+sec+""+ @"',N'" + txtHoTen.Text + @"',N'"
                                + Sex + @"', N'" + txtDoB.Text + @"', N'" + txtDiaChi.Text + @"', N'" + txtSDT.Text + @"' , N'" + PhongBan + @"' ,  N'" + time + @"')";
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        sql = @"Insert into Account_Staff(Staff_Id, Staff_Account, Staff_Password, Staff_Role) VALUES (N'" + day + "" + Min + "" + sec + "" + @"', N'" + day + "" + Min + "" + sec + "" + @"', 1, 2)";
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        sql = @"Insert into Salary_Staff(Staff_Id, Staff_Default_Salary, Staff_Salary_Per_Hour, Staff_OT, Staff_Reward) VALUES (N'" + day + "" + Min + "" + sec + "" + @"',0, 0, 0, 0)";
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        ketnoi.Close();
                        hienthi();
                    }
                    else
                    {
                        ketnoi.Close();
                        hienthi();
                    }
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
            if (txtGioiTinh.Text == "Nam")
            {
                Sex = "1";
            }
            else
            {
                Sex = "2";
            }
            if (txtDepartment.Text == "Quản Lý")
            {
                PhongBan = "1";
            }
            else if (txtDepartment.Text == "Kỹ Thuật")
            {
                PhongBan = "2";
            }
            else
            {
                PhongBan = "3";
            }
            sql = @"UPDATE Inf_Staff set Staff_Name = N'" + txtHoTen.Text + @"', Staff_Sex = N'" + Sex + @"', 
                    Staff_Birth = N'" + txtDoB.Text + @"', Staff_Address = N'" + txtDiaChi.Text + @"', Staff_Phone = N'" + txtSDT.Text + @"', Staff_Deparment = N'" + PhongBan + @"' Where (Staff_Id = N'" + txtMaNv.Text + @"')";
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
            txtMaNv.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            txtDoB.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtDepartment.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteUser(txtMaNv.Text);
            hienthi();
        }

        private void ThongTinNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
