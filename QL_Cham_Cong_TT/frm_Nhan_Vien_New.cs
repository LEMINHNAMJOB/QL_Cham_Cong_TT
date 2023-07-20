using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Cham_Cong_TT
{
    public partial class frm_Nhan_Vien_New : Form
    {


        private Timer timer, timer1;
        private int x = 0;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse
);


        private void ButtonColorReset(Button button)
        {
            Color activeColor = Color.FromArgb(31, 27, 48);
            Color btnColor = Color.FromArgb(26, 23, 40);
            btn_Cong_Viec.BackColor = btnColor;
            btn_Thong_Tin.BackColor = btnColor;
            btn_Phong_Ban.BackColor = btnColor;
            btn_Dang_Xuat.BackColor = btnColor;
            button.BackColor = activeColor;
        }

        public frm_Nhan_Vien_New()
        {
            InitializeComponent();

            // Tạo Timer với thời gian delay là 100ms
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            pnlNavindicator.Height = btn_Thong_Tin.Height; pnlNavindicator.Top = btn_Thong_Tin.Top; pnlNavindicator.Left = btn_Thong_Tin.Left;

            ButtonColorReset(btn_Thong_Tin);
            this.pal_Main_NV.Controls.Clear(); frm_Thong_Tin_NV_New FrmDashboard = new frm_Thong_Tin_NV_New() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.pal_Main_NV.Controls.Add(FrmDashboard); FrmDashboard.Show();

        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

     

    private void timer_Tick(object sender, EventArgs e)
        {
            label7.Left += 1;
            label6.Left += 1;
            if (label6.Left >= this.Width)
            {
                label6.Left = -label6.Width;
            }
            if (label7.Left >= this.Width)
            {
                label7.Left = -label7.Width;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thoát ?", "Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đăng xuất","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dl == DialogResult.Yes)
            {
                this.Hide();
                frm_Dang_Nhap frm_Dang_Nhap = new frm_Dang_Nhap();
                frm_Dang_Nhap.Show();
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_Nhan_Vien_New_Load(object sender, EventArgs e)
        {
            
            ConnectData c = new ConnectData();
            c.connect();

            SqlCommand cmd = new SqlCommand("select * from Nhan_Vien, Phong_Ban, Chuc_Vu where Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'", c.conn);
            
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                lbl_manv.Text = "MNV : " + frm_Dang_Nhap.id_Nhan_Vien;
                lbl_sex.Text = "Sex : " + reader["Gioi_Tinh"].ToString();
                lbl_ten.Text = "Tên : " + reader["Ho_Ten"].ToString();
                lbl_phongban.Text = "Phòng Ban : " + reader["Ten_Phong_Ban"].ToString();
                lbl_chucvu.Text = "Chức Vụ : " + reader["Ten_Chuc_Vu"].ToString();
                
            }
            reader.Close();

            frm_Thong_Tin_NV_New frm_Thong_Tin_NV_New = new frm_Thong_Tin_NV_New();
            frm_Thong_Tin_NV_New.TopLevel = false;
            frm_Thong_Tin_NV_New.AutoScroll = true;

            this.pal_Main_NV.Controls.Clear();
            this.pal_Main_NV.Controls.Add(frm_Thong_Tin_NV_New);
            frm_Thong_Tin_NV_New.Show();
            ButtonColorReset(btn_Thong_Tin);
            
        }

        private void btn_Cong_Viec_Click(object sender, EventArgs e)
        {
            frm_Cong_Viec_New frm_Cong_Viec = new frm_Cong_Viec_New();
            frm_Cong_Viec.TopLevel = false;
            frm_Cong_Viec.AutoScroll = true;

            this.pal_Main_NV.Controls.Clear();
            this.pal_Main_NV.Controls.Add(frm_Cong_Viec);
            frm_Cong_Viec.Show();
            ButtonColorReset(btn_Cong_Viec);
            pnlNavindicator.Height = btn_Cong_Viec.Height; pnlNavindicator.Top = btn_Cong_Viec.Top; pnlNavindicator.Left = btn_Cong_Viec.Left;

        }

        private void btn_Thong_Tin_Click(object sender, EventArgs e)
        {
            frm_Thong_Tin_NV_New frm_Thong_Tin_NV_New = new frm_Thong_Tin_NV_New();
            frm_Thong_Tin_NV_New.TopLevel = false;
            frm_Thong_Tin_NV_New.AutoScroll = true;

            this.pal_Main_NV.Controls.Clear();
            this.pal_Main_NV.Controls.Add(frm_Thong_Tin_NV_New);
            frm_Thong_Tin_NV_New.Show();
            ButtonColorReset(btn_Thong_Tin);
            pnlNavindicator.Height = btn_Thong_Tin.Height; pnlNavindicator.Top = btn_Thong_Tin.Top; pnlNavindicator.Left = btn_Thong_Tin.Left;
        }

        private void btn_Diem_Danh_Click(object sender, EventArgs e)
        {

            if (frm_Cong_Viec_New.loai_cong_viec == "FullTime")
            {
                frm_Diem_Danh_Full_New frm_Diem_Danh = new frm_Diem_Danh_Full_New();
                frm_Diem_Danh.TopLevel = false;
                frm_Diem_Danh.AutoScroll = true;

                this.pal_Main_NV.Controls.Clear();
                this.pal_Main_NV.Controls.Add(frm_Diem_Danh);
                frm_Diem_Danh.Show();
                ButtonColorReset(btn_Diem_Danh);
                pnlNavindicator.Height = btn_Diem_Danh.Height; pnlNavindicator.Top = btn_Diem_Danh.Top; pnlNavindicator.Left = btn_Diem_Danh.Left;

            }
            else
            {
                frm_Diem_Danh_Part_New frm_Diem_Danh_Part_New = new frm_Diem_Danh_Part_New();
                frm_Diem_Danh_Part_New.TopLevel = false;
                frm_Diem_Danh_Part_New.AutoScroll = true;

                this.pal_Main_NV.Controls.Clear();
                this.pal_Main_NV.Controls.Add(frm_Diem_Danh_Part_New);
                frm_Diem_Danh_Part_New.Show();
                ButtonColorReset(btn_Diem_Danh);
                pnlNavindicator.Height = btn_Diem_Danh.Height; pnlNavindicator.Top = btn_Diem_Danh.Top; pnlNavindicator.Left = btn_Diem_Danh.Left;

            }
            
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btn_Phong_Ban_Click(object sender, EventArgs e)
        {
            frm_Phong_Ban_NV frm_Phong_Ban_NV = new frm_Phong_Ban_NV();
            frm_Phong_Ban_NV.TopLevel = false;
            frm_Phong_Ban_NV.AutoScroll = true;

            this.pal_Main_NV.Controls.Clear();
            this.pal_Main_NV.Controls.Add(frm_Phong_Ban_NV);
            frm_Phong_Ban_NV.Show();
            ButtonColorReset(btn_Phong_Ban);
            pnlNavindicator.Height = btn_Phong_Ban.Height; pnlNavindicator.Top = btn_Phong_Ban.Top; pnlNavindicator.Left = btn_Phong_Ban.Left;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
