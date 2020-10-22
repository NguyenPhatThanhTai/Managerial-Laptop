using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    class Data_KH
    {
        DatabaseExcute db;
        string sql;
        string Sex, PhongBan, Quyen;
        string time = DateTime.Now.ToString("yyyy/MM/dd");
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");

        public Data_KH()
        {
            db = new DatabaseExcute();
        }


        // PHẦN THÔNG TIN KHÁCH HÀNG

        public DataTable Load_KH()
        {
            sql = @"Select * from Inf_Customers";
            return db.Excute(sql);
        }

        public bool Check_KH(string Customer_Name)
        {
            bool check = true;
            sql = @"Select * from Inf_Customers where (Customer_Name = N'" + Customer_Name + @"')";
            DataTable dtb = db.Excute(sql);
            if (dtb.Rows.Count != 0)
            {
                check = false;
            }
            return check;
        }

        public void Insert_KH(string Customer_Name, string Customer_Sex, string Customer_Birth, string Customer_Email, string Customer_Phone)
        {
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
            db.ExecuteNonQuery(sql);
            sql = @"Insert into Inf_Repair (Repair_Id, Customer_Id, Laptop_Name, Laptop_Status, Staff_Id)
                                                VALUES(N'RP" + day + "" + Min + "" + sec + "" + @"',N'KH" + day + "" + Min + "" + sec + "" + @"', N'Chưa biết', N'Chưa biết', N'Chưa biết')";
            db.ExecuteNonQuery(sql);
            sql = @"Insert into Detail_Inf_Repair (Repair_Id, Repair_Reason, Repair_Note, Repair_Appointment, Repair_Money)
                                                VALUES(N'RP" + day + "" + Min + "" + sec + "" + @"', N'Chưa biết', N'Sửa lấy ngay', '09/05/2000', 0)";
            db.ExecuteNonQuery(sql);
            time = DateTime.Now.ToString("yyyy/MM/dd");
            day = DateTime.Now.ToString("dd");
            Min = DateTime.Now.ToString("mm");
            sec = DateTime.Now.ToString("ss");
        }

        public void Update_KH(string Customer_Name, String Customer_Sex, string Customer_Birth, String Customer_Email, string Customer_Phone, string Customer_Id)
        {
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
            db.ExecuteNonQuery(sql);
        }

        public void Delete_KH(string Customer_Id)
        {
            string repair = (String)Customer_Id;
            string repairID = repair.Substring(2);
            sql = @"DELETE FROM Detail_Inf_Repair where(Repair_Id = N'RP" + repairID + @"')";
            db.ExecuteNonQuery(sql);
            sql = @"DELETE FROM Inf_Repair where(Customer_Id = N'" + Customer_Id + @"')";
            db.ExecuteNonQuery(sql);
            sql = @"DELETE FROM Inf_Customers where(Customer_Id = N'" + Customer_Id + @"')";
            db.ExecuteNonQuery(sql);
        }

        // PHẦN THÔNG TIN SỮA CHỮA

        public DataTable Load_RP()
        {
                sql = @"Select Inf_Repair.Repair_Id, Inf_Customers.Customer_Name, Inf_Repair.Laptop_Name, Inf_Repair.Laptop_Status, Inf_repair.Staff_Id, Detail_Inf_Repair.Repair_Reason, Detail_Inf_Repair.Repair_Note, Detail_Inf_Repair.Repair_Appointment, Detail_Inf_Repair.Repair_Money  
                        from Inf_Customers 
                                inner join Inf_Repair
                                        on Inf_Customers.Customer_Id = Inf_Repair.Customer_Id
                                inner join Detail_Inf_Repair
                                        on Inf_Repair.Repair_Id = Detail_Inf_Repair.Repair_Id";
                return db.Excute(sql);
        }

        public void Update_RP(string Laptop_Name, string Laptop_Status, string Repair_Reason, string Repair_Note, string Repair_Appointment, string Repair_Money, string Repair_Id)
        {
            sql = @"UPDATE Inf_Repair set Laptop_Name = N'" + Laptop_Name + @"', Laptop_Status = N'" + Laptop_Status + @"'
                    Where (Repair_Id = N'" + Repair_Id + @"')";
            db.ExecuteNonQuery(sql);
            var date = DateTime.Parse(Repair_Appointment.ToString());
            sql = @"UPDATE Detail_Inf_Repair set Repair_Reason = N'" + Repair_Reason + @"', Repair_Note = N'" + Repair_Note + @"', 
                    Repair_Appointment = '" + date.ToString("yyyy/MM/dd") + @"', Repair_Money = N'" + Repair_Money + @"' Where (Repair_Id = N'" + Repair_Id + @"')";
            db.ExecuteNonQuery(sql);
        }

        public void Update_NhanDon(string NVTN, string Repair_Id)
        {
            sql = @"UPDATE Inf_Repair set Staff_Id = N'" + NVTN + "' Where (Repair_Id = N'" + Repair_Id + @"')";
            db.ExecuteNonQuery(sql);
        }

        public void Done_RP(string Repair_Id, string Laptop_Name, string Repair_Reason, string Repair_Money, string Repair_Appoinment)
        {
            string Id = (Repair_Id).Substring(2);
            sql = @"Insert into Inf_LichSu (Customer_Id, Repair_Time_End) VALUES(N'KH" + Id + @"', N'" + time + @"')";
            db.ExecuteNonQuery(sql);
            string sql1 = @"SELECT * from Inf_Customers Where (Customer_Id = N'KH" + Id + @"')";
            DataTable dtb1 = db.Excute(sql1);
            if (dtb1.Rows.Count > 0)
            {
                foreach (DataRow row in dtb1.Rows)
                {
                    if (Repair_Appoinment == "Hẹn ngày lấy")
                    {
                        var thread = new Thread(() => sendMail(row[1].ToString(), row[4].ToString(), row[5].ToString(), Laptop_Name, Repair_Reason, Repair_Money));
                        thread.Start();
                    }
                    var date = DateTime.Parse(row[3].ToString());
                    var date2 = DateTime.Parse(row[6].ToString());
                    sql = @"UPDATE Inf_LichSu set Customer_Name = N'" + row[1].ToString() + @"', Customer_Sex = N'" + row[2].ToString() + @"', Customer_Birth = N'" + date.ToString("yyyy/MM/dd") + @"', 
                                    Customer_Email = '" + row[4].ToString() + @"', Customer_Phone = N'" + row[5].ToString() + @"', Customer_TimeAdd = N'" + date2.ToString("yyyy/MM/dd") + @"'
                                            Where (Customer_Id = N'KH" + Id + @"')";
                    db.ExecuteNonQuery(sql);
                }
            }
            string sql2 = @"SELECT Repair_Id, Laptop_Name, Laptop_Status, Staff_Id from Inf_Repair Where (Repair_Id = N'" + Repair_Id + @"')";
            DataTable dtb2 = db.Excute(sql2);
            if (dtb2.Rows.Count > 0)
            {
                foreach (DataRow row in dtb2.Rows)
                {
                    sql = @"UPDATE Inf_LichSu set Repair_Id = N'" + row[0].ToString() + @"', Laptop_Name = N'" + row[1].ToString() + @"', Laptop_Status = N'" + row[2].ToString() + @"', 
                                    Staff_Id = '" + row[3].ToString() + @"' Where (Customer_Id = N'KH" + Id + @"')";
                    db.ExecuteNonQuery(sql);
                }
            }
            string sql3 = @"SELECT Repair_Reason, Repair_Note, Repair_Appointment, Repair_Money from Detail_Inf_Repair Where (Repair_Id = N'" + Repair_Id + @"')";
            DataTable dtb3 = db.Excute(sql3);
            if (dtb3.Rows.Count > 0)
            {
                foreach (DataRow row in dtb3.Rows)
                {
                    var date = DateTime.Parse(row[2].ToString());
                    sql = @"UPDATE Inf_LichSu set Repair_Reason = N'" + row[0].ToString() + @"', Repair_Note = N'" + row[1].ToString() + @"', 
                                        Repair_Appointment = '" + date.ToString("yyyy/MM/dd") + @"', Repair_Money = N'" + row[3].ToString() + @"' Where (Customer_Id = N'KH" + Id + @"')";
                    db.ExecuteNonQuery(sql);
                }
            }
            sql = @"DELETE from Detail_Inf_Repair Where (Repair_Id = N'" + Repair_Id + @"')";
            db.ExecuteNonQuery(sql);
            sql = @"DELETE from Inf_Repair Where (Customer_Id = N'KH" + Id + @"')";
            db.ExecuteNonQuery(sql);
            sql = @"DELETE from Inf_Customers Where (Customer_Id = N'KH" + Id + @"')";
            db.ExecuteNonQuery(sql);
        }

        private static void sendMail(string NameTo, string EmailTo, string SDTTo, string Laptop_Name, string Repair_Reason, string Repair_Money)
        {
            try
            {
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential("herroseven@gmail.com", "@#Taitutoi952000@#");
                MailMessage message = new MailMessage("herroseven@gmail.com", EmailTo);
                message.Subject = "Thông báo hoàn tất việc sửa laptop !";
                message.Body = "<h3><b>Trân trọng gửi đến quý khách hàng : </b>" + NameTo + "</h3>" +
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

        // PHẦN LỊCH SỬ SỮA CHỮA

        public DataTable Load_LS()
        {
            sql = @"Select * from Inf_LichSu";
            return db.Excute(sql);
        }

        public void delete(string id)
        {
            sql = @"DELETE from Inf_LichSu where (Customer_Id =N'" + id + @"')"; ;
            db.ExecuteNonQuery(sql);
        }
    }
}
