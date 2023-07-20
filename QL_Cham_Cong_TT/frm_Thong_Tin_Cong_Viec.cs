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
    public partial class frm_Thong_Tin_Cong_Viec : Form
    {

        private Timer timer;
        private int x = 0;

        public frm_Thong_Tin_Cong_Viec()
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
            //label11.Left += 1;
            label1.Left += 1;
            if (label1.Left >= this.Width)
            {
                label1.Left = -label1.Width;
            }
            //if (label11.Left >= this.Width)
           // {
           //     label11.Left = -label1.Width;
           //}

        }

        private void frm_Thong_Tin_Cong_Viec_Load(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();
            string sql_macongviec = "select id_Cong_Viec from Cong_Viec where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_tencongviec = "select Ten_Cong_Viec from Cong_Viec where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_ngaybatdau = "select Ngay_Bat_Dau from Cong_Viec where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_ngayketthuc = "select Ngay_Ket_Thuc from Cong_Viec where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";
            string sql_chucvu = "select Ten_Chuc_Vu from Nhan_Vien,Chuc_Vu where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu";
            string sql_phongban = "select Ten_Phong_Ban from Nhan_Vien,Phong_Ban where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban";
            string sql_luongcoban = "select Luong_Co_Ban from Nhan_Vien,Chuc_Vu,Phong_Ban,Luong_Full_Time where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Luong_Full_Time.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Luong_Full_Time.id_Phong_Ban = Phong_Ban.id_Phong_Ban";
            string sql_luongtrengio = "select Luong_Tren_Gio from Nhan_Vien,Phong_Ban,Luong_Part_Time where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Phong_Ban.id_Phong_Ban = Luong_Part_Time.id_Phong_Ban";
            string sql_phucap = "select Phu_Cap from Nhan_Vien,Chuc_Vu,Phong_Ban,Luong_Full_Time,Phu_Cap where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Luong_Full_Time.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Luong_Full_Time.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Phu_Cap.id_Phu_Cap = Luong_Full_Time.id_Phu_Cap";
            string sql_phucappart = "select Phu_Cap from Nhan_Vien,Phong_Ban,Luong_Part_Time,Phu_Cap where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "' and Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and Phong_Ban.id_Phong_Ban = Luong_Part_Time.id_Phong_Ban and Luong_Part_Time.id_Phu_Cap = Phu_Cap.id_Phu_Cap";
            string sql_motacongviec = "select Mo_Ta_Cong_Viec from Cong_Viec where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";

            string sql_loaicongviec = "select id_Loai_Cong_Viec from Cong_Viec where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'";

            SqlCommand th = new SqlCommand(sql_macongviec,c.conn);
            SqlCommand th1 = new SqlCommand(sql_tencongviec,c.conn);
            SqlCommand th2 = new SqlCommand(sql_ngaybatdau,c.conn);
            SqlCommand th3 = new SqlCommand(sql_ngayketthuc,c.conn);
            SqlCommand th4 = new SqlCommand(sql_chucvu,c.conn);
            SqlCommand th5 = new SqlCommand(sql_phongban,c.conn);
            SqlCommand th6 = new SqlCommand(sql_luongcoban,c.conn);
            SqlCommand th7 = new SqlCommand(sql_phucap,c.conn);
            SqlCommand th8 = new SqlCommand(sql_motacongviec,c.conn);
            
            SqlCommand th9 = new SqlCommand(sql_loaicongviec,c.conn);
            SqlCommand th10 = new SqlCommand(sql_luongtrengio,c.conn);
            SqlCommand th11 = new SqlCommand(sql_phucappart, c.conn);

            lbl_macongviec.Text = Convert.ToString(th.ExecuteScalar());
            lbl_tencongviec.Text= Convert.ToString(th1.ExecuteScalar());

            lbl_ngaybatdau.Text= Convert.ToString(th2.ExecuteScalar());
            DateTime ngayBatDau = Convert.ToDateTime(th2.ExecuteScalar());
            lbl_ngaybatdau.Text = ngayBatDau.ToString("dd/MM/yyyy");

            lbl_ngayketthuc.Text = Convert.ToString(th3.ExecuteScalar());
            DateTime ngayKetThuc = Convert.ToDateTime(th3.ExecuteScalar());
            lbl_ngayketthuc.Text = ngayKetThuc.ToString("dd/MM/yyyy");

            lbl_chucvu.Text = Convert.ToString(th4.ExecuteScalar());
            lbl_phongban.Text = Convert.ToString(th5.ExecuteScalar());

            string loaicongviec = Convert.ToString(th9.ExecuteScalar());

            if (loaicongviec == "0")
            {
                lbl_luongcoban.Text = Convert.ToString(th6.ExecuteScalar());
                double luongCoBan = Convert.ToDouble(lbl_luongcoban.Text);
                string luongCoBanViet = luongCoBan.ToString("N0") + "đ";
                lbl_luongcoban.Text = luongCoBanViet;

                lbl_phucap.Text = Convert.ToString(th7.ExecuteScalar());
                double PhuCap = Convert.ToDouble(lbl_phucap.Text);
                string PhuCapViet = PhuCap.ToString("N0") + "đ";
                lbl_phucap.Text = PhuCapViet;
            }
            else
            {
                label8.Text = "Lương Trên Giờ :";
                lbl_luongcoban.Text = Convert.ToString(th10.ExecuteScalar());
                double luongTrenGio = Convert.ToDouble(lbl_luongcoban.Text);
                string luongTrenGioViet = luongTrenGio.ToString("N0") + "đ";
                lbl_luongcoban.Text = luongTrenGioViet;

                lbl_phucap.Text = Convert.ToString(th11.ExecuteScalar());
                double PhuCap = Convert.ToDouble(lbl_phucap.Text);
                string PhuCapViet = PhuCap.ToString("N0") + "đ";
                lbl_phucap.Text = PhuCapViet;
            }
            lbl_motacongviec.Text = Convert.ToString(th8.ExecuteScalar());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
