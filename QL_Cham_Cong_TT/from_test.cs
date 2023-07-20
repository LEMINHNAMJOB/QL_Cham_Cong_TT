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
    public partial class from_test : Form
    {
        public from_test()
        {
            InitializeComponent();
        }

        private void btn_Chon_Anh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();
            SqlCommand th = new SqlCommand("update Nhan_Vien set Hinh_Anh=@img where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'", c.conn);
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            
            th.Parameters.AddWithValue("@img", img);
            int i = th.ExecuteNonQuery();
            c.conn.Close();
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
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void from_test_Load(object sender, EventArgs e)
        {
            LoadImage();
            /*
            ConnectData c = new ConnectData();
            c.connect();
            SqlCommand thh = new SqlCommand("select Hinh_Anh from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'", c.conn);
            SqlDataAdapter da = new SqlDataAdapter(thh);
            DataTable dt = new DataTable();
            da.Fill(dt);
            byte[] img = (byte[])dt.Rows[0][0];
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            */
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            ConnectData c = new ConnectData();
            c.connect();
            SqlCommand th = new SqlCommand("delete from Nhan_Vien where id_Nhan_Vien = '" + frm_Dang_Nhap.id_Nhan_Vien + "'", c.conn);
            //th.Parameters.AddWithValue("@id", );
            int i = th.ExecuteNonQuery();
            c.conn.Close();
        }
    }
}
