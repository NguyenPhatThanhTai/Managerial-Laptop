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
    public partial class QlyKeToan : Form
    {
        public QlyKeToan()
        {
            InitializeComponent();
        }

        Data_KT dkt;

        private void QlyKeToan_Load(object sender, EventArgs e)
        {
            dkt = new Data_KT();
            hienthi();
        }

        private void hienthi()
        {
            long Money = 0;
            lsvKeToan.Items.Clear();
            DataTable dtb = dkt.Load_KT();
            int i = 0;
            foreach(DataRow row in dtb.Rows)
            {
                var date1 = DateTime.Parse(row[1].ToString());
                var date2 = DateTime.Parse(row[2].ToString());
                lsvKeToan.Items.Add((i + 1).ToString());
                lsvKeToan.Items[i].SubItems.Add(row[0].ToString());
                lsvKeToan.Items[i].SubItems.Add(date1.ToString("dd/MM/yyyy"));
                lsvKeToan.Items[i].SubItems.Add(date2.ToString("dd/MM/yyyy"));
                lsvKeToan.Items[i].SubItems.Add(String.Format("{0:#,###} VND", row[3].ToString()));
                Money += int.Parse(row[3].ToString());
                i++;
            }

            lbTongTien.Text = String.Format("{0:#,###} VND", Money.ToString());
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            long Money = 0;
            lsvKeToan.Items.Clear();
            DateTime date1 = DateTime.Parse(dtp1.Text);
            DateTime date2 = DateTime.Parse(dtp2.Text);
            DataTable dtb = dkt.DataBetweenDate(date1.ToString("yyyy/MM/dd"), date2.ToString("yyyy/MM/dd"));
            int i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                var date11 = DateTime.Parse(row[1].ToString());
                var date22 = DateTime.Parse(row[2].ToString());
                lsvKeToan.Items.Add((i + 1).ToString());
                lsvKeToan.Items[i].SubItems.Add(row[0].ToString());
                lsvKeToan.Items[i].SubItems.Add(date11.ToString("dd/MM/yyyy"));
                lsvKeToan.Items[i].SubItems.Add(date22.ToString("dd/MM/yyyy"));
                lsvKeToan.Items[i].SubItems.Add(String.Format("{0:#,###} VND", row[3].ToString()));
                Money += int.Parse(row[3].ToString());
                i++;
            }
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            long Money = 0;
            lsvKeToan.Items.Clear();
            DateTime date1 = DateTime.Parse(dtp1.Text);
            DateTime date2 = DateTime.Parse(dtp2.Text);
            DataTable dtb = dkt.DataBetweenDate(date1.ToString("yyyy/MM/dd"), date2.ToString("yyyy/MM/dd"));
            int i = 0;
            foreach (DataRow row in dtb.Rows)
            {
                var date11 = DateTime.Parse(row[1].ToString());
                var date22 = DateTime.Parse(row[2].ToString());
                lsvKeToan.Items.Add((i + 1).ToString());
                lsvKeToan.Items[i].SubItems.Add(row[0].ToString());
                lsvKeToan.Items[i].SubItems.Add(date11.ToString("dd/MM/yyyy"));
                lsvKeToan.Items[i].SubItems.Add(date22.ToString("dd/MM/yyyy"));
                lsvKeToan.Items[i].SubItems.Add(String.Format("{0:#,###} VND", row[3].ToString()));
                Money += int.Parse(row[3].ToString());
                i++;
            }
        }
    }
}
