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
    public partial class QlySuaChua : Form
    {
        public QlySuaChua()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=QuanLySuaChuaLaptop;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string time = DateTime.Now.ToString();
        int Role;
        string Name;
        int i = 0;

        public QlySuaChua(int Role, string Name) : this()
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
            txtTinhTrang.Enabled = false;
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
            sql = @"Select * from TableSuaChua where (name = N'" + User + @"')";
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
            if (txtHoTen.Text != "" && txtEmail.Text != "" && txtSDT.Text != "" && txtTenMay.Text != "" && txtChiTiet.Text != "" && txtTinhTrang.Text != ""
                                && txtGhiChu.Text != "" && txtSoTien.Text != "")
            {
                listView1.Items.Clear();
                if (CheckUser(txtHoTen.Text))
                {
                    ketnoi.Close();
                    ketnoi.Open();
                    sql = @"Insert into TableSuaChua (Name, Email, SDT, Kind, DetailFix, Status, Noti, Money, TimeStart) VALUES(N'" + txtHoTen.Text + @"',N'" + txtEmail.Text + @"',N'"
                            + txtSDT.Text + @"', N'" + txtTenMay.Text + @"', N'" + txtChiTiet.Text + @"', N'" + "Chưa hoàn thành" + @"', N'" + txtGhiChu.Text + @"', N'" + txtSoTien.Text + @"', N'" + time + @"')";
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
            sql = @"UPDATE TableSuaChua set Name = N'" + txtHoTen.Text + @"', Email = N'" + txtEmail.Text + @"', 
                    SDT = N'" + txtSDT.Text + @"', Kind = N'" + txtTenMay.Text + @"', DetailFix = N'" + txtChiTiet.Text + @"',
                        Status = N'" + txtTinhTrang.Text + @"', Noti = N'" + txtGhiChu.Text + @"', Money = N'" + txtSoTien.Text + @"',  TimeStart = N'" + txtThoiGian.Text + @"' Where (Name = N'" + txtHoTen.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        public void sendMail(string toEmail)
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
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
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
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            LichSuSuaChua f2 = new LichSuSuaChua();
            f2.Show();
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
            txtHoTen.Enabled = true;
            txtTinhTrang.Enabled = true;
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
    }
}
