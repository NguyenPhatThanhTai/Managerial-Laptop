using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class Data_LK
    {
        DatabaseExcute db;
        string sql;
        string Sex, PhongBan, Quyen;
        string time = DateTime.Now.ToString("yyyy/MM/dd");
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");
        public Data_LK()
        {
            db = new DatabaseExcute();
        }

        public DataTable Load_LK()
        {
            sql = @"Select * from Inf_LK";
            return db.Excute(sql);
        }

        public bool Check_LK(string LK, string nameLK)
        {
            bool check = true;
            sql = @"Select * from Inf_LK where (LK_Name = N'" + LK + @"' and LK_Producer = N'" + nameLK + @"')";
            DataTable dtb = db.Excute(sql);
            if (dtb.Rows.Count != 0)
            {
                check = false;
            }
            return check;
        }

        public void Insert_LK(string LK_Name, string LK_Number, string LK_Producer, string LK_Price)
        {
            sql = @"Insert into Inf_LK (LK_Id, LK_Name, LK_Number, LK_Producer, LK_Price, LK_Time_Add) VALUES(N'LK" + day + "" + Min + "" + sec + @"',N'" + LK_Name + @"',N'"
                                + LK_Number + @"', N'" + LK_Producer + @"', N'" + LK_Price + @"', N'" + time + @"')";
            db.ExecuteNonQuery(sql);
            time = DateTime.Now.ToString("dd/MM/yyyy");
            day = DateTime.Now.ToString("dd");
            Min = DateTime.Now.ToString("mm");
            sec = DateTime.Now.ToString("ss");
        }

        public DataTable Classify_LK(string LK_Name)
        {   
            sql = @"Select * from Inf_LK where (LK_Producer = N'" + LK_Name + @"')";
            return db.Excute(sql);
        }

        public void Delete_LK(string LK_Id)
        {
            sql = @"Delete from Inf_LK where (LK_Id = N'" + LK_Id + @"')";
            db.ExecuteNonQuery(sql);
        }

        public void Update_LK(string LK_Name, string LK_Number, string LK_Producer, string LK_Price, string LK_Id)
        {
            sql = @"UPDATE Inf_LK set LK_Name = N'" + LK_Name + @"', LK_Number = N'" + LK_Number + @"', 
                    LK_Producer = N'" + LK_Producer + "', LK_Price = N'" + LK_Price + @"' Where (LK_Id = N'" + LK_Id + @"')";
            db.ExecuteNonQuery(sql);
        }
    }
}
