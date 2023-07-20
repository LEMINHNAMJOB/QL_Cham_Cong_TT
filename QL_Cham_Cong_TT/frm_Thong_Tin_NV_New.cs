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
    public partial class frm_Thong_Tin_NV_New : Form
    {

        private Timer timer;
        private int x = 0;

        public frm_Thong_Tin_NV_New()
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
            label3.Left += 1;
            label2.Left += 1;
            if (label2.Left >= this.Width)
            {
                label2.Left = -label2.Width;
            }
            if (label3.Left >= this.Width)
            {
                label3.Left = -label3.Width;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void frm_Thong_Tin_NV_New_Load(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();

            SqlCommand cmd = new SqlCommand("select * from Nhan_Vien, Phong_Ban, Chuc_Vu, Cong_Viec where Nhan_Vien.id_Nhan_Vien = Cong_Viec.id_Nhan_Vien and  Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'", c.conn);
            
            SqlDataReader reader = cmd.ExecuteReader();

            lbl_manv.Text = "MNV : " + frm_Dang_Nhap.id_Nhan_Vien;

            try
            {
                while (reader.Read())
                {
                    
                    lbl_gioi_tinh.Text = reader["Gioi_Tinh"].ToString();
                    lbl_ten.Text = "Tên : " + reader["Ho_Ten"].ToString();
                    lbl_phongban.Text = "Phòng Ban : " + reader["Ten_Phong_Ban"].ToString();
                    //lbl_phong_ban.Text = reader["Ten_Phong_Ban"].ToString();
                    lbl_chuc_vu.Text = reader["Ten_Chuc_Vu"].ToString();
                    lbl_ho_ten.Text = reader["Ho_Ten"].ToString();
                    lbl_dien_thoai.Text = reader["SDT"].ToString();
                    lbl_dan_toc.Text = reader["Dan_Toc"].ToString();
                    lbl_que_quan.Text = reader["Que_Quan"].ToString();
                    lbl_dia_chi.Text = reader["Dia_Chi_Hien_Tai"].ToString();
                    lbl_ton_giao.Text = reader["Ton_Giao"].ToString();
                    lbl_ngay_sinh.Text = Convert.ToDateTime(reader["Ngay_Sinh"]).ToString("dd/MM/yyyy");
                    lbl_sdt.Text = reader["SDT"].ToString();
                    //lbl_cong_viec.Text = Convert.ToString(reader["Ten_Cong_Viec"]);
                    //lbl_ngoai_ngu.Text = Convert.ToString(reader["Loai_Ngoai_Ngu"]) + " - " + Convert.ToString(reader["Point"]) + "đ";
                    lbl_trinh_do.Text = Convert.ToString(reader["Trinh_Do"]);
                }
           }
            finally
           {
                // Always call Close when done reading.
             reader.Close();
           }

            SqlCommand cmd1 = new SqlCommand("select * from Nhan_Vien, Ngoai_Ngu where Nhan_Vien.id_Nhan_Vien = Ngoai_Ngu.id_Nhan_Vien and Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'", c.conn);
            
            SqlDataReader reader1 = cmd1.ExecuteReader();

            try
            {
                while (reader1.Read())
                {

                    lbl_ngoai_ngu.Text = Convert.ToString(reader1["Loai_Ngoai_Ngu"]) + " - " + Convert.ToString(reader1["Point"]) + "đ";
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader1.Close();
            }


            LoadImage();
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
