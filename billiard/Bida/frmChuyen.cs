using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bida.BUS;
using Bida.DTO;

namespace Bida
{
    public partial class frmChuyen : Form
    {
        private NhanVien nhanvien;
        private Ban ban;
       
        public frmChuyen(NhanVien nv, Ban b)
        {
            InitializeComponent();
            this.ban = b;
            this.nhanvien = nv;
        }

        private void frmChuyen_Load(object sender, EventArgs e)
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
                Ban ban2 = a[i];
                if (ban2.KhuVuc1 == 1)
                {

                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();

                    this.Tab1.Controls.Add(btn);

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
                        if (ban2.TinhTrang1 == true)
                        {
                            MessageBox.Show(this, "Bàn " + ban2.Maban1 + " đang được người khác chơi vui lòng chọn bàn khác ! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            new BanBUS().chuyenban(ban, ban2);

                            DialogResult dialogResult = MessageBox.Show(this, "Bạn đã chuyển bàn thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frmBan frm = new frmBan(ban2, nhanvien);
                            frm.Show();
                            this.Close();

                        }
                    };
                    if (r > 0)
                    {
                        btn.Left = c * 120;
                        c = c + 1;
                        btn.Top = d * 150;
                        r--;
                    }
                    else
                    {

                        r = 6;
                        d++;
                        c = 0;
                        btn.Left = c * 120;
                        c++;
                        btn.Top = d * 150;
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
                Ban ban2 = a[i];
                if (ban2.KhuVuc1 == 2)
                {

                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();

                    this.Tab2.Controls.Add(btn);

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
                        if (ban2.TinhTrang1 == true)
                        {
                            MessageBox.Show(this, "Bàn " + ban2.Maban1 + " đang được người khác chơi vui lòng chọn bàn khác ! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            new BanBUS().chuyenban(ban, ban2);

                            DialogResult dialogResult = MessageBox.Show(this, "Bạn đã chuyển bàn thành công ! ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frmBan frm = new frmBan(ban2, nhanvien);
                            frm.Show();
                            this.Close();

                        }
                    };
                    if (r > 0)
                    {
                        btn.Left = c * 120;
                        c = c + 1;
                        btn.Top = d * 150;
                        r--;
                    }
                    else
                    {

                        r = 6;
                        d++;
                        c = 0;
                        btn.Left = c * 120;
                        c++;
                        btn.Top = d * 150;
                        r--;
                    }

                }
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan(ban, nhanvien);
            frm.Show();
            this.Close();
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
