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
    public partial class Qly_SuaChua : Form
    {
        public Qly_SuaChua()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        string Name;
        string time = DateTime.Now.ToString("yyyy/MM/dd");
        int Role;

        public Qly_SuaChua(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        public void hienthi()
        {
            ketnoi.Close();
            listView2.Items.Clear();
            ketnoi.Open();
            sql = @"Select Inf_Repair.Repair_Id, Inf_Customers.Customer_Name, Inf_Repair.Laptop_Name, Inf_Repair.Laptop_Status, Inf_repair.Staff_Id, Detail_Inf_Repair.Repair_Reason, Detail_Inf_Repair.Repair_Note, Detail_Inf_Repair.Repair_Appointment, Detail_Inf_Repair.Repair_Money  
                        from Inf_Customers 
                                inner join Inf_Repair
                                        on Inf_Customers.Customer_Id = Inf_Repair.Customer_Id
                                inner join Detail_Inf_Repair
                                        on Inf_Repair.Repair_Id = Detail_Inf_Repair.Repair_Id";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView2.Items.Add((i + 1).ToString());
                listView2.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[5].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[6].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[7].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[8].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            btnNhanDon.Enabled = true;
            txtMaSuaChua.Text = listView2.SelectedItems[0].SubItems[1].Text;
            txtTenKhachHang.Text = listView2.SelectedItems[0].SubItems[2].Text;
            txtTenMay.Text = listView2.SelectedItems[0].SubItems[3].Text;
            txtTinhTrang.Text = listView2.SelectedItems[0].SubItems[4].Text;
            txtNVTN.Text = listView2.SelectedItems[0].SubItems[5].Text;
            txtCanSua.Text = listView2.SelectedItems[0].SubItems[6].Text;
            txtHenSua.Text = listView2.SelectedItems[0].SubItems[7].Text;
            txtDateHen.Text = listView2.SelectedItems[0].SubItems[8].Text;
            txtSoTien.Text = listView2.SelectedItems[0].SubItems[9].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLySuaChua QLSC = new QuanLySuaChua();
            QLSC.Show();
            this.Hide();
        }

        private void LichSuSuaChua_FormClosing(object sender, FormClosingEventArgs e)
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
            DialogResult dialog = MessageBox.Show("Cập nhật ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                btnDone.Enabled = true;
                ketnoi.Open();
                sql = @"UPDATE Inf_Repair set Laptop_Name = N'" + txtTenMay.Text + @"', Laptop_Status = N'" + txtTinhTrang.Text + @"'
                    Where (Repair_Id = N'" + txtMaSuaChua.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                sql = @"UPDATE Detail_Inf_Repair set Repair_Reason = N'" + txtCanSua.Text + @"', Repair_Note = N'" + txtHenSua.Text + @"', 
                    Repair_Appointment = '" + txtDateHen.Value.ToString("yyyy/MM/dd") + @"', Repair_Money = N'" + txtSoTien.Text + @"' Where (Repair_Id = N'" + txtMaSuaChua.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hienthi();
            }
            else
            {
                hienthi();
            }
        }

        private void btnNhanDon_Click(object sender, EventArgs e)
        {
            if(listView2.SelectedItems[0].SubItems[5].Text == Name)
            {
                Enable(true);
                listView2.Enabled = false;
                MessageBox.Show("Đã tiếp tục đơn !");
            }
            else
            {
                if (listView2.SelectedItems[0].SubItems[5].Text != "Chưa biết")
                {
                    MessageBox.Show("Đơn này đã có nhân viên " + listView2.SelectedItems[0].SubItems[5].Text + " nhận rồi, vui lòng chọn đơn khác");
                    hienthi();
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Xác nhận nhận đơn này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        btnNhanDon.Enabled = false;
                        Enable(true);
                        listView2.Enabled = false;
                        ketnoi.Open();
                        sql = @"UPDATE Inf_Repair set Staff_Id = N'" + Name + "' Where (Repair_Id = N'" + txtMaSuaChua.Text + @"')";
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        ketnoi.Close();
                        hienthi();
                        txtNVTN.Text = Name;
                    }
                }
            }
        }

        private void Enable(bool a)
        {
            btnUpdate.Enabled = a;
            txtCanSua.Enabled = a;
            txtDateHen.Enabled = a;
            txtHenSua.Enabled = a;
            txtSoTien.Enabled = a;
            txtTenMay.Enabled = a;
            txtTinhTrang.Enabled = a;
        }

        private void Clear()
        {
            txtCanSua.Text = "";
            txtDateHen.Text = "";
            txtMaSuaChua.Text = "";
            txtNVTN.Text = "";
            txtSoTien.Text = "";
            txtTenMay.Text = "";
            txtTinhTrang.Text = "";
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //Sửa lấy ngay
            //Hẹn ngày lấy
            DialogResult dialog = MessageBox.Show("Xác nhận hoàn thành đơn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                hienthi();
            }
            else
            {
                string Id = (txtMaSuaChua.Text).Substring(2);
                ketnoi.Open();
                sql = @"Insert into Inf_LichSu (Customer_Id, Repair_Time_End) VALUES(N'KH" + Id + @"', N'" + time + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                docdulieu.Close();
                sql = @"SELECT * from Inf_Customers Where (Customer_Id = N'KH" + Id + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    docdulieu = thuchien.ExecuteReader();
                    while (docdulieu.Read())
                    {
                    if(txtHenSua.Text == "Hẹn ngày lấy")
                        {
                            sendMail(docdulieu[1].ToString(), docdulieu[4].ToString(), docdulieu[5].ToString());
                        }
                        sql = @"UPDATE Inf_LichSu set Customer_Name = N'" + docdulieu[1].ToString() + @"', Customer_Sex = N'" + docdulieu[2].ToString() + @"', Customer_Birth = N'" + docdulieu[3].ToString() + @"', 
                                    Customer_Email = '" + docdulieu[4].ToString() + @"', Customer_Phone = N'" + docdulieu[5].ToString() + @"', Customer_TimeAdd = N'" + docdulieu[6].ToString() + @"'
                                            Where (Customer_Id = N'KH" + Id + @"')";
                            docdulieu.Dispose();
                            thuchien = new SqlCommand(sql, ketnoi);
                            thuchien.ExecuteNonQuery();
                            docdulieu = thuchien.ExecuteReader();
                    }
                    docdulieu.Close();
                    sql = @"SELECT Repair_Id, Laptop_Name, Laptop_Status, Staff_Id from Inf_Repair Where (Repair_Id = N'" + txtMaSuaChua.Text + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    docdulieu = thuchien.ExecuteReader();
                    while (docdulieu.Read())
                    {
                        sql = @"UPDATE Inf_LichSu set Repair_Id = N'" + docdulieu[0].ToString() + @"', Laptop_Name = N'" + docdulieu[1].ToString() + @"', Laptop_Status = N'" + docdulieu[2].ToString() + @"', 
                                    Staff_Id = '" + docdulieu[3].ToString() + @"' Where (Customer_Id = N'KH" + Id + @"')";
                        docdulieu.Dispose();
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        docdulieu = thuchien.ExecuteReader();
                    }
                    docdulieu.Close();
                    sql = @"SELECT Repair_Reason, Repair_Note, Repair_Appointment, Repair_Money from Detail_Inf_Repair Where (Repair_Id = N'" + txtMaSuaChua.Text + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    docdulieu = thuchien.ExecuteReader();
                    while (docdulieu.Read())
                    {
                        sql = @"UPDATE Inf_LichSu set Repair_Reason = N'" + docdulieu[0].ToString() + @"', Repair_Note = N'" + docdulieu[1].ToString() + @"', 
                                        Repair_Appointment = '" + docdulieu[2].ToString() + @"', Repair_Money = N'" + docdulieu[3].ToString() + @"' Where (Customer_Id = N'KH" + Id + @"')";
                        docdulieu.Dispose();
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        docdulieu = thuchien.ExecuteReader();
                    }
                    ketnoi.Close();
                    ketnoi.Open();
                    sql = @"DELETE from Detail_Inf_Repair Where (Repair_Id = N'" + txtMaSuaChua.Text + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.ExecuteNonQuery();
                    sql = @"DELETE from Inf_Repair Where (Customer_Id = N'KH" + Id + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.ExecuteNonQuery();
                    sql = @"DELETE from Inf_Customers Where (Customer_Id = N'KH" + Id + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.ExecuteNonQuery();
                    ketnoi.Close();
                    hienthi();
                    listView2.Enabled = true;
                    Enable(false);
                    Clear();
            }
        }

        public void sendMail(string NameTo, string EmailTo, string SDTTo)
        {
            try
            {
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential("herroseven@gmail.com", "@#Taitutoi952000@#");
                MailMessage message = new MailMessage("herroseven@gmail.com", EmailTo);
                message.Subject = "Thông báo hoàn tất việc sửa laptop !";
                message.Body = "<h3><b>Trân trọng gửi đến quý khách hàng thông báo: </b>"+ NameTo + "</h3>" +
                    "           <h5><b>Số điện thoại</b>: " + SDTTo + "</h5>" +
                    "           <h5><b>Tên laptop</b>: " + txtTenMay.Text + "</h5>" +
                    "           <h5><b>Chi tiết sửa</b>: "+ txtCanSua.Text + "</h5>" +
                    "           <h5><b>Số tiền</b>: " + String.Format("{0:#,###} VND", int.Parse(txtSoTien.Text)) + "</h5>" +
                    "           <h5><strong>Lưu ý: </strong> <i>Khi đến quý khách vui lòng đem đúng số tiền là <b>"+ String.Format("{0:#,###} VND", int.Parse(txtSoTien.Text)) + "</b> để thanh toán</i><h5> <br>" +
                    "           <h3><b>Trân trọng thông báo cho quý khách !<b><h3>";
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                mailclient.Send(message);
                MessageBox.Show("Mail hẹn nhận máy đã được gửi đi cho khách hàng: " + Name+ "", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail");
            }
        }
    }
}
