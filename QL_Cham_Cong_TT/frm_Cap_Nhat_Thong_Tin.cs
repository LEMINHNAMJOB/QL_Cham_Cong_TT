using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Cham_Cong_TT
{
    public partial class frm_Cap_Nhat_Thong_Tin : Form
    {
        private Timer timer;
        private int x = 0;

        public frm_Cap_Nhat_Thong_Tin()
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

        private void frm_Cap_Nhat_Thong_Tin_Load(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();
            string sql = "select Ho_Ten from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_taikhoan = "select Tai_Khoan from Nguoi_Dung where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_ngaysinh = "select Ngay_Sinh from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_gioitinh = "select Gioi_Tinh from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_quequan = "select Que_Quan from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_diachihientai = "select Dia_Chi_Hien_Tai from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_dantoc = "select Dan_Toc from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_cccd = "select CCCD from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_gmail = "select Gmail from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_dienthoai = "select SDT from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";


            SqlCommand th = new SqlCommand(sql, c.conn);
            SqlCommand th1 = new SqlCommand(sql_taikhoan, c.conn);
            SqlCommand th2= new SqlCommand(sql_ngaysinh, c.conn);
            SqlCommand th3 = new SqlCommand(sql_gioitinh, c.conn);
            SqlCommand th4 = new SqlCommand(sql_quequan, c.conn);
            SqlCommand th5 = new SqlCommand(sql_diachihientai, c.conn);
            SqlCommand th6 = new SqlCommand(sql_dantoc, c.conn);
            SqlCommand th7 = new SqlCommand(sql_cccd, c.conn);
            SqlCommand th8 = new SqlCommand(sql_gmail, c.conn);
            SqlCommand th9 = new SqlCommand(sql_dienthoai, c.conn);

            lbl_manv.Text = frm_Dang_Nhap.id_Nhan_Vien;
            txt_taikhoan.Text = Convert.ToString(th1.ExecuteScalar());
            lbl_ten.Text = Convert.ToString(th.ExecuteScalar());
            datepk_ngaysinh.Text = Convert.ToString(th2.ExecuteScalar());
            cmb_gioitinh.Text = Convert.ToString(th3.ExecuteScalar());
            txt_quequan.Text = Convert.ToString(th4.ExecuteScalar());
            txt_diachi.Text = Convert.ToString(th5.ExecuteScalar());
            txt_dantoc.Text = Convert.ToString(th6.ExecuteScalar());
            txt_cccd.Text = Convert.ToString(th7.ExecuteScalar());
            txt_gmail.Text = Convert.ToString(th8.ExecuteScalar());
            txt_sdt.Text = Convert.ToString(th9.ExecuteScalar());
            LoadImage();
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
                        pictb_anh.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_chonanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictb_anh.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();
            SqlCommand th = new SqlCommand("update Nhan_Vien set Hinh_Anh=@img where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'", c.conn);
            MemoryStream ms = new MemoryStream();
            pictb_anh.Image.Save(ms, pictb_anh.Image.RawFormat);
            byte[] img = ms.ToArray();


            th.Parameters.AddWithValue("@img", img);
            int i = th.ExecuteNonQuery();
            c.conn.Close();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            frm_Nhan_Vien frm_Nhan_Vien = new frm_Nhan_Vien();
            frm_Nhan_Vien.Show();
            this.Close();
        }

        private void chk_hien_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_hien.Checked)
            {
                txt_taikhoan.PasswordChar = '\0';
            }
            else
            {
                txt_taikhoan.PasswordChar = '*';
            }
        }
    }
}
