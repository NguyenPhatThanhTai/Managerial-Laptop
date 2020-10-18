using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class WhenStartedcs
    {
        Data_NV dnv = new Data_NV();
        public void check()
        {
            if (Properties.Settings.Default.userName != "")
            {
                string Account = Properties.Settings.Default.userName;
                string Password = Properties.Settings.Default.passUser;
                if (dnv.DangNhap(Account, Password))
                {
                    DanhSachChucNang DSCN = new DanhSachChucNang(int.Parse(dnv.CheckRole(Account)), dnv.GetUserName(Account));
                    DSCN.Show();
                }
            }
            else
            {
                DangNhap dn = new DangNhap();
                dn.Show();
            }
        }
    }
}
