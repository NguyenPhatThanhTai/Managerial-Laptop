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
using System.Net.Mail;
using System.Net;

namespace DoAn
{
    public partial class Qly_SuaChua : Form
    {
        public Qly_SuaChua()
        {
            InitializeComponent();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        string Name;
        string time = DateTime.Now.ToString("yyyy/MM/dd");
        int Role;

        public Qly_SuaChua(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        public void hienthi()
        {
            DatabaseConnection dc = new DatabaseConnection();
            listView2.Items.Clear();
            DataTable dtb = dc.Load_RP(); 
            i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                listView2.Items.Add((i + 1).ToString());
                listView2.Items[i].SubItems.Add(row[0].ToString());
                listView2.Items[i].SubItems.Add(row[1].ToString());
                listView2.Items[i].SubItems.Add(row[2].ToString());
                listView2.Items[i].SubItems.Add(row[3].ToString());
                listView2.Items[i].SubItems.Add(row[4].ToString());
                listView2.Items[i].SubItems.Add(row[5].ToString());
                listView2.Items[i].SubItems.Add(row[6].ToString());
                listView2.Items[i].SubItems.Add(row[7].ToString());
                listView2.Items[i].SubItems.Add(row[8].ToString());
                i++;
            }
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            btnNhanDon.Enabled = true;
            txtMaSuaChua.Text = listView2.SelectedItems[0].SubItems[1].Text;
            txtTenKhachHang.Text = listView2.SelectedItems[0].SubItems[2].Text;
            txtTenMay.Text = listView2.SelectedItems[0].SubItems[3].Text;
            txtTinhTrang.Text = listView2.SelectedItems[0].SubItems[4].Text;
            txtNVTN.Text = listView2.SelectedItems[0].SubItems[5].Text;
            txtCanSua.Text = listView2.SelectedItems[0].SubItems[6].Text;
            txtHenSua.Text = listView2.SelectedItems[0].SubItems[7].Text;
            txtDateHen.Text = listView2.SelectedItems[0].SubItems[8].Text;
            txtSoTien.Text = listView2.SelectedItems[0].SubItems[9].Text;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DatabaseConnection dc = new DatabaseConnection();
            DialogResult dialog = MessageBox.Show("Cập nhật ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                btnDone.Enabled = true;
                dc.Update_RP(txtTenMay.Text, txtTinhTrang.Text, txtCanSua.Text, txtHenSua.Text, txtDateHen.Value.ToString("yyyy/MM/dd"), txtSoTien.Text, txtMaSuaChua.Text);
                hienthi();
            }
            else
            {
                hienthi();
            }
        }

        private void btnNhanDon_Click(object sender, EventArgs e)
        {
            DatabaseConnection dc = new DatabaseConnection();
            if(listView2.SelectedItems[0].SubItems[5].Text == Name)
            {
                Enable(true);
                listView2.Enabled = false;
                MessageBox.Show("Đã tiếp tục đơn !");
            }
            else
            {
                if (listView2.SelectedItems[0].SubItems[5].Text != "Chưa biết")
                {
                    MessageBox.Show("Đơn này đã có nhân viên " + listView2.SelectedItems[0].SubItems[5].Text + " nhận rồi, vui lòng chọn đơn khác");
                    hienthi();
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Xác nhận nhận đơn này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        btnNhanDon.Enabled = false;
                        Enable(true);
                        listView2.Enabled = false;
                        dc.Update_NhanDon(Name, txtMaSuaChua.Text);
                        hienthi();
                        txtNVTN.Text = Name;
                    }
                }
            }
        }

        private void Enable(bool a)
        {
            btnUpdate.Enabled = a;
            txtCanSua.Enabled = a;
            txtDateHen.Enabled = a;
            txtHenSua.Enabled = a;
            txtSoTien.Enabled = a;
            txtTenMay.Enabled = a;
            txtTinhTrang.Enabled = a;
        }

        private void Clear()
        {
            txtCanSua.Text = "";
            txtDateHen.Text = "";
            txtMaSuaChua.Text = "";
            txtNVTN.Text = "";
            txtSoTien.Text = "";
            txtTenMay.Text = "";
            txtTinhTrang.Text = "";
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DatabaseConnection dc = new DatabaseConnection();
            //Sửa lấy ngay
            //Hẹn ngày lấy
            DialogResult dialog = MessageBox.Show("Xác nhận hoàn thành đơn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                hienthi();
            }
            else
            {
                //string Repair_Id, string Laptop_Name, string Repair_Reason, string Repair_Money, string Repair_Appoinment
                dc.Done_RP(txtMaSuaChua.Text, txtTenMay.Text, txtCanSua.Text, txtSoTien.Text, txtHenSua.Text);
                hienthi();
                listView2.Enabled = true;
                Enable(false);
                Clear();
            }
        }
    }
}
