using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
        string time = DateTime.Now.ToString("dd/MM/yyyy");
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");


                                                    ////////////////////////// QUẢN LÝ LINH KIỆN //////////////////////////

        // LOAD LINH KIỆN LÊN LIST VIEW
        public DataTable Load_LK()
        {
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();
                sql = @"Select * from Inf_LK";
                SqlDataAdapter da = new SqlDataAdapter(sql, chuoiketnoi);
                da.Fill(data);
                connection.Close();
                return data;
            }
        }

        // KIỂM TRA TỒN TẠI KINH KIỆN
        public bool Check_LK(string LK, string nameLK)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"Select * from Inf_LK where (LK_Name = N'" + LK + @"' and LK_Producer = N'" + nameLK + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                return false;
            }
            return true;
        }

        // THÊM MỚI LINH KIỆN
        public void Insert_LK(string LK_Name, string LK_Number, string LK_Producer, string LK_Price)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"Insert into Inf_LK (LK_Id, LK_Name, LK_Number, LK_Producer, LK_Price, LK_Time_Add) VALUES(N'LK" + day + "" + Min + "" + sec + @"',N'" + LK_Name + @"',N'"
                                + LK_Number + @"', N'" + LK_Producer + @"', N'" + LK_Price + @"', N'" + time + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
        }

        // PHÂN LOẠI LINH KIỆN ( LỌC )
        public DataTable Classify_LK (string LK_Name)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();
                sql = @"Select * from Inf_LK where (LK_Producer = N'" + LK_Name + @"')";
                SqlDataAdapter da = new SqlDataAdapter(sql, chuoiketnoi);
                da.Fill(data);
                connection.Close();
                return data;
            }
        }

        // XÓA LINH KIỆN
        public void Delete_LK(string LK_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"Delete from Inf_LK where (LK_Id = N'" + LK_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
        }

        // CẬP NHẬT LINH KIỆN
        public void Update_LK(string LK_Name, string LK_Number, string LK_Producer, string LK_Price, string LK_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"UPDATE Inf_LK set LK_Name = N'" + LK_Name + @"', LK_Number = N'" + LK_Number + @"', 
                    LK_Producer = N'" + LK_Producer + "', LK_Price = N'" + LK_Price + @"' Where (LK_Id = N'" + LK_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
        }

                                               ////////////////////////// QUẢN LÝ NHÂN VIÊN //////////////////////////
                                               
                                                                      ///PHẦN THÔNG TIN NHÂN VIÊN
                            
        // LOAD THÔNG TIN NHÂN VIÊN LÊN LIST VIEW
        public DataTable Load_NV()
        {
            using (SqlConnection connection = new SqlConnection(chuoiketnoi))
            {
                connection.Open();
                sql = @"Select * from Inf_Staff";
                SqlDataAdapter da = new SqlDataAdapter(sql, chuoiketnoi);
                da.Fill(data);
                connection.Close();
                return data;
            }
        }

        // KIỂM TRA TỒN TẠI NHÂN VIÊN
        public bool Check_NV(string Staff_Name)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"Select * from Inf_Staff where (Staff_Name = N'" + Staff_Name + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                ketnoi.Close();
                return false;
            }
            ketnoi.Close();
            return true;

        }

        // THÊM MỚI MỘT NHÂN VIÊN
        public void Insert_NV(string Staff_Name, string Staff_Sex, string Staff_Birth, string Staff_Address, string Staff_Phone, string Staff_Department)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            if (Staff_Sex == "Nam")
            {
                Sex = "1";
            }
            else
            {
                Sex = "2";
            }
            if (Staff_Department == "Quản Lý")
            {
                PhongBan = "1";
            }
            else if (Staff_Department == "Kỹ Thuật")
            {
                PhongBan = "2";
            }
            else
            {
                PhongBan = "3";
            }
            sql = @"Insert into Inf_Staff (Staff_Id, Staff_Name, Staff_Sex, Staff_Birth, Staff_Address, Staff_Phone, Staff_Deparment, Staff_TimeAdd) VALUES(N'NV" + day + "" + Min + "" + sec + "" + @"',N'" + Staff_Name + @"',N'"
                    + Sex + @"', N'" + Staff_Birth + @"', N'" + Staff_Address + @"', N'" + Staff_Phone + @"' , N'" + PhongBan + @"' ,  N'" + time + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"Insert into Account_Staff(Staff_Id, Staff_Account, Staff_Password, Staff_Role) VALUES (N'NV" + day + "" + Min + "" + sec + "" + @"', N'NV" + day + "" + Min + "" + sec + "" + @"', 1, N'" + PhongBan + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"Insert into Salary_Staff(Staff_Id, Staff_Default_Salary, Staff_Salary_Per_Hour, Staff_OT, Staff_Reward) VALUES (N'NV" + day + "" + Min + "" + sec + "" + @"',0, 0, 0, 0)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            time = DateTime.Now.ToString("dd/MM/yyyy");
            day = DateTime.Now.ToString("dd");
            Min = DateTime.Now.ToString("mm");
            sec = DateTime.Now.ToString("ss");
            ketnoi.Close();
        }

        // CẬP NHẬT THÔNG TIN NHÂN VIÊN
        public void Update_NV(string Staff_Name, string Staff_Sex, string Staff_Birth, string Staff_Address, string Staff_Phone, string  Staff_Deparment, string Staff_Id)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            if (Staff_Sex == "Nam")
            {
                Sex = "1";
            }
            else
            {
                Sex = "2";
            }
            if (Staff_Deparment == "Quản Lý")
            {
                PhongBan = "1";
            }
            else if (Staff_Deparment == "Kỹ Thuật")
            {
                PhongBan = "2";
            }
            else
            {
                PhongBan = "3";
            }
            sql = @"UPDATE Inf_Staff set Staff_Name = N'" + Staff_Name + @"', Staff_Sex = N'" + Sex + @"', 
                    Staff_Birth = N'" + Staff_Birth + "', Staff_Address = N'" + Staff_Address + @"', Staff_Phone = N'" + Staff_Phone + @"', Staff_Deparment = N'" + PhongBan + @"' Where (Staff_Id = N'" + Staff_Id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        // XÓA 1 NHÂN VIÊN
        public void Delete_NV(string Staff_ID)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"DELETE FROM Account_Staff where(Staff_Id = N'" + Staff_ID + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"DELETE FROM Salary_Staff where(Staff_Id = N'" + Staff_ID + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            sql = @"DELETE FROM Inf_Staff where(Staff_Id = N'" + Staff_ID + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

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
    }
}
