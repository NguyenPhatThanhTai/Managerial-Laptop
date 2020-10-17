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
    public partial class QlyTaiKhoanNhanVien : Form
    {
        public QlyTaiKhoanNhanVien()
        {
            InitializeComponent();
        }

        Data_NV dnv;
        string Quyen;
        int i = 0;
        int Role;
        string Name;

        private void QlyTaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            dnv = new Data_NV();
            hienthi();
        }

        public QlyTaiKhoanNhanVien(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }

        public void hienthi()
        {
            lsvAccount.Items.Clear();
            DataTable dtb = dnv.Load_TK();
            i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                if(row[3].ToString() == "1")
                {
                    Quyen = "Admin";
                }
                else
                {
                    Quyen = "Nhân Viên";
                }
                lsvAccount.Items.Add((i + 1).ToString());
                lsvAccount.Items[i].SubItems.Add(row[0].ToString());
                lsvAccount.Items[i].SubItems.Add(row[1].ToString());
                lsvAccount.Items[i].SubItems.Add(row[2].ToString());
                lsvAccount.Items[i].SubItems.Add(Quyen);
                i++;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                hienthi();
            }
            else
            {
                foreach (ListViewItem item in lsvAccount.Items)
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

        private void QlyTaiKhoanNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            Clear(false);
            lsvAccount.Enabled = true;
            DialogResult dialog = MessageBox.Show("Bạn muốn cập nhật à?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                dnv.Update_TK(txtPassword.Text, txtRole.Text, txtMaNv.Text);
            }
            hienthi();
        }

        private void lsvAccount_Click(object sender, EventArgs e)
        {
            lsvAccount.Enabled = false;
            btnClear.Enabled = true;
            btnSua.Enabled = true;
            txtRole.Enabled = true;
            txtPassword.Enabled = true;
            txtMaNv.Text = lsvAccount.SelectedItems[0].SubItems[1].Text;
            txtAccount.Text = lsvAccount.SelectedItems[0].SubItems[2].Text;
            txtPassword.Text = lsvAccount.SelectedItems[0].SubItems[3].Text;
            txtRole.Text = lsvAccount.SelectedItems[0].SubItems[4].Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lsvAccount.Enabled = true;
            Clear(false);
            hienthi();
        }

        private void Clear(bool Bool)
        {
            btnClear.Enabled = Bool;
            btnSua.Enabled = Bool;
            txtRole.Enabled = Bool;
            txtPassword.Enabled = Bool;
            txtAccount.Enabled = Bool;
        }
    }
}
