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
    public partial class Check : Form
    {
        public Check()
        {
            InitializeComponent();
        }

        private async void Check_Load(object sender, EventArgs e)
        {
            pb1.Hide();
            await Task.Delay(2000);
            pb1.Show();
            await Task.Delay(11000);
            WhenStartedcs ws = new WhenStartedcs();
            ws.check();
            this.Hide();
        }
    }
}
