using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace DoAn
{
    class DatabaseConnection
    {
        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        DataTable data = new DataTable();
        string Sex, PhongBan, Quyen;
        string time = DateTime.Now.ToString("yyyy/MM/dd");
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");

        ////////////////////////// QUẢN LÝ NHÂN VIÊN //////////////////////////

        ///PHẦN TÀI KHOẢN NHÂN VIÊN

        // LOAD THÔNG TIN TÀI KHOẢN LÊN LIST VIEW

        public DataTable Load_TK()
        {
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();
                sql = @"Select * from Account_Staff";
                SqlDataAdapter da = new SqlDataAdapter(sql, chuoiketnoi);
                da.Fill(data);
                connection.Close();
                return data;
            }
        }

        // CẬP NHẬT TÀI KHOẢN

        public void Update_TK(string Staff_Password, string Staff_Role, string Staff_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            if (Staff_Role == "Admin")
            {
                Quyen = "1";
            }
            else
            {
                Quyen = "2";
            }
            sql = @"UPDATE Account_Staff set Staff_Password = N'" + Staff_Password + @"', Staff_Role = N'" + Quyen + @"' Where (Staff_Id = N'" + Staff_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        ///PHẦN LƯƠNG NHÂN VIÊN

        // LOAD LƯƠNG NHÂN VIÊN LÊN LIST VIEW

        public DataTable Load_Salary()
        {
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();
                sql = @"Select * from Salary_Staff";
                SqlDataAdapter da = new SqlDataAdapter(sql, chuoiketnoi);
                da.Fill(data);
                connection.Close();
                return data;
            }
        }

        // CẬP NHẬT LƯƠNG NHÂN VIÊN

        public void Update_Salary(string Staff_Default_Salary, string Staff_Salary_Per_Hour, string Staff_OT, string Staff_Reward, string Staff_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"UPDATE Salary_Staff set Staff_Default_Salary = N'" + Staff_Default_Salary + @"', Staff_Salary_Per_Hour = N'" + Staff_Salary_Per_Hour + @"', Staff_OT = N'" + Staff_OT + @"', Staff_Reward = N'" + Staff_Reward + @"' Where (Staff_Id = N'" + Staff_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        ////////////////////////// QUẢN LÝ SỬA CHỮA //////////////////////////

        /// PHẦN QUẢN LÝ THÔNG TIN KHÁCH HÀNG ///

        // LOAD THÔNG TIN KHÁCH HÀNG LÊN LIST VIEW

        public DataTable Load_KH()
        {
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();
                sql = @"Select * from Inf_Customers";
                SqlDataAdapter da = new SqlDataAdapter(sql, chuoiketnoi);
                da.Fill(data);
                connection.Close();
                return data;
            }
        }

        // KIỂM TRA TỒN TẠI NHÂN VIÊN

        public bool Check_KH(string Customer_Name)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"Select * from Inf_Customers where (Customer_Name = N'" + Customer_Name + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                return false;
            }
            return true;
        }

        // THÊM MỚI NHÂN VIÊN

        public void Insert_KH(string Customer_Name, string Customer_Sex, string Customer_Birth, string Customer_Email, string Customer_Phone)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            if (Customer_Sex == "Nam")
            {
                Sex = "1";
            }
            else
            {
                Sex = "2";
            }
            sql = @"Insert into Inf_Customers (Customer_Id, Customer_Name, Customer_Sex, Customer_Birth, Customer_Email, Customer_Phone, Customer_TimeAdd)
                                                VALUES(N'KH" + day + "" + Min + "" + sec + "" + @"',N'" + Customer_Name + @"',N'" + Sex + @"', N'" + Customer_Birth + "',N'" + Customer_Email + @"',N'"
                    + Customer_Phone + @"', N'" + time + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"Insert into Inf_Repair (Repair_Id, Customer_Id, Laptop_Name, Laptop_Status, Staff_Id)
                                                VALUES(N'RP" + day + "" + Min + "" + sec + "" + @"',N'KH" + day + "" + Min + "" + sec + "" + @"', N'Chưa biết', N'Chưa biết', N'Chưa biết')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"Insert into Detail_Inf_Repair (Repair_Id, Repair_Reason, Repair_Note, Repair_Appointment, Repair_Money)
                                                VALUES(N'RP" + day + "" + Min + "" + sec + "" + @"', N'Chưa biết', N'Sửa lấy ngay', '09/05/2000', 0)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            time = DateTime.Now.ToString();
            day = DateTime.Now.ToString("dd");
            Min = DateTime.Now.ToString("mm");
            sec = DateTime.Now.ToString("ss");
        }

        // CẬP NHẬT NHÂN VIÊN

        public void Update_KH(string Customer_Name, String Customer_Sex, string Customer_Birth, String Customer_Email, string Customer_Phone, string Customer_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            if (Customer_Sex == "Nam")
            {
                Sex = "1";
            }
            else
            {
                Sex = "2";
            }
            sql = @"UPDATE Inf_Customers set Customer_Name = N'" + Customer_Name + @"', Customer_Sex = N'" + Sex + @"', 
                    Customer_Birth = '" + Customer_Birth + "', Customer_Email = N'" + Customer_Email + @"', Customer_Phone = N'" + Customer_Phone + @"' Where (Customer_Id = N'" + Customer_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        // XÓA NHÂN VIÊN

        public void Delete_KH(string Customer_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            string repair = (String)Customer_Id;
            string repairID = repair.Substring(2);
            sql = @"DELETE FROM Detail_Inf_Repair where(Repair_Id = N'RP" + repairID + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"DELETE FROM Inf_Repair where(Customer_Id = N'" + Customer_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"DELETE FROM Inf_Customers where(Customer_Id = N'" + Customer_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            ketnoi.Close();
        }

        /// PHẦN QUẢN LÝ THÔNG TIN SỮA CHỮA ///
        public DataTable Load_RP()
        {
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();
                sql = @"Select Inf_Repair.Repair_Id, Inf_Customers.Customer_Name, Inf_Repair.Laptop_Name, Inf_Repair.Laptop_Status, Inf_repair.Staff_Id, Detail_Inf_Repair.Repair_Reason, Detail_Inf_Repair.Repair_Note, Detail_Inf_Repair.Repair_Appointment, Detail_Inf_Repair.Repair_Money  
                        from Inf_Customers 
                                inner join Inf_Repair
                                        on Inf_Customers.Customer_Id = Inf_Repair.Customer_Id
                                inner join Detail_Inf_Repair
                                        on Inf_Repair.Repair_Id = Detail_Inf_Repair.Repair_Id";
                SqlDataAdapter da = new SqlDataAdapter(sql, chuoiketnoi);
                da.Fill(data);
                connection.Close();
                return data;
            }
        }

        public void Update_RP(string Laptop_Name, string Laptop_Status, string Repair_Reason, string Repair_Note, string Repair_Appointment, string Repair_Money, string Repair_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"UPDATE Inf_Repair set Laptop_Name = N'" + Laptop_Name + @"', Laptop_Status = N'" + Laptop_Status + @"'
                    Where (Repair_Id = N'" + Repair_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"UPDATE Detail_Inf_Repair set Repair_Reason = N'" + Repair_Reason + @"', Repair_Note = N'" + Repair_Note + @"', 
                    Repair_Appointment = '" + Repair_Appointment + @"', Repair_Money = N'" + Repair_Money + @"' Where (Repair_Id = N'" + Repair_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        public void Update_NhanDon(string NVTN, string Repair_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"UPDATE Inf_Repair set Staff_Id = N'" + NVTN + "' Where (Repair_Id = N'" + Repair_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        public void Done_RP(string Repair_Id, string Laptop_Name, string Repair_Reason, string Repair_Money, string Repair_Appoinment)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            string Id = (Repair_Id).Substring(2);
            ketnoi.Open();
            sql = @"Insert into Inf_LichSu (Customer_Id, Repair_Time_End) VALUES(N'KH" + Id + @"', N'" + time + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"SELECT * from Inf_Customers Where (Customer_Id = N'KH" + Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            while (docdulieu.Read())
            {
                if (Repair_Appoinment == "Hẹn ngày lấy")
                {
                    sendMail(docdulieu[1].ToString(), docdulieu[4].ToString(), docdulieu[5].ToString(), Laptop_Name, Repair_Reason, Repair_Money);
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
            sql = @"SELECT Repair_Id, Laptop_Name, Laptop_Status, Staff_Id from Inf_Repair Where (Repair_Id = N'" + Repair_Id + @"')";
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
            sql = @"SELECT Repair_Reason, Repair_Note, Repair_Appointment, Repair_Money from Detail_Inf_Repair Where (Repair_Id = N'" + Repair_Id + @"')";
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
            sql = @"DELETE from Detail_Inf_Repair Where (Repair_Id = N'" + Repair_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"DELETE from Inf_Repair Where (Customer_Id = N'KH" + Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"DELETE from Inf_Customers Where (Customer_Id = N'KH" + Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        public void sendMail(string NameTo, string EmailTo, string SDTTo, string Laptop_Name, string Repair_Reason, string Repair_Money)
        {
            try
            {
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential("herroseven@gmail.com", "@#Taitutoi952000@#");
                MailMessage message = new MailMessage("herroseven@gmail.com", EmailTo);
                message.Subject = "Thông báo hoàn tất việc sửa laptop !";
                message.Body = "<h3><b>Trân trọng gửi đến quý khách hàng thông báo: </b>" + NameTo + "</h3>" +
                    "           <h5><b>Số điện thoại</b>: " + SDTTo + "</h5>" +
                    "           <h5><b>Tên laptop</b>: " + Laptop_Name + "</h5>" +
                    "           <h5><b>Chi tiết sửa</b>: " + Repair_Reason + "</h5>" +
                    "           <h5><b>Số tiền</b>: " + String.Format("{0:#,###} VND", int.Parse(Repair_Money)) + "</h5>" +
                    "           <h5><strong>Lưu ý: </strong> <i>Khi đến quý khách vui lòng đem đúng số tiền là <b>" + String.Format("{0:#,###} VND", int.Parse(Repair_Money)) + "</b> để thanh toán</i><h5> <br>" +
                    "           <h3><b>Trân trọng thông báo cho quý khách !<b><h3>";
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                mailclient.Send(message);
                MessageBox.Show("Mail hẹn nhận máy đã được gửi đi cho khách hàng: " + NameTo + "", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail");
            }
        }
    }
}

