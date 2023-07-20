using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace QL_Cham_Cong_TT
{

    public partial class frm_Nhan_Vien : Form
    {
        private Timer timer;
        private int x = 0;

        public frm_Nhan_Vien()
        {
            InitializeComponent();
            // Tạo Timer với thời gian delay là 100ms
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label11.Left += 1;
            label1.Left += 1;
            if (label1.Left >= this.Width)
            {
                label1.Left = -label1.Width;
            }
            if (label11.Left >= this.Width)
            {
                label11.Left = -label1.Width;
            }

        }

        private void LoadImage()
        {
            ConnectData c = new ConnectData();
            c.connect();
            string query = "select Hinh_Anh from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["Hinh_Anh"] != DBNull.Value)
                {
                    byte[] imgData = (byte[])reader["Hinh_Anh"];
                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        pictureBox2.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void frm_Nhan_Vien_Load(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();
            string sql_hoten = "select Ho_Ten from Nhan_Vien where Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_phongban = "select Ten_Phong_Ban from Nhan_Vien,Phong_Ban where Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_chucvu = "select Ten_Chuc_Vu from Nhan_Vien,Chuc_Vu where Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_congviec = "select Ten_Cong_Viec from Nhan_Vien,Cong_Viec where Nhan_Vien.id_Nhan_Vien = Cong_Viec.id_Nhan_Vien and Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_loaicongviec = "select Ten_Loai_Cong_Viec from Nhan_Vien,Cong_Viec,Loai_Cong_Viec where Nhan_Vien.id_Nhan_Vien = Cong_Viec.id_Nhan_Vien and Cong_Viec.id_Loai_Cong_Viec = Loai_Cong_Viec.id_Loai_Cong_Viec and Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            SqlCommand th = new SqlCommand(sql_hoten,c.conn);
            SqlCommand th1 = new SqlCommand(sql_phongban,c.conn);
            SqlCommand th2 = new SqlCommand(sql_chucvu, c.conn);
            SqlCommand th3 = new SqlCommand(sql_congviec, c.conn);
            SqlCommand th4 = new SqlCommand(sql_loaicongviec, c.conn);
            txt_Ma_Nhan_Vien.Text = frm_Dang_Nhap.id_Nhan_Vien;
            txt_Ho_Ten.Text = Convert.ToString(th.ExecuteScalar());
            txt_Phong_Ban.Text = Convert.ToString(th1.ExecuteScalar());
            txt_Chuc_Vu.Text = Convert.ToString(th2.ExecuteScalar());
            txt_Cong_Viec.Text = Convert.ToString(th3.ExecuteScalar());
            txt_Loai_Cong_Viec.Text= Convert.ToString(th4.ExecuteScalar());

            string sql_dienthoai = "select SDT from Nhan_Vien where Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_quequan = "select Que_Quan from Nhan_Vien where Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";

            SqlCommand thdt = new SqlCommand(sql_dienthoai,c.conn);
            SqlCommand thqq = new SqlCommand(sql_quequan, c.conn);
            lbl_manv.Text = "Mã Nhân Viên : " + frm_Dang_Nhap.id_Nhan_Vien;
            lbl_phongban.Text = "Phòng Ban : " + Convert.ToString(th1.ExecuteScalar());
            lbl_ten_the.Text = "Họ Tên : " + Convert.ToString(th.ExecuteScalar());   
            lblsdt.Text = "SDT : " + Convert.ToString(thdt.ExecuteScalar());
            lbl_que_quan.Text = "Quê Quán : " + Convert.ToString(thqq.ExecuteScalar());
            LoadImage();
        }

        private void trưởngPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phiênBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phiên bản này được phát triển bới Lee Nam\nPhiên bản 1.0","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Doi_Mat_Khau frm_Doi_Mat_Khau = new frm_Doi_Mat_Khau();
            frm_Doi_Mat_Khau.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Dang_Nhap frm_Dang_Nhap = new frm_Dang_Nhap();
            frm_Dang_Nhap.Show();
        }

        private void txt_Ho_Ten_TextChanged(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Thong_Tin_Cong_Viec frm_Thong_Tin_Cong_Viec = new frm_Thong_Tin_Cong_Viec();
            frm_Thong_Tin_Cong_Viec.Show();
        }

        private void điểmDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Diem_Rank_Full frm_Diem_Rank = new frm_Diem_Rank_Full();
            frm_Diem_Rank.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            from_test from_Test = new from_test();
            from_Test.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            from_test from_Test2 = new from_test();
            from_Test2.Show();
        }

        private void cậpNhậtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Cap_Nhat_Thong_Tin frm_Cap_Nhat_Thong_Tin = new frm_Cap_Nhat_Thong_Tin();
            frm_Cap_Nhat_Thong_Tin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            from_test from_Test = new from_test();
            from_Test.Show();
        }
    }
}

