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
using DevExpress.XtraEditors.Filtering.Templates;

namespace DoAn
{
    public partial class QlyThongTinNhanVien : Form
    {
        public QlyThongTinNhanVien()
        {
            InitializeComponent();
        }

        Data_NV DNV;
        int Role;
        string Name, PhongBan, Sex;
        int i = 0;

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            DNV = new Data_NV();
            hienthi();
        }

        public QlyThongTinNhanVien(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }

        public void hienthi()
        {
            listView4.Items.Clear();
            DataTable dtb = DNV.Load_NV();
            i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                if(row[2].ToString() == "1")
                {
                    Sex = "Nam";
                }
                else if(row[2].ToString() == "2")
                {
                    Sex = "Nữ";
                }
                else
                {
                    Sex = "Khác";
                }

                if(row[6].ToString() == "1")
                {
                    PhongBan = "Quản lý";       
                }
                else if(row[6].ToString() == "2")
                {
                    PhongBan = "Kỹ Thuật";
                }
                else
                {
                    PhongBan = "Kế Toán";
                }

                listView4.Items.Add((i + 1).ToString());
                listView4.Items[i].SubItems.Add(row[0].ToString());
                listView4.Items[i].SubItems.Add(row[1].ToString());
                listView4.Items[i].SubItems.Add(Sex.ToString());
                listView4.Items[i].SubItems.Add(row[3].ToString());
                listView4.Items[i].SubItems.Add(row[4].ToString());
                listView4.Items[i].SubItems.Add(row[5].ToString());
                listView4.Items[i].SubItems.Add(PhongBan.ToString());
                listView4.Items[i].SubItems.Add(row[7].ToString());
                i++;
            }
        }

        private void listView4_Click(object sender, EventArgs e)
        {
            listView4.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnDelete.Enabled = true;
            listView4.Enabled = false;
            if (listView4.SelectedItems[0].SubItems[2].Text == "Nguyễn Phát Thành Tài")
            {
                btnDelete.Enabled = false;
            }
            txtMaNv.Text = listView4.SelectedItems[0].SubItems[1].Text;
            txtHoTen.Text = listView4.SelectedItems[0].SubItems[2].Text;
            txtGioiTinh.Text = listView4.SelectedItems[0].SubItems[3].Text;
            txtDate.Text = listView4.SelectedItems[0].SubItems[4].Text;
            txtDiaChi.Text = listView4.SelectedItems[0].SubItems[5].Text;
            txtSDT.Text = listView4.SelectedItems[0].SubItems[6].Text;
            txtDepartment.Text = listView4.SelectedItems[0].SubItems[7].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            if (txtHoTen.Text != "" && txtGioiTinh.Text != "" && txtDate.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "")
            {
                listView4.Items.Clear();
                if (DNV.Check_NV(txtHoTen.Text))
                {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn thêm nhân viên: " + txtHoTen.Text + " ở phòng ban: "+ txtDepartment.Text +"  không !", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        DNV.Insert_NV(txtHoTen.Text, txtGioiTinh.Text, txtDate.Value.ToString("yyyy/MM/dd"), txtDiaChi.Text, txtSDT.Text, txtDepartment.Text);
                        listView4.Items.Clear();
                        listView4.Enabled = true;
                        hienthi();
                    }
                    else
                    {
                        listView4.Items.Clear();
                        listView4.Enabled = true;
                        hienthi();
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại nhân viên này rồi, vui lòng cập nhật hoặc xóa đi !");
                    listView4.Enabled = true;
                    hienthi();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DNV.Update_NV(txtHoTen.Text, txtGioiTinh.Text, txtDate.Value.ToString("yyyy/MM/dd"), txtDiaChi.Text, txtSDT.Text, txtDepartment.Text, txtMaNv.Text);
            listView4.Items.Clear();
            hienthi();
            listView4.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnDelete.Enabled = false;
            clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                hienthi();
            }
            else
            {
                foreach (ListViewItem item in listView4.Items)
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
            listView4.Enabled = true;
            clear();
        }

        private void clear()
        {
            txtMaNv.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "Nam";
            txtDate.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtDepartment.Text = "Quản Lý";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DatabaseConnection dc = new DatabaseConnection();
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa nhân viên " + txtHoTen.Text + " ở phòng ban:" + txtDepartment.Text + " không !", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                DNV.Delete_NV(txtMaNv.Text);
                listView4.Items.Clear();
                clear();
            }
            listView4.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnDelete.Enabled = false;
            clear();
            listView4.Items.Clear();
            hienthi();
        }

        private void ThongTinNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
