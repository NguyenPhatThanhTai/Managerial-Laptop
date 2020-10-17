using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class Data_NV
    {
        DatabaseExcute db;
        string sql;
        string Sex, PhongBan, Quyen;
        string time = DateTime.Now.ToString("dd/MM/yyyy");
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");

        //PHẦN THÔNG TIN NHÂN VIÊN

        public Data_NV()
        {
            db = new DatabaseExcute();
        }

        public DataTable Load_NV()
        {
            sql = @"Select * from Inf_Staff";
            return db.Excute(sql);
        }

        public bool Check_NV(string Staff_Name)
        {
            bool check = true;
            sql = @"Select * from Inf_Staff where (Staff_Name = N'" + Staff_Name + @"')";
            DataTable dtb = db.Excute(sql);
            if (dtb.Rows.Count != 0)
            {
                check = false;
            }
            return check;
        }

        public void Insert_NV(string Staff_Name, string Staff_Sex, string Staff_Birth, string Staff_Address, string Staff_Phone, string Staff_Department)
        {
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
            db.ExecuteNonQuery(sql);
            sql = @"Insert into Account_Staff(Staff_Id, Staff_Account, Staff_Password, Staff_Role) VALUES (N'NV" + day + "" + Min + "" + sec + "" + @"', N'NV" + day + "" + Min + "" + sec + "" + @"', 1, N'" + PhongBan + @"')";
            db.ExecuteNonQuery(sql);
            sql = @"Insert into Salary_Staff(Staff_Id, Staff_Default_Salary, Staff_Salary_Per_Hour, Staff_OT, Staff_Reward) VALUES (N'NV" + day + "" + Min + "" + sec + "" + @"',0, 0, 0, 0)";
            db.ExecuteNonQuery(sql);
            time = DateTime.Now.ToString("dd/MM/yyyy");
            day = DateTime.Now.ToString("dd");
            Min = DateTime.Now.ToString("mm");
            sec = DateTime.Now.ToString("ss");
        }

        public void Update_NV(string Staff_Name, string Staff_Sex, string Staff_Birth, string Staff_Address, string Staff_Phone, string Staff_Deparment, string Staff_Id)
        {
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
            db.ExecuteNonQuery(sql);
        }
        public void Delete_NV(string Staff_ID)
        {
            sql = @"DELETE FROM Account_Staff where(Staff_Id = N'" + Staff_ID + @"')";
            db.ExecuteNonQuery(sql);
            sql = @"DELETE FROM Salary_Staff where(Staff_Id = N'" + Staff_ID + @"')";
            db.ExecuteNonQuery(sql);
            sql = @"DELETE FROM Inf_Staff where(Staff_Id = N'" + Staff_ID + @"')";
            db.ExecuteNonQuery(sql);
        }

        // PHẦN LƯƠNG NHÂN VIÊN

        public DataTable Load_TK()
        {
            sql = @"Select * from Account_Staff";
            return db.Excute(sql);
        }
    }
}