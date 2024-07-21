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
    public partial class frmMain : Form
    {
        private NhanVien nhanvien;
        public frmMain(NhanVien nv)
        {
            InitializeComponent();
            this.nhanvien = nv;
        }
        public static void showFormBan(Ban b, NhanVien nv)
        {
            frmBan frm = new frmBan(b,nv);
            frm.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getTable1();
            getTable2();
            lblNV.Text = nhanvien.TenNv;

        }

        private void getTable1()
        {
            List<Ban> a = new List<Ban>(new BanBUS().GetListBan());

            int d = 0;
            int c = 0;
            int r = 6;

            for (int i = 0; i < a.Count; i++)
            {
                Ban ban = a[i];
                if (ban.KhuVuc1 == 1)
                {

                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();

                    this.metroTabPage1.Controls.Add(btn);

                    btn.Size = new System.Drawing.Size(83, 147);
                    btn.TabIndex = 2;
                    btn.Text = "Bàn " + a[i].Maban1;
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    btn.UseVisualStyleBackColor = false;
                    if (a[i].TinhTrang1 == false)
                    {
                        if (a[i].LoaiBan1 == false)
                        {
                            btn.BackColor = System.Drawing.Color.Aqua;
                        }
                        else
                        { 
                            btn.BackColor = System.Drawing.Color.SpringGreen;
                        }
                        
                    }
                    else
                    {
                        if (a[i].LoaiBan1 == false)
                        {
                            btn.BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            btn.BackColor = System.Drawing.Color.Red;
                        }
                    }

                    btn.Click += (s, e) =>
                    {
                        frmBan frm = new frmBan(ban, nhanvien);
                        frm.Show();
                        this.Close();
                    };
                    if (r > 0)
                    {
                        btn.Left = c*120;
                        c = c + 1;
                        btn.Top = d*150;
                        r--;
                    }
                    else
                    {
                        r = 6;
                        d++;
                        c = 0;
                        btn.Left = c*120;
                        c++;
                        btn.Top = d*150;
                        r--;
                    }

                }
            }
        }
        
        private void getTable2()
        {
            List<Ban> a = new List<Ban>(new BanBUS().GetListBan());

            int d = 0;
            int c = 0;
            int r = 6;

            for (int i = 0; i < a.Count; i++)
            {
                Ban ban = a[i];
                if (ban.KhuVuc1 == 2)
                {

                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();

                    this.metroTabPage2.Controls.Add(btn);

                    btn.Size = new System.Drawing.Size(83, 147);
                    btn.TabIndex = 2;
                    btn.Text = "Bàn " + a[i].Maban1;
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    btn.UseVisualStyleBackColor = false;
                    if (a[i].TinhTrang1 == false)
                    {
                        if (a[i].LoaiBan1 == false)
                        {
                            btn.BackColor = System.Drawing.Color.Aqua;
                        }
                        else
                        {
                            btn.BackColor = System.Drawing.Color.SpringGreen;
                        }
                    }
                    else
                    {
                        if (a[i].LoaiBan1 == false)
                        {
                            btn.BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            btn.BackColor = System.Drawing.Color.Red;
                        }
                    }


                    btn.Click += (s, e) =>
                    {
                        frmBan frm = new frmBan(ban, nhanvien);
                        frm.Show();
                        this.Close();
                    };
                    if (r > 0)
                    {
                        btn.Left = c*120;
                        c = c + 1;
                        btn.Top = d*150;
                        r--;
                    }
                    else
                    {

                        r = 6;
                        d++;
                        c = 0;
                        btn.Left = c*120;
                        c++;
                        btn.Top = d*150;
                        r--;
                    }

                }
            }
        }
     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCreateBan a = new frmCreateBan(nhanvien);
            a.Show();
            this.Close();
        }
    }
}
