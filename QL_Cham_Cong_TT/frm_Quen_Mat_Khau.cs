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
    public partial class frm_Quen_Mat_Khau : Form
    {
        public frm_Quen_Mat_Khau()
        {
            InitializeComponent();
        }

        private void btn_Quay_Lai_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Dang_Nhap frm_Dang_Nhap = new frm_Dang_Nhap(); 
            frm_Dang_Nhap.ShowDialog();
        }

        private void btn_Lay_Mat_Khau_Click(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();
            string sql = "select Nguoi_Dung.Mat_Khau from Nhan_Vien,Nguoi_Dung,Chuc_Vu where Nhan_Vien.id_Nhan_Vien = Nguoi_Dung.id_Nhan_Vien and Nhan_Vien.id_Chuc_Vu = Chuc_Vu.id_Chuc_Vu and Tai_Khoan ='" + txt_Tai_Khoan.Text +"' and Nguoi_Dung.Gmail ='" + txt_Gmail.Text +"' and Nhan_Vien.id_Nhan_Vien ='" + txt_ID_Nhan_Vien.Text+"' and Ten_Chuc_Vu ='" + cmb_Chuc_Vu.Text + "'";
            SqlCommand thuchien = new SqlCommand(sql,c.conn);
            string matkhau = Convert.ToString(thuchien.ExecuteScalar());
            SqlDataReader reader = thuchien.ExecuteReader();
            //string mk = reader.GetString(0);
            if(reader.Read() == false)
            {
                MessageBox.Show("Bạn đã nhập sai thông tin\nVui lòng điền đúng thông tin","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txt_Tai_Khoan.Text = "";
                txt_Gmail.Text = "";
                txt_ID_Nhan_Vien.Text = "";
                txt_Tai_Khoan.Focus();
            }
            else
            {
                MessageBox.Show("Mật khẩu của bạn là " + matkhau + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
