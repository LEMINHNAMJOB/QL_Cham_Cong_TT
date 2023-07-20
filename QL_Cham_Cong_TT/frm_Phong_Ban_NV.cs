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
    public partial class frm_Phong_Ban_NV : Form
    {
        public static string id_truong_phong;

        public frm_Phong_Ban_NV()
        {
            InitializeComponent();
        }

        ConnectData c = new ConnectData();

        private void frm_Phong_Ban_NV_Load(object sender, EventArgs e)
        {
            c.connect();
            SqlCommand cmd = new SqlCommand("select id_Truong_Phong from Nhan_Vien, Phong_Ban where Nhan_Vien.id_Phong_Ban = Phong_Ban.id_Phong_Ban and id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'",c.conn);
            //SqlDataReader dr = cmd.ExecuteReader();

            id_truong_phong = Convert.ToString(cmd.ExecuteScalar());
            //dr.Close();

            SqlCommand cmd1 = new SqlCommand("select * from Truong_Phong, Phong_Ban, Chuc_Vu where Truong_Phong.id_Truong_Phong = '" + id_truong_phong + "' and Phong_Ban.id_Truong_Phong = Truong_Phong.id_Truong_Phong and Chuc_Vu.id_Chuc_Vu = Truong_Phong.id_Chuc_Vu", c.conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            try
            {
                while (dr1.Read())
                {
                    lbl_tenphongban.Text = dr1["Ten_Phong_Ban"].ToString();
                    lbl_lienhe.Text = dr1["GmailPB"].ToString();
                    lbl_diachiphongban.Text = dr1["Dia_Chi"].ToString();
                    lbl_dien_thoai.Text = dr1["SDT"].ToString();
                    lbl_ho_ten.Text = dr1["Ho_Ten"].ToString();
                    lbl_ngay_sinh.Text = dr1["Ngay_Sinh"].ToString();
                    lbl_dia_chi.Text = dr1["Dia_Chi_Hien_Tai"].ToString();
                    lbl_gioi_tinh.Text = dr1["Gioi_Tinh"].ToString();
                    lbl_ton_giao.Text = dr1["Ton_Giao"].ToString();
                    lbl_trinh_do.Text = dr1["Trinh_Do"].ToString();
                    lbl_gmail.Text = dr1["Gmail"].ToString();
                    lbl_chuc_vu.Text = dr1["Ten_Chuc_Vu"].ToString();
                }
            }
            finally { dr1.Close(); }
            

        }
    }
}
