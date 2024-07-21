using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bida.BUS;
using Bida.DTO;

namespace Bida
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }

        public static void showFormMain(NhanVien nv)
        {
            frmMain frm = new frmMain(nv);
            frm.ShowDialog();
        }
      

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            Boolean kt = new NhanVienBUS().ValidateNv(user, pass);
            if (kt == true)
            {
                NhanVien nv = new NhanVienBUS().GetNhanVienbyID(user);

                frmMain a = new frmMain(nv);
                a.Show();
                this.Hide();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(this, "Bạn đã nhập sai tài khoản hoặc mật khảu bạn có muốn tiếp tục", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                txtUser.Text = "";
                txtPass.Text = "";
                if (dialogResult == DialogResult.Yes)
                {
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }

        }
    }
}