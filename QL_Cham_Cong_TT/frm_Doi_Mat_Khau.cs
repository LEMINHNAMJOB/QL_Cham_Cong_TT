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
    

    public partial class frm_Doi_Mat_Khau : Form
    {

       public static string tk, mk;

        public frm_Doi_Mat_Khau()
        {
            InitializeComponent();
           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Quay_Lai_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Dang_Nhap frm_Dang_Nhap = new frm_Dang_Nhap();
            frm_Dang_Nhap.Show();
        }

        private void btn_Doi_Mat_Khau_Click(object sender, EventArgs e)
        {

            ConnectData c = new ConnectData();
            c.connect();
            SqlCommand sqlCommand = new SqlCommand("select * from Nguoi_Dung where Tai_Khoan = '" + txt_Tai_Khoan.Text + "'",c.conn);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();  

            while (dataReader.Read())
            {
                tk = dataReader["Tai_Khoan"].ToString();
                mk = dataReader["Mat_Khau"].ToString();
            }
            dataReader.Close();
            //c.disconnect();

            if (txt_Mat_Khau_Moi.Text != txt_Nhap_Lai_Mat_Khau_Moi.Text)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới trùng khớp !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tk == txt_Tai_Khoan.Text && mk == txt_Mat_Khau.Text)
            {
                c.connect();
                string sql = "update Nguoi_Dung set Nguoi_Dung.Mat_Khau = '" + txt_Mat_Khau_Moi.Text + "' where Nguoi_Dung.Tai_Khoan = '" + tk + "'";
                SqlCommand thuchien = new SqlCommand(sql, c.conn);
                SqlDataReader sqlDataReader = thuchien.ExecuteReader();
                c.disconnect();
                txt_Mat_Khau.Text = "";
                txt_Mat_Khau_Moi.Text = "";
                txt_Nhap_Lai_Mat_Khau_Moi.Text = "";
                txt_Tai_Khoan.Text = "";
                txt_Tai_Khoan.Focus();
                sqlDataReader.Close();
               // c.disconnect();
                MessageBox.Show("Đổi mật khẩu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tk != txt_Tai_Khoan.Text || mk != txt_Mat_Khau.Text)
            {
                txt_Mat_Khau.Text = "";
                txt_Mat_Khau_Moi.Text = "";
                txt_Nhap_Lai_Mat_Khau_Moi.Text = "";
                txt_Tai_Khoan.Text = "";
                txt_Tai_Khoan.Focus();
                MessageBox.Show("Vui lòng nhập đúng tài khoản và mật khẩu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
