using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Cham_Cong_TT
{
    public partial class frm_Diem_Danh_Part_New : Form
    {
        public static TimeSpan gio_Ket_Thuc;
        public static string id_Ca_Lam, maca, diemdanh;
        private Timer timer1;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;



        public frm_Diem_Danh_Part_New()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        ConnectData c = new ConnectData();  

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void frm_Diem_Danh_Part_New_Load(object sender, EventArgs e)
        {

            //lưu ngày tháng năm hiện tại

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            c.connect();
            int gio_lam_day = 0;
            int gio_lam_month = 0;
            for (int i = 1; i < daysInMonth; i++)
            {
                //Tính số giờ Đã làm trên tháng
                SqlCommand cmd = new SqlCommand("select DATEDIFF(hour, Gio_Bat_Dau, Gio_Ket_Thuc) AS DateDiff FROM Cham_Cong_Part_Time, Cong_Viec " +
                    "where Cham_Cong_Part_Time.id_Cong_Viec = Cong_Viec.id_Cong_Viec " +
                    "and Gio_Bat_Dau IS NOT NULL " +
                    "and Gio_Ket_Thuc IS NOT NULL " +
                    "and DAY(Ngay_Lam) = '" + i + "' " +
                    "and MONTH(Ngay_Lam) = '" + month + "' " +
                    "and YEAR(Ngay_Lam) = '" + year + "' " +
                    "and Cong_Viec.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "';", c.conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    gio_lam_day = sqlDataReader.GetInt32(0);
                    gio_lam_month = gio_lam_month + gio_lam_day;
                    lbl_giodalam.Text = gio_lam_month.ToString();
                }
                else
                {

                }
                sqlDataReader.Close();
            }

            // hiện lưu id ca làm vào id_Ca_Lam và hiện tên ca
            SqlCommand cmd1 = new SqlCommand("select * from Cong_Viec, Cham_Cong_Part_Time, Ca_Lam where Cong_Viec.id_Cong_Viec = Cham_Cong_Part_Time.id_Cong_Viec and Ca_Lam.id_Ca_Lam = Cham_Cong_Part_Time.id_Ca_Lam and DAY(Ngay_Lam) = '" + day + "' and MONTH(Ngay_Lam) = '" + month + "' and YEAR(Ngay_Lam) = '" + year + "' and Cong_Viec.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "'", c.conn);
            SqlDataReader sqlDataReader1 = cmd1.ExecuteReader();
            

            while(sqlDataReader1.Read())
            {
                lbl_nowcalam.Text = sqlDataReader1["Ten_Ca"].ToString();
                id_Ca_Lam = sqlDataReader1["id_Ca_Lam"].ToString();
                
            }
            sqlDataReader1.Close();


            // hiện giờ bắt ddaauf và giờ kết thúc
            SqlCommand cmd3 = new SqlCommand("select * from Ca_Lam where id_Ca_Lam = '" + frm_Diem_Danh_Part_New.id_Ca_Lam + "'", c.conn);
            SqlDataReader sqlDataReader3 = cmd3.ExecuteReader();

            while(sqlDataReader3.Read())
            {
                lbl_nowgiobatdau.Text = sqlDataReader3["Gio_Bat_Dau"].ToString();
                lbl_nowgioketthuc.Text = sqlDataReader3["Gio_Ket_Thuc"].ToString();
                frm_Diem_Danh_Part_New.gio_Ket_Thuc = sqlDataReader3.GetTimeSpan(sqlDataReader3.GetOrdinal("Gio_Ket_Thuc"));
            }
            sqlDataReader3.Close();


            // Check xem Gio_Bai_Dau và Gio_ket_Thc có null k
            SqlCommand cmdcheck = new SqlCommand("select Gio_Bat_Dau,Gio_Ket_Thuc from Cham_Cong_Part_Time where Ngay_Lam = '" + DateTime.Now + "' and id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "'", c.conn);
            SqlDataReader reader = cmdcheck.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    if (reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {

                        MessageBox.Show("Ngày Hôm Nay Bạn Chưa Điểm Danh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_ketthuc.ForeColor = Color.White;
                        btn_batdau.Enabled = true;
                        btn_ketthuc.Enabled = false;

                    }
                    else if (!reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {
                        btn_batdau.Enabled=false;
                        btn_ketthuc.Enabled=true;
                    }
                    else if(!reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && !reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {
                        MessageBox.Show("Ngày Hôm Nay Bạn Đã Điểm Danh vào lúc " + reader["Gio_Bat_Dau"].ToString() + "\n Và kết thúc vào lúc " + reader["Gio_Ket_Thuc"].ToString() + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
                        btn_batdau.Enabled = false;
                        btn_ketthuc.Enabled = false;
                    }
                }
            }
            reader.Close();

            DataSet ds = new DataSet();
            string query = "select Ten_Cong_Viec 'Tên Công Việc', Ten_Ca 'Tên Ca', Ngay_Lam 'Ngày Làm', Cham_Cong_Part_Time.Gio_Bat_Dau 'Giờ Bắt Đầu Làm', Cham_Cong_Part_Time.Gio_Ket_Thuc 'Giờ Kết Thúc' from  Cong_Viec, Cham_Cong_Part_Time, Ca_Lam where Cham_Cong_Part_Time.id_Cong_Viec = Cong_Viec.id_Cong_Viec and Cham_Cong_Part_Time.id_Ca_Lam = Ca_Lam.id_Ca_Lam and Cong_Viec.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "'";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
            sqlDataAdapter.Fill(ds);
            datagrv_ThongKePart.DataSource = ds.Tables[0];

  
            lbl_thang.Text = month.ToString();
            lbl_nam.Text = year.ToString();
            
            
        }



        private void btn_batdau_Click(object sender, EventArgs e)
        {

            if(lbl_nowcalam.Text == "none")
            {
               MessageBox.Show("Bạn Cần Đăng Ký Ca Làm Trước Khi Điểm Danh","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update Cham_Cong_Part_Time set Gio_Bat_Dau = '" + DateTime.Now + "' where Ngay_Lam = '" + DateTime.Now + "' and Cham_Cong_Part_Time.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "'", c.conn);
                cmd.ExecuteNonQuery();
                btn_batdau.Enabled = false;
                btn_ketthuc.Enabled = true;
                MessageBox.Show("Bạn đã bắt đầu công việc vào lúc " + DateTime.Now + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void btn_ketthuc_Click(object sender, EventArgs e)
        {
            DialogResult de = MessageBox.Show("Khi quá ca làm thì sẽ tự động kết thúc\nBạn muốn kết thúc luôn không ?","Thông Báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            TimeSpan time = TimeSpan.FromHours(DateTime.Now.Hour);
            if (de == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("update Cham_Cong_Part_Time set Gio_Ket_Thuc = '" + DateTime.Now + "' where Ngay_Lam = '" + DateTime.Now + "' and Cham_Cong_Part_Time.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "'", c.conn);
                cmd.ExecuteNonQuery();
                btn_batdau.Enabled = false;
                btn_ketthuc.Enabled = false;
                MessageBox.Show("Bạn đã Kết thúc công việc vào lúc " + DateTime.Now + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            /*
            else if(time > frm_Diem_Danh_Part_New.gio_Ket_Thuc)
            {
                SqlCommand cmd = new SqlCommand("update Cham_Cong_Part_Time set Gio_Ket_Thuc = '" + DateTime.Now + "' where Ngay_Lam = '" + DateTime.Now + "' and Cham_Cong_Part_Time.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "'", c.conn);
                cmd.ExecuteNonQuery();
                btn_batdau.Enabled = false;
                btn_ketthuc.Enabled = false;
            }
            */


        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            DateTime tungay = dtp_tktungay.Value;
            string tn = tungay.ToString("yyyy-MMMM-dd");

            DateTime denngay = dtp_tkdenngay.Value;
            string dn = denngay.ToString("yyyy-MMMM-dd");

            //SELECT* FROM table_name WHERE date_column BETWEEN '2023-07-01' AND '2023-07-10';

            if(cmb_tkcalam.Text == "Tất Cả")
            {
                string tatca = "";
                DataSet ds = new DataSet();
                string query = "SELECT Ten_Cong_Viec 'Tên Công Việc', Ten_Ca 'Tên Ca', Ngay_Lam 'Ngày Làm', Cham_Cong_Part_Time.Gio_Bat_Dau 'Giờ Bắt Đầu Làm', Cham_Cong_Part_Time.Gio_Ket_Thuc 'Giờ Kết Thúc' FROM Cong_Viec, Cham_Cong_Part_Time, Ca_Lam WHERE Cham_Cong_Part_Time.id_Cong_Viec = Cong_Viec.id_Cong_Viec and Cham_Cong_Part_Time.id_Ca_Lam = Ca_Lam.id_Ca_Lam and Ten_Ca like N'%" + tatca + "%' and Cong_Viec.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' AND Ngay_Lam BETWEEN '" + tn + "' AND '" + dn + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
                sqlDataAdapter.Fill(ds);
                datagrv_ThongKePart.DataSource = ds.Tables[0];
            }else 
            {

                DataSet ds = new DataSet();
                string query = "SELECT Ten_Cong_Viec 'Tên Công Việc', Ten_Ca 'Tên Ca', Ngay_Lam 'Ngày Làm', Cham_Cong_Part_Time.Gio_Bat_Dau 'Giờ Bắt Đầu Làm', Cham_Cong_Part_Time.Gio_Ket_Thuc 'Giờ Kết Thúc' FROM Cong_Viec, Cham_Cong_Part_Time, Ca_Lam WHERE Cham_Cong_Part_Time.id_Cong_Viec = Cong_Viec.id_Cong_Viec and Cham_Cong_Part_Time.id_Ca_Lam = Ca_Lam.id_Ca_Lam and Ten_Ca like N'%" + cmb_tkcalam.Text + "%' and Cong_Viec.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' AND Ngay_Lam BETWEEN '" + tn + "' AND '" + dn + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
                sqlDataAdapter.Fill(ds);
                datagrv_ThongKePart.DataSource = ds.Tables[0];
            }

            
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            //Lưu mã ca
            if (cmb_dkcalam.Text == "Sáng")
            {
                maca = "C1";
            }
            else if (cmb_dkcalam.Text == "Chiều")
            {
                maca = "C2";
            }
            else if (cmb_dkcalam.Text == "Tối")
            {
                maca = "C3";
            }
            else if (cmb_dkcalam.Text == "Sáng - Chiều")
            {
                maca = "C4";
            }
            else if (cmb_dkcalam.Text == "Sáng - Tối")
            {
                maca = "C5";
            }
            else if (cmb_dkcalam.Text == "Chiều - Tối")
            {
                maca = "C6";
            }
            else if (cmb_dkcalam.Text == "Sáng - Chều - Tối")
            {
                maca = "C7";
            }
            else if (cmb_dkcalam.Text == "none")
            {
                maca = "none";
            }

            if (maca == "none")
            {
                MessageBox.Show("Bạn chưa chọn ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DateTime date = dtp_dkdiemdanh.Value;
                string formattedDate = date.ToString("yyyy-MM-dd");

                // Check xem Ngay_Lam có null k
                SqlCommand cmdcheck = new SqlCommand("select count(*) from Cham_Cong_Part_Time where Ngay_Lam = '" + formattedDate + "' and id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "'", c.conn);
                SqlDataReader reader = cmdcheck.ExecuteReader();

                int ck = 0;

                if (reader.Read())
                {
                    ck = reader.GetInt32(0);
                    if (ck > 0)
                    {

                        MessageBox.Show("Bạn đẫ đăng ký ngày " + dtp_dkdiemdanh.Text + " rồi\nBạn chỉ có thể chỉnh sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       

                    }
                    else
                    {
                        reader.Close();
                        SqlCommand sqlCommand = new SqlCommand("insert into Cham_Cong_Part_Time(id_Cong_Viec, id_Ca_Lam, Ngay_Lam) values ('" + frm_Cong_Viec_New.id_Cong_Viec + "', '" + frm_Diem_Danh_Part_New.maca + "', '" + formattedDate + "')", c.conn);
                        SqlDataReader dr = sqlCommand.ExecuteReader();
                        MessageBox.Show("Bạn đẫ đăng ký thành công !", "Thông", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Close();
                    }

                }
                reader.Close();
                
            }
        }

        private void cmb_dkcalam_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_dkcalam_TextUpdate(object sender, EventArgs e)
        {
            
        }

        

        private void cmb_dkcalam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_dkcalam.SelectedIndex == 0)
            {
                lbl_dkgiobatdau.Text = "06:30:00";
                lbl_dkgioketthuc.Text = "11:30:00";

            }
            else if(cmb_dkcalam.SelectedIndex == 1)
            {
                lbl_dkgiobatdau.Text = "13:00:00";
                lbl_dkgioketthuc.Text = "17:00:00";

            }
            else if (cmb_dkcalam.SelectedIndex == 2)
            {
                lbl_dkgiobatdau.Text = "17:30:00";
                lbl_dkgioketthuc.Text = "22:00:00";
            }
            else if (cmb_dkcalam.SelectedIndex == 3)
            {
                lbl_dkgiobatdau.Text = "06:30:00";
                lbl_dkgioketthuc.Text = "17:00:00";

            }
            else if (cmb_dkcalam.SelectedIndex == 4)
            {
                lbl_dkgiobatdau.Text = "06:30:00";
                lbl_dkgioketthuc.Text = "22:00:00";
            }
            else if (cmb_dkcalam.SelectedIndex == 5)
            {
                lbl_dkgiobatdau.Text = "13:00:00";
                lbl_dkgioketthuc.Text = "22:00:00";

            }
            
            
        }

        private void cmb_tkcalam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_chínhua_Click(object sender, EventArgs e)
        {

            DateTime date = dtp_dkdiemdanh.Value;
            // Check xem Gio_Bai_Dau và Gio_ket_Thc có null k
            SqlCommand cmdcheck = new SqlCommand("select Gio_Bat_Dau,Gio_Ket_Thuc from Cham_Cong_Part_Time where Ngay_Lam = '" + date + "' and id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "'", c.conn);
            SqlDataReader reader = cmdcheck.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    if (reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {

                        frm_Diem_Danh_Part_New.diemdanh = "ok";

                    }
                    else if (!reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {

                        frm_Diem_Danh_Part_New.diemdanh = "kok";
                    }
                    else if (!reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && !reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {

                        frm_Diem_Danh_Part_New.diemdanh = "kok";
                    }
                }
            }
            reader.Close();


            //Lưu mã ca
            if (cmb_dkcalam.Text == "Sáng")
            {
                maca = "C1";
            }
            else if (cmb_dkcalam.Text == "Chiều")
            {
                maca = "C2";
            }
            else if (cmb_dkcalam.Text == "Tối")
            {
                maca = "C3";
            }
            else if (cmb_dkcalam.Text == "Sáng - Chiều")
            {
                maca = "C4";
            }
            else if (cmb_dkcalam.Text == "Sáng - Tối")
            {
                maca = "C5";
            }
            else if (cmb_dkcalam.Text == "Chiều - Tối")
            {
                maca = "C6";
            }
            else if (cmb_dkcalam.Text == "Sáng - Chều - Tối")
            {
                maca = "C7";
            }
            else if (cmb_dkcalam.Text == "none")
            {
                maca = "none";
            }


            if (frm_Diem_Danh_Part_New.diemdanh == "ok")
            {
                if (maca == "none")
                {
                    MessageBox.Show("Vui lòng chọn ca muốn chỉnh sửa","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update Cham_Cong_Part_Time set id_Ca_Lam = '" + maca + "' where Ngay_Lam = '" + date + "'", c.conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    MessageBox.Show("Bạn đã chỉnh sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close();
                }
            }
            else if(frm_Diem_Danh_Part_New.diemdanh == "kok")
            {
                MessageBox.Show("Ngày Bạn chọn là ngày đã điểm danh rồi nên không thể chỉnh sửa nữa","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reader.Close();
            
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {

            lbl_giohientai.Text = DateTime.Now.ToString("HH:mm:ss"); //Hiển thị thời gian hiện tại
            lbl_nowngaydiemdanh.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

    }
}
