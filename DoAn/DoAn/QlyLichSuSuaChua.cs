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
    public partial class QlyLichSuSuaChua : Form
    {
        public QlyLichSuSuaChua()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        string Sex;
        string id;

        private void QlyLichSuSuaChua_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        private void hienthi()
        {
            lsvLichSu.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from Inf_LichSu";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                if (docdulieu[2].ToString() == "1")
                {
                    Sex = "Nam";
                }
                else if (docdulieu[2].ToString() == "2")
                {
                    Sex = "Nữ";
                }
                else
                {
                    Sex = "Khác";
                }

                lsvLichSu.Items.Add((i + 1).ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[0].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[1].ToString());
                lsvLichSu.Items[i].SubItems.Add(Sex);
                lsvLichSu.Items[i].SubItems.Add(docdulieu[3].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[4].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[5].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[6].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[7].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[8].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[9].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[10].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[11].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[12].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[13].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[14].ToString());
                lsvLichSu.Items[i].SubItems.Add(docdulieu[15].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void lsvLichSu_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            id = lsvLichSu.SelectedItems[0].SubItems[1].Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn xóa à?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                delete(lsvLichSu.SelectedItems[0].SubItems[1].Text);
                hienthi();
            }
            else
            {
                btnXoa.Enabled = false;
                hienthi();
            }
        }
        
        private void delete(string id)
        {
            ketnoi.Open();
            sql = @"DELETE from Inf_LichSu where (Customer_Id =N'" + id + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}
