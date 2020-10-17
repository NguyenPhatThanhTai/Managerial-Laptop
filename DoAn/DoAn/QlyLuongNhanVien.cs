using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class QlyLuongNhanVien : Form
    {
        public QlyLuongNhanVien()
        {
            InitializeComponent();
        }

        Data_NV dnv;
        int Role;
        string name;
        int i = 0;

        public QlyLuongNhanVien(int Role, string name) : this()
        {
            this.Role = Role;
            this.name = name;
        }

        private void LuongNhanVien_Load(object sender, EventArgs e)
        {
            dnv = new Data_NV();
            hienthi();
        }

        public void hienthi()
        {
            lsvLuong.Items.Clear();
            DataTable dtb = dnv.Load_Salary();
            i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                lsvLuong.Items.Add((i + 1).ToString());
                lsvLuong.Items[i].SubItems.Add(row[0].ToString());
                lsvLuong.Items[i].SubItems.Add(string.Format("{0:#,###}", row[1].ToString()));   
                lsvLuong.Items[i].SubItems.Add(string.Format("{0:#,###}", row[2].ToString()));
                lsvLuong.Items[i].SubItems.Add(string.Format("{0:#,###}", row[3].ToString()));
                lsvLuong.Items[i].SubItems.Add(string.Format("{0:#,###}", row[4].ToString()));
                i++;
            }
        }

        private void lsvLuong_Click(object sender, EventArgs e)
        {
            Clear(true);
            lsvLuong.Enabled = false;
            txtMaNV.Text = lsvLuong.SelectedItems[0].SubItems[1].Text;
            txtLuongCoBan.Text = lsvLuong.SelectedItems[0].SubItems[2].Text;
            txtLuongTheoGio.Text = lsvLuong.SelectedItems[0].SubItems[3].Text;
            txtLamNgoaiGio.Text = lsvLuong.SelectedItems[0].SubItems[4].Text;
            txtTienThuong.Text = lsvLuong.SelectedItems[0].SubItems[5].Text;
            if (lsvLuong.SelectedItems[0].SubItems[3].Text == "" && lsvLuong.SelectedItems[0].SubItems[4].Text == "" && lsvLuong.SelectedItems[0].SubItems[5].Text == "" &&
                        lsvLuong.SelectedItems[0].SubItems[6].Text == "")
            {
                MessageBox.Show("Nhân viên này vẫn chưa cài đặt các thông số lương !");
                txtTongLuong.Text = "";
            }
            else
            {
                int TienCoBan = int.Parse(lsvLuong.SelectedItems[0].SubItems[2].Text);
                int TienThuong = int.Parse(lsvLuong.SelectedItems[0].SubItems[4].Text);
                int LamNgoaiGio = int.Parse(lsvLuong.SelectedItems[0].SubItems[5].Text);
                int TongLuong = TienCoBan + TienThuong + LamNgoaiGio;
                txtTongLuong.Text = string.Format("{0:#,###}VND", TongLuong.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear(false);
            txtMaNV.Text = "";
            txtLuongCoBan.Text = "";
            txtLuongTheoGio.Text = "";
            txtTienThuong.Text = "";
            txtLamNgoaiGio.Text = "";
            txtTongLuong.Text = "";
            hienthi();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                hienthi();
            }
            else
            {
                foreach (ListViewItem item in lsvLuong.Items)
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

        private void LuongNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
            DialogResult dialog = MessageBox.Show("Bạn có muốn cập nhật không !", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                lsvLuong.Enabled = true;
                dnv.Update_Salary(txtLuongCoBan.Text, txtLuongTheoGio.Text, txtLamNgoaiGio.Text, txtTienThuong.Text, txtMaNV.Text);
                hienthi();
            }
            else
            {
                hienthi();
            }
        }

        private void Clear(bool Bool)
        {
            lsvLuong.Enabled = true;
            btnUpdate.Enabled = Bool;
            btnClear.Enabled = Bool;
            txtLuongCoBan.Enabled = Bool;
            txtLuongTheoGio.Enabled = Bool;
            txtTienThuong.Enabled = Bool;
            txtLamNgoaiGio.Enabled = Bool;
        }
    }
}
