using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class DatabaseExcute
    {
        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        SqlDataAdapter da;
        DataTable data;
        DataSet ds;

        public DatabaseExcute()
        {
            ketnoi = new SqlConnection(chuoiketnoi);
        }

        public DataTable Excute(string SqlCommand)
        {
            da = new SqlDataAdapter(SqlCommand, chuoiketnoi);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public void ExecuteNonQuery(String SqlCommand)
        {
            thuchien = new SqlCommand(SqlCommand, ketnoi);
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }
    }
}
