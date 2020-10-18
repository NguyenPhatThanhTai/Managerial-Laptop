﻿using System;
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

        Data_KH DKH;
        int i = 0;
        string Sex;
        string id;

        private void QlyLichSuSuaChua_Load(object sender, EventArgs e)
        {
            DKH = new Data_KH();
            hienthi();
        }

        public void hienthi()
        {
            lsvLichSu.Items.Clear();
            DataTable dtb = DKH.Load_LS();
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
                lsvLichSu.Items.Add((i + 1).ToString());
                lsvLichSu.Items[i].SubItems.Add(row[0].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[1].ToString());
                lsvLichSu.Items[i].SubItems.Add(Sex);
                lsvLichSu.Items[i].SubItems.Add(date.ToString("dd/MM/yyyy"));
                lsvLichSu.Items[i].SubItems.Add(row[4].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[5].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[6].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[7].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[8].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[9].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[10].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[11].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[12].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[13].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[14].ToString());
                lsvLichSu.Items[i].SubItems.Add(row[15].ToString());
                i++;
            }
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
                DKH.delete(lsvLichSu.SelectedItems[0].SubItems[1].Text);
                hienthi();
            }
            else
            {
                btnXoa.Enabled = false;
                hienthi();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}
