using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_Cham_Cong_TT
{
    
    public partial class frm_Dang_Nhap : Form
    {
        public static string id_Nhan_Vien;
        private Timer timer;
        private int x = 0;

        public frm_Dang_Nhap()
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
            label2.Left += 1;
            label1.Left += 1;
            if (label1.Left >= this.Width)
            {
                label1.Left = -label1.Width;
            }
            if (label2.Left >= this.Width)
            {
                label2.Left = -label1.Width;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Đang_Nhap_Click(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();
            string sql = "Select Nguoi_Dung.id_Nhan_Vien from Nhan_Vien ,Nguoi_Dung ,Chuc_Vu  where Nhan_Vien.id_Nhan_Vien = Nguoi_Dung.id_Nhan_Vien and Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Tai_Khoan = '" + txt_Tai_Khoan.Text + "' and Mat_Khau = '" + txt_Mat_Khau.Text + " ' and Ten_Chuc_Vu = N'" + cmb_Chuc_Vu.Text + "'";
            SqlCommand com = new SqlCommand(sql, c.conn);
            id_Nhan_Vien = Convert.ToString(com.ExecuteScalar());
            SqlDataReader reader = com.ExecuteReader();
            if(reader.Read() == false)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu \nVui lòng chọn đúng chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Tai_Khoan.Text = "";
                txt_Mat_Khau.Text = "";
                txt_Tai_Khoan.Focus();
            }else if(cmb_Chuc_Vu.Text == "Nhân Viên")
            {
                this.Hide();
                frm_Nhan_Vien_New frm_Nhan_Vien = new frm_Nhan_Vien_New();
                frm_Nhan_Vien.Show();
            }else if(cmb_Chuc_Vu.Text == "Quản Lý")
            {
                this.Hide();
                frm_Quan_Ly frm_Quan_Ly = new frm_Quan_Ly();
                frm_Quan_Ly.Show();
            }
        }
        private void btn_Quen_Mat_Khau_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Doi_Mat_Khau frm_Doi_Mat_Khau = new frm_Doi_Mat_Khau();
            frm_Doi_Mat_Khau.Show();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát ? ", "Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txt_Mat_Khau.PasswordChar = '\0';
            }
            else
            {
                txt_Mat_Khau.PasswordChar = '*';
            }
        }

        private void cmb_Chuc_Vu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Mat_Khau_Click(object sender, EventArgs e)
        {

        }

        private void lib_Quen_Mat_Kau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frm_Quen_Mat_Khau frm_Quen_Mat_Khau = new frm_Quen_Mat_Khau();
            frm_Quen_Mat_Khau.Show();
        }

        private void frm_Dang_Nhap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            from_test from_Test = new from_test();
            from_Test.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
