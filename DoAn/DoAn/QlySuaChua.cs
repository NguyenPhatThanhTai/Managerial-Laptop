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
using System.Threading;

namespace DoAn
{
    public partial class Qly_SuaChua : Form
    {
        public Qly_SuaChua()
        {
            InitializeComponent();
        }

        Data_KH dkh;
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
            PanDone.Hide();
            Panload.Hide();
            dkh = new Data_KH();
            hienthi();
        }

        public void hienthi()
        {
            listView2.Items.Clear();
            DataTable dtb = dkh.Load_RP(); 
            i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                var date = DateTime.Parse(row[7].ToString());

                listView2.Items.Add((i + 1).ToString());
                listView2.Items[i].SubItems.Add(row[0].ToString());
                listView2.Items[i].SubItems.Add(row[1].ToString());
                listView2.Items[i].SubItems.Add(row[2].ToString());
                listView2.Items[i].SubItems.Add(row[3].ToString());
                listView2.Items[i].SubItems.Add(row[4].ToString());
                listView2.Items[i].SubItems.Add(row[5].ToString());
                listView2.Items[i].SubItems.Add(row[6].ToString());
                listView2.Items[i].SubItems.Add(date.ToString("dd/MM/yyyy"));
                listView2.Items[i].SubItems.Add(row[8].ToString());
                i++;
            }
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems[0].SubItems[5].Text == Name)
            {
                btnNhanDon.Text = "Tiếp tục đơn";
            }
            else
            {
                btnNhanDon.Text = "Nhận đơn này";
            }
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
            DialogResult dialog = MessageBox.Show("Cập nhật ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                btnDone.Enabled = true;
                dkh.Update_RP(txtTenMay.Text, txtTinhTrang.Text, txtCanSua.Text, txtHenSua.Text, txtDateHen.Text, txtSoTien.Text, txtMaSuaChua.Text);
                hienthi();
            }
            else
            {
                hienthi();
            }
        }

        private void btnNhanDon_Click(object sender, EventArgs e)
        {
            if(listView2.SelectedItems[0].SubItems[5].Text == Name)
            {
                Enable(true);
                listView2.Enabled = false;
                MessageBox.Show("Đã tiếp tục đơn !");
                btnNhanDon.Enabled = false;
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
                        dkh.Update_NhanDon(Name, txtMaSuaChua.Text);
                        hienthi();
                        txtNVTN.Text = Name;
                    }
                }
            }
        }

        private void Enable(bool a)
        {
            btnDone.Enabled = a;
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

        private async void btnDone_Click(object sender, EventArgs e)
        {
            //Sửa lấy ngay
            //Hẹn ngày lấy
            DialogResult dialog = MessageBox.Show("Xác nhận hoàn thành đơn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                hienthi();
            }
            else
            {
                Panload.Show();
                Enable(false);
                dkh.Done_RP(txtMaSuaChua.Text, txtTenMay.Text, txtCanSua.Text, txtSoTien.Text, txtHenSua.Text);
                await Task.Delay (5000);
                Panload.Hide();
                PanDone.Show();
                await Task.Delay(3000);
                PanDone.Hide();
                btnNhanDon.Enabled = true;
                hienthi();
                listView2.Enabled = true;
                Enable(false);
                Clear();
            }
        }
    }
}
