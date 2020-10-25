using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class Data_KT
    {
        DatabaseExcute db;
        string sql;
        public Data_KT() 
        {
            db = new DatabaseExcute();
        }
        public DataTable Load_KT()
        {
            sql = @"Select Repair_Id, Customer_TimeAdd, Repair_Time_End, Repair_Money from Inf_LichSu";
            return db.Excute(sql);
        }

        public DataTable DataBetweenDate(string StartDate, string EndDate)
        {
            sql = @"select Repair_Id, Customer_TimeAdd, Repair_Time_End, Repair_Money from Inf_LichSu where Repair_Time_End between N'" + StartDate + @"' and N'" + EndDate + @"' ";
            return db.Excute(sql);
        }
    }
}
