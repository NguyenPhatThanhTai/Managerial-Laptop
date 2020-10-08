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
using System.Net.Mail;
using System.Net;

namespace DoAn
{
    public partial class QlyThongTinKhachHang : Form
    {
        public QlyThongTinKhachHang()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string time = DateTime.Now.ToString();
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");
        int Role;
        string Sex;
        string Name;
        int i = 0;

        public QlyThongTinKhachHang(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }

        private void QlySuaChua_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from Inf_Customers";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                if (docdulieu[2].ToString() == "1")
                {
                    Sex = "Nam";
                }
                else if (docdulieu[2].ToString() == "2")
                {
                    Sex = "Nữ";
                }
                else
                {
                    Sex = "Khác";
                }
                listView1.Items.Add((i + 1).ToString());
                listView1.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(Sex);
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[5].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[6].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if(txtMaKhachHang.Text != "")
            {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn dọn sạch các dữ liệu hiện tại trên ô nhập không", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        txtMaKhachHang.Enabled = false;
                        txtThoiGian.Enabled = false;
                        btnSua.Enabled = true;
                        btnDelete.Enabled = true;
                        btnThem.Enabled = false;
                        txtMaKhachHang.Text = listView1.SelectedItems[0].SubItems[1].Text;
                        txtHoTen.Text = listView1.SelectedItems[0].SubItems[2].Text;
                        txtGioiTinh.Text = listView1.SelectedItems[0].SubItems[3].Text;
                        txtBirth.Text = listView1.SelectedItems[0].SubItems[4].Text;
                        txtEmail.Text = listView1.SelectedItems[0].SubItems[5].Text;
                        txtSDT.Text = listView1.SelectedItems[0].SubItems[6].Text;
                        txtThoiGian.Text = listView1.SelectedItems[0].SubItems[7].Text;
                }
                else
                {
                    txtMaKhachHang.Enabled = false;
                    txtThoiGian.Enabled = false;
                    btnSua.Enabled = true;
                    btnDelete.Enabled = true;
                    btnThem.Enabled = false;
                    txtMaKhachHang.Text = listView1.SelectedItems[0].SubItems[1].Text;
                    txtHoTen.Text = listView1.SelectedItems[0].SubItems[2].Text;
                    txtGioiTinh.Text = listView1.SelectedItems[0].SubItems[3].Text;
                    txtBirth.Text = listView1.SelectedItems[0].SubItems[4].Text;
                    txtEmail.Text = listView1.SelectedItems[0].SubItems[5].Text;
                    txtSDT.Text = listView1.SelectedItems[0].SubItems[6].Text;
                    txtThoiGian.Text = listView1.SelectedItems[0].SubItems[7].Text;
                }
            }
            else
            {
                txtMaKhachHang.Enabled = false;
                txtThoiGian.Enabled = false;
                btnSua.Enabled = true;
                btnDelete.Enabled = true;
                btnThem.Enabled = false;
                txtMaKhachHang.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtHoTen.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtGioiTinh.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txtBirth.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txtEmail.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txtSDT.Text = listView1.SelectedItems[0].SubItems[6].Text;
                txtThoiGian.Text = listView1.SelectedItems[0].SubItems[7].Text;
            }
        }

        public bool CheckUser(string id)
        {
            ketnoi.Open();
            sql = @"Select * from Inf_Customers where (Customer_Id = N'" + id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                return false;
            }
            return true;
        }

        public void deleteUser(string id)
        {
            ketnoi.Open();
            sql = @"Delete from Inf_Customers where (name = N'" + id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text != "" && txtEmail.Text != "" && txtSDT.Text != "" && txtGioiTinh.Text != "" && txtBirth.Text != "" && txtEmail.Text != ""
                                && txtSDT.Text != "") 
            {
                DialogResult dialog = MessageBox.Show("Xác nhận thêm khách hàng " + txtHoTen.Text + " ?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    if (txtGioiTinh.Text == "Nam")
                    {
                        Sex = "1";
                    }
                    else
                    {
                        Sex = "2";
                    }
                    listView1.Items.Clear();
                    if (CheckUser(txtHoTen.Text))
                    {
                        ketnoi.Close();
                        ketnoi.Open();
                        sql = @"Insert into Inf_Customers (Customer_Id, Customer_Name, Customer_Sex, Customer_Birth, Customer_Email, Customer_Phone, Customer_TimeAdd)
                                                VALUES(N'KH" + day + "" + Min + "" + sec + "" + @"',N'" + txtHoTen.Text + @"',N'" + Sex + @"', N'" + txtBirth.Value.ToString("yyyy/MM/dd") + "',N'" + txtEmail.Text + @"',N'"
                                + txtSDT.Text + @"', N'" + time + @"')";
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        sql = @"Insert into Inf_Repair (Repair_Id, Customer_Id, Laptop_Name, Laptop_Status, Staff_Id)
                                                    VALUES(N'RP" + day + "" + Min + "" + sec + "" + @"',N'KH" + day + "" + Min + "" + sec + "" + @"','Chưa biết','Chưa biết', 'NV096784')";
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        sql = @"Insert into Detail_Inf_Repair (Repair_Id, LK_Id, Repair_Reason, Repair_Note, Repain_Appointment, Repair_Money)
                                                    VALUES(N'RP" + day + "" + Min + "" + sec + "" + @"','LK"+ i +"', 'Chưa biết', 'Chưa biết', 'Chưa biết', 'Chưa biết')";
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        ketnoi.Close();
                        hienthi();
                        time = DateTime.Now.ToString();
                        day = DateTime.Now.ToString("dd");
                        Min = DateTime.Now.ToString("mm");
                        sec = DateTime.Now.ToString("ss");
                        i++;
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại khách hàng này rồi, vui lòng cập nhật hoặc xóa đi !");
                        ketnoi.Close();
                        hienthi();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnDelete.Enabled = false;
            btnThem.Enabled = true;
            listView1.Items.Clear();
            ketnoi.Open();
            if (txtGioiTinh.Text == "Nam")
            {
                Sex = "1";
            }
            else
            {
                Sex = "2";
            }
            sql = @"UPDATE Inf_Customers set Customer_Name = N'" + txtHoTen.Text + @"', Customer_Sex = N'" + Sex + @"', 
                    Customer_Birth = '" + txtBirth.Value.ToString("yyyy/MM/dd") + "', Customer_Email = N'" + txtEmail.Text + @"', Customer_Phone = N'" + txtSDT.Text + @"' Where (Customer_Id = N'" + txtMaKhachHang.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
            clear();
        }

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
            btnSua.Enabled = false;
            btnDelete.Enabled = false;
            btnThem.Enabled = true;
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtGioiTinh.Text = "Nam";
            txtMaKhachHang.Text = "";
            txtThoiGian.Text = "";
        }

        private void QlySuaChua_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa khách hàng " + txtHoTen.Text + " không !", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                string repair = (String)txtMaKhachHang.Text;
                string repairID = repair.Substring(2);
                ketnoi.Open();
                sql = @"DELETE FROM Detail_Inf_Repair where(Repair_Id = N'RP" + repairID + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                sql = @"DELETE FROM Inf_Repair where(Customer_Id = N'" + txtMaKhachHang.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                sql = @"DELETE FROM Inf_Customers where(Customer_Id = N'" + txtMaKhachHang.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                docdulieu = thuchien.ExecuteReader();
                ketnoi.Close();
                clear();
                hienthi();
                btnThem.Enabled = true;
            }
            else
            {
                ketnoi.Close();
                hienthi();
            }
        }

        private void clear()
        {
            txtHoTen.Text = "";
            txtGioiTinh.Text = "Nam";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtMaKhachHang.Text = "";
            txtThoiGian.Text = "";
        }
    }
}
