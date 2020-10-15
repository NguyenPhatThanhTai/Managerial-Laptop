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
        public QlyLinhKien()
        {
            InitializeComponent();
        }

        private void QlyLinhKien_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            txtLoc.Text = "Acer";
            hienthi();
        }

        string chuoiketnoi = @"Data Source=DESKTOP-G2HJKI8\SQLEXPRESS;Initial Catalog=ProjectOne;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string time = DateTime.Now.ToString("ddd/MM/yyyy");
        string day = DateTime.Now.ToString("dd");
        string Min = DateTime.Now.ToString("mm");
        string sec = DateTime.Now.ToString("ss");
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
            ketnoi.Close();
            ketnoi.Open();
            sql = @"Select * from Inf_LK";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView3.Items.Add((i + 1).ToString());
                listView3.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[5].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void listView3_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnDelete.Enabled = true;
            listView3.Enabled = false;
            txtTenLinhKien.Text = listView3.SelectedItems[0].SubItems[2].Text;
            txtSoLuong.Text = listView3.SelectedItems[0].SubItems[3].Text;
            txtNhaSanXuat.Text = listView3.SelectedItems[0].SubItems[4].Text;
            txtPrice.Text = listView3.SelectedItems[0].SubItems[5].Text;
        }

        public bool CheckLK(string LK, string nameLK)
        {
            ketnoi.Close();
            ketnoi.Open();
            sql = @"Select * from Inf_LK where (LK_Name = N'" + LK + @"' and LK_Producer = N'"+ nameLK +@"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLinhKien.Text != "" && txtSoLuong.Text != "" && txtNhaSanXuat.Text != "" && txtPrice.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn thêm linh kiện " + txtTenLinhKien.Text + " của nhà sản xuất: " + txtNhaSanXuat.Text + " không !", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    listView3.Items.Clear();
                    if (CheckLK(txtTenLinhKien.Text, txtNhaSanXuat.Text))
                    {
                        ketnoi.Close();
                        ketnoi.Open();
                        sql = @"Insert into Inf_LK (LK_Id, LK_Name, LK_Number, LK_Producer, LK_Price, LK_Time_Add) VALUES(N'LK" + day + "" + Min + "" + sec + @"',N'" + txtTenLinhKien.Text + @"',N'"
                                + txtSoLuong.Text + @"', N'" + txtNhaSanXuat.Text + @"', N'" + txtPrice.Text + @"', N'" + time + @"')";
                        thuchien = new SqlCommand(sql, ketnoi);
                        thuchien.ExecuteNonQuery();
                        ketnoi.Close();
                        txtNhaSanXuat.Text = "";
                        txtTenLinhKien.Text = "";
                        txtPrice.Text = "";
                        txtSoLuong.Text = "";
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại linh kiện " + txtTenLinhKien.Text + " của nhà sản xuất " + txtNhaSanXuat.Text + ", vui lòng chỉnh sửa !");
                        ketnoi.Close();
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
            listView3.Items.Clear();
            hienthi();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (txtLoc.Text == "")
            {
                MessageBox.Show("Không được để rỗng !");
            }
            ketnoi.Close();
            ketnoi.Open();
            sql = @"Select * from Inf_LK where (LK_Producer = N'" + txtLoc.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            if (docdulieu.Read())
            {
                listView3.Items.Clear();
                listView3.Items.Add((i + 1).ToString());
                listView3.Items[i].SubItems.Add(docdulieu[0].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView3.Items[i].SubItems.Add(docdulieu[5].ToString());
                i++;
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
                ketnoi.Open();
                sql = @"Delete from Inf_LK where (LK_Id = N'" + listView3.SelectedItems[0].SubItems[1].Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                docdulieu = thuchien.ExecuteReader();
                listView3.Enabled = true;
                listView3.Items.Clear();
                txtNhaSanXuat.Text = "";
                txtTenLinhKien.Text = "";
                txtPrice.Text = "";
                txtSoLuong.Text = "";
            }
            hienthi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn cập nhật không !", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                ketnoi.Open();
                sql = @"UPDATE Inf_LK set LK_Name = N'" + txtTenLinhKien.Text + @"', LK_Number = N'" + txtSoLuong.Text + @"', 
                    LK_Producer = N'" + txtNhaSanXuat.Text + "', LK_Price = N'" + txtPrice.Text + @"' Where (LK_Id = N'" + listView3.SelectedItems[0].SubItems[1].Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                txtNhaSanXuat.Text = "";
                txtTenLinhKien.Text = "";
                txtPrice.Text = "";
                txtSoLuong.Text = "";
                listView3.Items.Clear();
                listView3.Enabled = true;
            }
            hienthi();
        }

        private void btnFeresh_Click_1(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            hienthi();
        }
    }
}
