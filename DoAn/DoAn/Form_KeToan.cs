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
    public partial class QuanLyKeToan : Form
    {
        public QuanLyKeToan()
        {
            InitializeComponent();
        }

        int Role;
        string Name;

        public QuanLyKeToan(int Role, string Name) : this()
        {
            this.Role = Role;
            this.Name = Name;
        }

        private void QuanLyKeToan_Load(object sender, EventArgs e)
        {
            QlyKeToan f = new QlyKeToan();
            AddToForm(f);
        }

        private void AddToForm(Form f)
        {
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.GboxContain.Controls.Clear();
            this.GboxContain.Controls.Add(f);
            f.Show();
        }

        private void thôngTinChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QlyKeToan f = new QlyKeToan();
            AddToForm(f);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DanhSachChucNang dscn = new DanhSachChucNang(Role, Name);
            dscn.Show();
            this.Hide();

        }
    }
}
