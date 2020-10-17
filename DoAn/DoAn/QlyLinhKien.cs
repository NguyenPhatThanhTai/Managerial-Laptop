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
    public partial class QlyLinhKien : Form
    {
        Data_LK dlk;
        public QlyLinhKien()
        {
            InitializeComponent();
        }

        private void QlyLinhKien_Load(object sender, EventArgs e)
        {
            dlk = new Data_LK();
            txtLoc.Text = "Acer";
            hienthi();
        }
        int Role;
        string Name;
        int i = 0;


        public QlyLinhKien(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }
        public void hienthi()
        {
            listView3.Items.Clear();
            i = 0;
            DataTable dtb = dlk.Load_LK();
            foreach (DataRow row in dtb.Rows)
            {
                var date = DateTime.Parse(row[5].ToString());
                listView3.Items.Add((i + 1).ToString());
                listView3.Items[i].SubItems.Add(row[0].ToString());
                listView3.Items[i].SubItems.Add(row[1].ToString());
                listView3.Items[i].SubItems.Add(row[2].ToString());
                listView3.Items[i].SubItems.Add(row[3].ToString());
                listView3.Items[i].SubItems.Add(row[4].ToString());
                listView3.Items[i].SubItems.Add(date.ToString("dd/MM/yyyy"));
                i++;
            }
        }

        private void listView3_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnDelete.Enabled = true;
            listView3.Enabled = false;
            txtTenLinhKien.Text = listView3.SelectedItems[0].SubItems[2].Text;
            txtSoLuong.Text = listView3.SelectedItems[0].SubItems[3].Text;
            txtNhaSanXuat.Text = listView3.SelectedItems[0].SubItems[4].Text;
            txtPrice.Text = listView3.SelectedItems[0].SubItems[5].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLinhKien.Text != "" && txtSoLuong.Text != "" && txtNhaSanXuat.Text != "" && txtPrice.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn thêm linh kiện " + txtTenLinhKien.Text + " của nhà sản xuất: " + txtNhaSanXuat.Text + " không !", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    listView3.Items.Clear();
                    if (dlk.Check_LK(txtTenLinhKien.Text, txtNhaSanXuat.Text))
                    {
                        dlk.Insert_LK(txtTenLinhKien.Text, txtSoLuong.Text, txtNhaSanXuat.Text, txtPrice.Text);
                        txtNhaSanXuat.Text = "";
                        txtTenLinhKien.Text = "";
                        txtPrice.Text = "";
                        txtSoLuong.Text = "";
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại linh kiện " + txtTenLinhKien.Text + " của nhà sản xuất " + txtNhaSanXuat.Text + ", vui lòng chỉnh sửa !");
                        hienthi();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listView3.Enabled = true;
            btnDelete.Enabled = false;
            btnSua.Enabled = false;
            txtTenLinhKien.Text = "";
            txtSoLuong.Text = "";
            txtNhaSanXuat.Text = "";
            txtPrice.Text = "";
        }

        private void btnTurnBack_Click(object sender, EventArgs e)
        {
            DanhSachChucNang DSCN = new DanhSachChucNang(Role, Name);
            DSCN.Show();
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                hienthi();
            }
            else
            {
                foreach (ListViewItem item in listView3.Items)
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (txtLoc.Text == "")
            {
                MessageBox.Show("Không được để rỗng !");
            }
            listView3.Items.Clear();
            i = 0;
            DataTable dtb = dlk.Classify_LK(txtLoc.Text);
            if (dtb.Rows.Count != 0)
            {
                foreach (DataRow row in dtb.Rows)
                {
                    listView3.Items.Add((i + 1).ToString());
                    listView3.Items[i].SubItems.Add(row[0].ToString());
                    listView3.Items[i].SubItems.Add(row[1].ToString());
                    listView3.Items[i].SubItems.Add(row[2].ToString());
                    listView3.Items[i].SubItems.Add(row[3].ToString());
                    listView3.Items[i].SubItems.Add(row[4].ToString());
                    listView3.Items[i].SubItems.Add(row[5].ToString());
                    i++;
                }
            }
            else
            {
                listView3.Items.Clear();
                MessageBox.Show("Chưa có linh kiện hoặc sai tên của nhà sản xuất " + txtLoc.Text + " vui lòng kiểm tra lại !");
                hienthi();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa linh kiện " + txtTenLinhKien.Text + " của nhà sản xuất: " + txtNhaSanXuat.Text + " không !", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                dlk.Delete_LK(listView3.SelectedItems[0].SubItems[1].Text);
                listView3.Enabled = true;
                listView3.Items.Clear();
                btnThem.Enabled = true;
                clear();
            }
            hienthi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string LK_ID = listView3.SelectedItems[0].SubItems[1].Text;
            DialogResult dialog = MessageBox.Show("Bạn có muốn cập nhật không !", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (dlk.Check_LK(txtTenLinhKien.Text, txtNhaSanXuat.Text))
                {
                    dlk.Update_LK(txtTenLinhKien.Text, txtSoLuong.Text, txtNhaSanXuat.Text, txtPrice.Text, LK_ID);
                    clear();
                    listView3.Items.Clear();
                    listView3.Enabled = true;
                    btnThem.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Đã tồn tại linh kiện " + txtTenLinhKien.Text + " của nhà sản xuất " + txtNhaSanXuat.Text + ", vui lòng kiểm tra lại !");
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnDelete.Enabled = false;
                    btnClear.Enabled = true;
                    listView3.Enabled = true;
                    clear();
                    hienthi();
                }
            }
            hienthi();
        }

        private void btnFeresh_Click_1(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            hienthi();
        }

        private void clear()
        {
            txtNhaSanXuat.Text = "";
            txtTenLinhKien.Text = "";
            txtPrice.Text = "";
            txtSoLuong.Text = "";
        }
    }

}
