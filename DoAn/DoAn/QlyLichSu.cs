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
    public partial class LichSuSuaChua : Form
    {
        public LichSuSuaChua()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=QuanLySuaChuaLaptop;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        string name;
        string Name;
        int Role;

        public LichSuSuaChua(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthiLichSu();
        }

        public void hienthiLichSu()
        {
            listView2.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from History";
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
            Delete.Enabled = true;
            name = listView2.SelectedItems[0].SubItems[1].Text;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string sql = @"Delete from History where (name = N'" + name.ToString() + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            ketnoi.Close();
            hienthiLichSu();
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

                /*public void sendMail(string toEmail)
        {
            try
            {
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential("herroseven@gmail.com", "@#Taitutoi952000@#");
                MailMessage message = new MailMessage("herroseven@gmail.com", toEmail);
                message.Subject = "Thông báo hoàn tất việc sửa laptop !";
                message.Body = "<h3><b>Trân trọng gửi đến quý khách hàng: </b>"+ txtHoTen.Text +"</h3>" +
                    "           <h5><b>Số điện thoại</b>: " + txtSDT.Text + "</h5>" +
                    "           <h5><b>Tên laptop</b>: " + txtTenMay.Text + "</h5>" +
                    "           <h5><b>Chi tiết sửa</b>: "+ txtChiTiet.Text + "</h5>" +
                    "           <h5><b>Số tiền</b>: " + String.Format("{0:#,###} VND", int.Parse(txtSoTien.Text)) + "</h5>" +
                    "           <h5><strong>Lưu ý: </strong> <i>Khi đến quý khách vui lòng đem đúng số tiền là <b>"+ String.Format("{0:#,###} VND", int.Parse(txtSoTien.Text)) + "</b> để thanh toán</i><h5> <br>" +
                    "           <h3><b>Trân trọng thông báo cho quý khách !<b><h3>";
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                mailclient.Send(message);
                MessageBox.Show("Mail hẹn nhận máy đã được gửi đi cho khách hàng: " +txtHoTen.Text+ "", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail");
            }
        }*/

                /*private void btnHoanTat_Click(object sender, EventArgs e)
                {
                    ketnoi.Open();
                    sql = @"Insert into History (Name, Email, SDT, Kind, DetailFix, Status, Noti, Money, TimeEnd) VALUES(N'" + txtHoTen.Text + @"',N'" + txtEmail.Text + @"',N'"
                            + txtSDT.Text + @"', N'" + txtTenMay.Text + @"', N'" + txtChiTiet.Text + @"', N'" + "Hoàn thành" + @"', N'" + txtGhiChu.Text + @"', N'" + txtSoTien.Text + @"', N'" + time + @"')";
                    thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.ExecuteNonQuery();
                    ketnoi.Close();
                    hienthi();
                    deleteUser(txtHoTen.Text);
                    ketnoi.Close();
                    hienthi();
                    //Gmail when done
                    sendMail(txtEmail.Text);
                }*/
    }
}
