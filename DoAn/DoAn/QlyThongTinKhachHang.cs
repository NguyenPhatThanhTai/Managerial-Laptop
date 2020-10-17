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
using Microsoft.SqlServer.Server;

namespace DoAn
{
    public partial class QlyThongTinKhachHang : Form
    {
        public QlyThongTinKhachHang()
        {
            InitializeComponent();
        }

        Data_KH dkh;
        int Role;
        string Sex;
        string Name;
        int i = 0;

        public QlyThongTinKhachHang(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }

        private void QlySuaChua_Load(object sender, EventArgs e)
        {
            dkh = new Data_KH();
            hienthi();
        }

        public void hienthi()
        {
            listView1.Items.Clear();
            DataTable dtb = dkh.Load_KH();
            i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                if (row[2].ToString() == "1")
                {
                    Sex = "Nam";
                }
                else if (row[2].ToString() == "2")
                {
                    Sex = "Nữ";
                }
                else
                {
                    Sex = "Khác";
                }

                var date = DateTime.Parse(row[3].ToString());
                var date2 = DateTime.Parse(row[6].ToString());

                listView1.Items.Add((i + 1).ToString());
                listView1.Items[i].SubItems.Add(row[0].ToString());
                listView1.Items[i].SubItems.Add(row[1].ToString());
                listView1.Items[i].SubItems.Add(Sex);
                listView1.Items[i].SubItems.Add(date.ToString("dd/MM/yyyy"));
                listView1.Items[i].SubItems.Add(row[4].ToString());
                listView1.Items[i].SubItems.Add(row[5].ToString());
                listView1.Items[i].SubItems.Add(date2.ToString("dd/MM/yyyy"));
                i++;
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
                listView1.Enabled = false;
                txtMaKhachHang.Enabled = false;
                txtThoiGian.Enabled = false;
                btnSua.Enabled = true;
                btnDelete.Enabled = true;
                btnThem.Enabled = false;
                txtMaKhachHang.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtHoTen.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtGioiTinh.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txtBirth.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txtEmail.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txtSDT.Text = listView1.SelectedItems[0].SubItems[6].Text;
                txtThoiGian.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text != "" && txtEmail.Text != "" && txtSDT.Text != "" && txtGioiTinh.Text != "" && txtBirth.Text != "" && txtEmail.Text != ""
                                && txtSDT.Text != "") 
            {
                DialogResult dialog = MessageBox.Show("Xác nhận thêm khách hàng " + txtHoTen.Text + " ?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    if (dkh.Check_KH(txtHoTen.Text))
                    {
                        dkh.Insert_KH(txtHoTen.Text, txtGioiTinh.Text, txtBirth.Value.ToString("yyyy/MM/dd"), txtEmail.Text, txtSDT.Text);
                        hienthi();
                        i++;
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại khách hàng này rồi, vui lòng cập nhật hoặc xóa đi !");
                        hienthi();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text != "" && txtEmail.Text != "" && txtSDT.Text != "" && txtGioiTinh.Text != "" && txtBirth.Text != "" && txtEmail.Text != ""
                    && txtSDT.Text != "")
            {
                btnSua.Enabled = false;
                btnDelete.Enabled = false;
                btnThem.Enabled = true;
                listView1.Items.Clear();
                dkh.Update_KH(txtHoTen.Text, txtGioiTinh.Text, txtBirth.Value.ToString("yyyy/MM/dd"), txtEmail.Text, txtSDT.Text, txtMaKhachHang.Text);
                hienthi();
                listView1.Enabled = true;
                clear();
            }
            else
            {
                MessageBox.Show("Không được để rỗng !");
;            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                hienthi();
            }
            else
            {
                foreach (ListViewItem item in listView1.Items)
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                        if (subitem.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            item.BackColor = SystemColors.Highlight;
                            item.ForeColor = SystemColors.HighlightText;
                            break;
                        }
            }
        }

        private void btnFeresh_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listView1.Enabled = true;
            btnSua.Enabled = false;
            btnDelete.Enabled = false;
            btnThem.Enabled = true;
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtGioiTinh.Text = "Nam";
            txtMaKhachHang.Text = "";
            txtThoiGian.Text = "";
        }

        private void QlySuaChua_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa khách hàng " + txtHoTen.Text + " không !", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                listView1.Enabled = true;
                dkh.Delete_KH(txtMaKhachHang.Text);
                clear();
                hienthi();
                btnThem.Enabled = true;
            }
            else
            {
                hienthi();
            }
        }

        private void clear()
        {
            txtHoTen.Text = "";
            txtGioiTinh.Text = "Nam";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtMaKhachHang.Text = "";
            txtThoiGian.Text = "";
        }
    }
}
