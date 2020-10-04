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
    public partial class LichSuSuaChua : Form
    {
        public LichSuSuaChua()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=QuanLySuaChuaLaptop;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        string name;
        string Role;

        public LichSuSuaChua(string Role) : this()
        {
            this.Role = Role;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthiLichSu();
        }

        public void hienthiLichSu()
        {
            listView2.Items.Clear();
            ketnoi.Open();
            sql = @"Select * from History";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView2.Items.Add((i + 1).ToString());
                listView2.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[5].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[6].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[7].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[8].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            Delete.Enabled = true;
            name = listView2.SelectedItems[0].SubItems[1].Text;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string sql = @"Delete from History where (name = N'" + name.ToString() + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            ketnoi.Close();
            hienthiLichSu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLySuaChua QLSC = new QuanLySuaChua();
            QLSC.Show();
            this.Hide();
        }

        private void LichSuSuaChua_FormClosing(object sender, FormClosingEventArgs e)
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
