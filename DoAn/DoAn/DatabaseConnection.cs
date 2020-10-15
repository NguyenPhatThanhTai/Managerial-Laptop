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
        string time = DateTime.Now.ToString("ddd/MM/yyyy");
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");



                                                    ////////////////////////// QUẢN LÝ LINH KIỆN //////////////////////////

        // LOAD LINH KIỆN LÊN LIST VIEW
        public DataTable Load_LK()
        {
            DataTable data = new DataTable();
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
    }
}
