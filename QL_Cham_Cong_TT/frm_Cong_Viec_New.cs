using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Cham_Cong_TT
{
    public partial class frm_Cong_Viec_New : Form
    {

        public static string loai_cong_viec, id_Cong_Viec;
        private Timer timer, timer1;
        private int x = 0;

        public frm_Cong_Viec_New()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
        ConnectData c = new ConnectData();
        private void frm_Cong_Viec_New_Load(object sender, EventArgs e)
        {
            
            c.connect();

            SqlCommand cmd = new SqlCommand("select * from Nhan_Vien, Cong_Viec, Loai_Cong_Viec, Phu_Cap where Nhan_Vien.id_Phu_Cap = Phu_Cap.id_Phu_Cap and Nhan_Vien.id_Nhan_Vien = Cong_Viec.id_Nhan_Vien and Cong_Viec.id_Loai_Cong_Viec = Loai_Cong_Viec.id_Loai_Cong_Viec and Nhan_Vien.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'", c.conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    lbl_loaicongviec.Text = rdr["Ten_Loai_Cong_Viec"].ToString();
                    loai_cong_viec = lbl_loaicongviec.Text;
                    id_Cong_Viec = rdr["id_Cong_Viec"].ToString();
                    lbl_motacongviec.Text = rdr["Mo_Ta_Cong_Viec"].ToString();
                    lbl_tencongviec.Text = rdr["Ten_Cong_Viec"].ToString();

                    DateTime ngayBatDau = Convert.ToDateTime(rdr["Ngay_Bat_Dau"].ToString());
                    lbl_ngaybatdau.Text = ngayBatDau.ToString("dd/MM/yyyy");

                    DateTime ngayKetThuc = Convert.ToDateTime(rdr["Ngay_Ket_Thuc"].ToString());
                    lbl_ngayketthuc.Text = ngayKetThuc.ToString("dd/MM/yyyy");

                    double PhuCap = Convert.ToDouble(rdr["Phu_Cap"].ToString());
                    string PhuCapViet = PhuCap.ToString("N0") + "đ" + " /Tháng";
                    lbl_phucap.Text = PhuCapViet;

                    if (lbl_loaicongviec.Text == "FullTime")
                    {
                        lbl_calam.Text = "Full Ngày";
                    }
                }
            }
            finally
            {
                // Always call Close when done reading.
                rdr.Close();
            }

            /*
            if (rdr.Read())
            {
                lbl_loaicongviec.Text = rdr["Ten_Loai_Cong_Viec"].ToString();
                lbl_motacongviec.Text = rdr["Mo_Ta_Cong_Viec"].ToString();
                lbl_tencongviec.Text = rdr["Ten_Cong_Viec"].ToString();

                DateTime ngayBatDau = Convert.ToDateTime(rdr["Ngay_Bat_Dau"].ToString());
                lbl_ngaybatdau.Text = ngayBatDau.ToString("dd/MM/yyyy");

                DateTime ngayKetThuc = Convert.ToDateTime(rdr["Ngay_Ket_Thuc"].ToString());
                lbl_ngayketthuc.Text = ngayKetThuc.ToString("dd/MM/yyyy");

                double PhuCap = Convert.ToDouble(rdr["Phu_Cap"].ToString());
                string PhuCapViet = PhuCap.ToString("N0") + "đ" + " /Tháng";
                lbl_phucap.Text = PhuCapViet;

                if (lbl_loaicongviec.Text == "FullTime")
                {
                    lbl_calam.Text = "Full Ngày";
                }
            }
            */
            c.disconnect();
            c.connect();

            //string sql_phongban = "select Ten_Phong_Ban from Nhan_Vien,Phong_Ban where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban";
            //SqlCommand th5 = new SqlCommand(sql_phongban, c.conn);
            //lbl_phongban.Text = Convert.ToString(th5.ExecuteScalar());

            SqlCommand cmd1 = new SqlCommand("select * from Nhan_Vien,Chuc_Vu,Phong_Ban,Luong_Full_Time where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Luong_Full_Time.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Luong_Full_Time.id_Phong_Ban = Phong_Ban.id_Phong_Ban", c.conn);

            SqlDataReader rdr1 = cmd1.ExecuteReader();

            try
            {
                if (rdr1.Read())
                {

                    if (lbl_loaicongviec.Text == "FullTime")
                    {
                        lbl_phongban.Text = rdr1["Ten_Phong_Ban"].ToString();
                        double luongfull = Convert.ToDouble(rdr1["Luong_Co_Ban"].ToString());
                        string luongcoban = luongfull.ToString("N0") + "đ";
                        lbl_luong.Text = luongcoban + " /Tháng";
                    }

                }
            }
            finally
            {
                // Always call Close when done reading.
                rdr1.Close();
            }


            SqlCommand cmd2 = new SqlCommand("select * from Nhan_Vien,Phong_Ban,Luong_Part_Time where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Luong_Part_Time.id_Phong_Ban = Phong_Ban.id_Phong_Ban", c.conn);

            SqlDataReader rdr2 = cmd2.ExecuteReader();

            try
            {
                if (rdr2.Read())
                {

                    if (lbl_loaicongviec.Text == "PartTime")
                    {
                        lbl_phongban.Text = rdr2["Ten_Phong_Ban"].ToString();
                        double luongfull = Convert.ToDouble(rdr2["Luong_Tren_Gio"].ToString());
                        string luongcoban = luongfull.ToString("N0") + "đ";
                        lbl_luong.Text = luongcoban + " /Giờ";
                    }

                }
            }
            finally
            {
                // Always call Close when done reading.
                rdr2.Close();
            }


            //select* from Nhan_Vien, Cong_Viec, Loai_Cong_Viec, Phu_Cap, Luong_Full_Time where Chuc_Vu.id_Chuc_Vu = Luong_Full_Time.id_Chuc_Vu and Phong_Ban.id_Phong_Ban = Luong_Full_Time.id_Phong_Ban


            //string luongfull = "select Luong_Co_Ban Nhan_Vien, Loai_Cong_Viec, Phu_Cap, Luong_Full_Time where Chuc_Vu.id_Chuc_Vu = Luong_Full_Time.id_Chuc_Vu and Phong_Ban.id_Phong_Ban = Luong_Full_Time.id_Phong_Ban";
            //SqlCommand th5 = new SqlCommand(sql_phongban, c.conn);
            //lbl_phongban.Text = Convert.ToString(th5.ExecuteScalar());


            SqlCommand cmd3 = new SqlCommand("select * from Cong_Viec, Cham_Cong_Part_Time, Ca_Lam where Cham_Cong_Part_Time.id_Ca_Lam = Ca_Lam.id_Ca_Lam and Cong_Viec.id_Cong_Viec = Cham_Cong_Part_Time.id_Cong_Viec and Cong_Viec.id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'",c.conn);

            SqlDataReader rdr3 = cmd3.ExecuteReader();
            if (rdr3.Read())
            lbl_calam.Text = rdr3["Ten_Ca"].ToString();
            /*
            try
            {
                if (rdr3.Read())
                {
                    if (lbl_loaicongviec.Text == "PartTime")
                    {
                        if (rdr3["Ten_Ca"].ToString() == "Sáng")
                        {
                            string[] tenCa = new string[] { "Sáng" };
                            string tenCaText = string.Join(" - ", tenCa);
                            lbl_calam.Text = tenCaText;
                        }
                        else if (rdr3["Ten_Ca"].ToString() == "Chiều")
                        {
                            string[] tenCa = new string[] { "Chiều" };
                            string tenCaText = string.Join(" - ", tenCa);
                            lbl_calam.Text = tenCaText;
                        }
                        else if (rdr3["Ten_Ca"].ToString() == "Tối")
                        {
                            string[] tenCa = new string[] { "Tối" };
                            string tenCaText = string.Join(" - ", tenCa);
                            lbl_calam.Text = tenCaText;
                        }
                        else if (rdr3["Ten_Ca"].ToString() == "Sáng" && rdr3["Ten_Ca"].ToString() == "Chiều")
                        {
                            string[] tenCa = new string[] { "Sáng", "Chiều" };
                            string tenCaText = string.Join(" - ", tenCa);
                            lbl_calam.Text = tenCaText;
                        }
                        else if (rdr3["Ten_Ca"].ToString() == "Sáng" && rdr3["Ten_Ca"].ToString() == "Tối")
                        {
                            string[] tenCa = new string[] { "Sáng", "Tối" };
                            string tenCaText = string.Join(" - ", tenCa);
                            lbl_calam.Text = tenCaText;
                        }
                        else if (rdr3["Ten_Ca"].ToString() == "Chiều" && rdr3["Ten_Ca"].ToString() == "Tối")
                        {
                            string[] tenCa = new string[] { "Chiều", "Tối" };
                            string tenCaText = string.Join(" - ", tenCa);
                            lbl_calam.Text = tenCaText;
                        }
                        else if (rdr3["Ten_Ca"].ToString() == "Chiều" && rdr3["Ten_Ca"].ToString() == "Tối" && rdr3["Ten_Ca"].ToString() == "Sáng")
                        {
                            string[] tenCa = new string[] { "Sáng", "Chiều", "Tối" };
                            string tenCaText = string.Join(" - ", tenCa);
                            lbl_calam.Text = tenCaText;
                        }
                    }
                    
                }
            }
            finally
            {
                // Always call Close when done reading.
                rdr3.Close();
            }
            */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_now.Text = DateTime.Now.ToString("dd/MM/yyyy"); //Hiển thị thời gian hiện tại
        }

        private void linklbl_luuy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbl_loaicongviec.Text == "PartTime")
            {
                MessageBox.Show("Ca Sáng - Thời Gian : 6h30 đến 11h30\nCa Chiều - Thời Gian : 13h đến 17h\nCa Tối - Thời Gian : 17h30 đến 22h","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Làm 8 Tiếng Chưa Tính Tăng Ca\nNghỉ trưa 1 tiếng rưỡi","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
