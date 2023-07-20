using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Cham_Cong_TT
{
    public partial class frm_Diem_Danh_Full_New : Form
    {

        private Timer timer1;
        public static string luu,th1,th2,th3,dd;
        public static int ck = 0, ck1 =0;

        public frm_Diem_Danh_Full_New()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }

        ConnectData c = new ConnectData();

        private void frm_Diem_Danh_New_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            
            c.connect();

            SqlCommand cmd = new SqlCommand("select COUNT(Diem_Danh) from Cham_Cong_Full_Time, Cong_Viec where Cong_Viec.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Cong_Viec.id_Cong_Viec = Cham_Cong_Full_Time.id_Cong_Viec and Month(Ngay_Diem_Danh) = '" + month + "' and YEAR(Ngay_Diem_Danh) = '" + year + "' and Diem_Danh = '" + true + "'", c.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int ngaycc = 0;
                ngaycc = dr.GetInt32(0);
                lbl_ngaydachamcong.Text = ngaycc.ToString();
            }
            dr.Close();

            SqlCommand cmd1 = new SqlCommand("select COUNT(Diem_Danh) from Cham_Cong_Full_Time, Cong_Viec where Cong_Viec.id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Cong_Viec.id_Cong_Viec = Cham_Cong_Full_Time.id_Cong_Viec and Month(Ngay_Diem_Danh) = '" + month + "' and YEAR(Ngay_Diem_Danh) = '" + year + "' and DAY(Ngay_Diem_Danh) = '" + day + "' and Diem_Danh = '" + true + "'", c.conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                ck = dr1.GetInt32(0);
            }
            dr1.Close();

            SqlCommand cmd2 = new SqlCommand("select COUNT(Diem_Danh) from Cham_Cong_Full_Time where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Month(Ngay_Diem_Danh) = '" + month + "' and YEAR(Ngay_Diem_Danh) = '" + year + "' and Di_lam_Muon = '" + true + "'", c.conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                int ddmuon = 0;
                ddmuon = dr2.GetInt32(0);
                lbl_ddmuon.Text = ddmuon.ToString();
            }
            dr2.Close();

            SqlCommand cmd3 = new SqlCommand("select COUNT(*) from Tang_Ca where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and month(Ngay_Tang_Ca) = '" + month + "' and year(Ngay_Tang_Ca) = '" + year + "' and Gio_Bat_Dau is not null and Gio_Ket_Thuc is not null", c.conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {
                int ddtangca = 0;
                ddtangca = dr3.GetInt32(0);
                lbl_ddtangca.Text = ddtangca.ToString();
            }
            dr3.Close();

            SqlCommand cmd4 = new SqlCommand("select COUNT(*) from Nghi_Phep where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and month(Ngay_Nghi) = '" + month + "' and year(Ngay_Nghi) = '" + year + "' and Ly_Do is not null", c.conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();

            while (dr4.Read())
            {
                int np = 0;
                np = dr4.GetInt32(0);
                lbl_np.Text = np.ToString();
            }
            dr4.Close();


            SqlCommand cmd5 = new SqlCommand("select COUNT(Diem_Danh) from Cham_Cong_Full_Time where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Month(Ngay_Diem_Danh) = '" + month + "' and YEAR(Ngay_Diem_Danh) = '" + year + "' and Diem_Danh = '" + false + "'", c.conn);
            SqlDataReader dr5 = cmd5.ExecuteReader();

            while (dr5.Read())
            {
                int nkp = 0;
                nkp = dr5.GetInt32(0);
                lbl_nkp.Text = nkp.ToString();
            }
            dr5.Close();

            DataSet ds = new DataSet();
            string query = "select id_Cong_Viec 'Mã Công Việc', Ngay_Diem_Danh 'Ngày Điểm Danh', Gio_Diem_Danh 'Giờ Điểm Danh', Di_Lam_Muon 'Đi Làm Muộn' from Cham_Cong_Full_Time where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Month(Ngay_Diem_Danh) = '" + month + "' and YEAR(Ngay_Diem_Danh) = '" + year + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
            sqlDataAdapter.Fill(ds);
            datagrv_ThongKeFull.DataSource = ds.Tables[0];

            datagrv_ThongKeFull.ReadOnly = true;

            btn_dangkytangca.Enabled = false;
            btn_batdau.Enabled = false;
            btn_ketthuc.Enabled = false;
            label12.Text = year.ToString();
            lbl_Thang.Text = month.ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label13.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbl_giodiemdanh.Text = DateTime.Now.ToString("HH:mm:ss"); //Hiển thị thời gian hiện tại
            lbl_ngaydiemdanh.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btn_Diem_Danh_Click(object sender, EventArgs e)
        {

                    if (ck != 0)
                    {
                        MessageBox.Show("Hôm nay bạn đã điểm danh","Thông báo", MessageBoxButtons.OK);
                dd = "ok";
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Hôm nay bạn chưa điểm danh . Bạn có muốn điểm danh không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        
                        if(result == DialogResult.Yes)
                        {
                    if (DateTime.Now.TimeOfDay < new TimeSpan(8, 30, 0) && DateTime.Now.TimeOfDay > new TimeSpan(4,0,0))
                    {
                        // Thực hiện trường hợp 1
                        SqlCommand cmd = new SqlCommand("insert into Cham_Cong_Full_Time(id_Cong_Viec,Diem_Danh,Ngay_Diem_Danh,Gio_Diem_Danh,Di_Lam_Muon) values('" + frm_Cong_Viec_New.id_Cong_Viec + "','" + true + "', '" + DateTime.Now + "', '" + DateTime.Now + "', '" + false + "')",c.conn);
                        SqlDataReader dr = cmd.ExecuteReader();
                        MessageBox.Show("Bạn đã bắt đầu điểm danh hôm nay, Hôm nay bạn đi làm đúng giờ!!\nTiếp tục phát huy nhé", "Thông báo", MessageBoxButtons.OK);
                        dr.Close();
                        btn_diem_danh.Enabled = false;
                    }
                    else if(DateTime.Now.TimeOfDay > new TimeSpan(8, 30, 0) && DateTime.Now.TimeOfDay < new TimeSpan(18,30,0))
                    {
                        // Thực hiện trường hợp 2
                        SqlCommand cmd = new SqlCommand("insert into Cham_Cong_Full_Time(id_Cong_Viec,Diem_Danh,Ngay_Diem_Danh,Gio_Diem_Danh,Di_Lam_Muon) values('" + frm_Cong_Viec_New.id_Cong_Viec + "','" + true + "', '" + DateTime.Now + "', '" + DateTime.Now + "', '" + true + "')",c.conn);
                        SqlDataReader dr = cmd.ExecuteReader();
                        MessageBox.Show("Bạn đã bắt đầu điểm danh hôm nay, Hôm nay bạn đi làm muộn giờ!!\nCảnh báo đi làm muộn", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        dr.Close();
                        btn_diem_danh.Enabled=false;
                    }
                    else 
                    {
                        MessageBox.Show("Công ty không ai đi làm lúc đêm cả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                        }
                    }
                
        }

        private void btn_thong_ke_Click(object sender, EventArgs e)
        {

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            DateTime tungay = dtp_tktungay.Value;
            string tn = tungay.ToString("yyyy-MMMM-dd");

            DateTime denngay = dtp_tkdenngay.Value;
            string dn = denngay.ToString("yyyy-MMMM-dd");

            if(cb_thong_ke.Text == "Đúng Giờ")
            {
                DataSet ds = new DataSet();
                string query = "select id_Cong_Viec 'Mã Công Việc', Ngay_Diem_Danh 'Ngày Điểm Danh', Gio_Diem_Danh 'Giờ Điểm Danh', Di_Lam_Muon 'Đi Làm Muộn' from Cham_Cong_Full_Time where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Month(Ngay_Diem_Danh) = '" + month + "' and YEAR(Ngay_Diem_Danh) = '" + year + "' and Di_Lam_Muon = '" + false + "' and Ngay_Diem_Danh BETWEEN '" + tn + "' AND '" + dn + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
                sqlDataAdapter.Fill(ds);
                datagrv_ThongKeFull.DataSource = ds.Tables[0];
            }
            else if (cb_thong_ke.Text == "Đi Muộn")
            {
                DataSet ds = new DataSet();
                string query = "select id_Cong_Viec 'Mã Công Việc', Ngay_Diem_Danh 'Ngày Điểm Danh', Gio_Diem_Danh 'Giờ Điểm Danh', Di_Lam_Muon 'Đi Làm Muộn' from Cham_Cong_Full_Time where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Month(Ngay_Diem_Danh) = '" + month + "' and YEAR(Ngay_Diem_Danh) = '" + year + "' and Di_Lam_Muon = '" + true + "' and Diem_Danh = '" + true + "' and Ngay_Diem_Danh BETWEEN '" + tn + "' AND '" + dn + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
                sqlDataAdapter.Fill(ds);
                datagrv_ThongKeFull.DataSource = ds.Tables[0];

            }
            else if (cb_thong_ke.Text == "Nghỉ Phép")
            {
                DataSet ds = new DataSet();
                string query = "select id_Cong_Viec 'Mã Công Việc', Ngay_Nghi 'Ngày Nghỉ', Ly_Do 'Lý Do' from Nghi_Phep where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Month(Ngay_Nghi) = '" + month + "' and YEAR(Ngay_Nghi) = '" + year + "' and Ngay_Nghi BETWEEN '" + tn + "' AND '" + dn + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
                sqlDataAdapter.Fill(ds);
                datagrv_ThongKeFull.DataSource = ds.Tables[0];

            }
            else if (cb_thong_ke.Text == "Nghỉ Không Phép")
            {
                DataSet ds = new DataSet();
                string query = "select id_Cong_Viec 'Mã Công Việc', Diem_Danh 'Điểm Danh', Ngay_Diem_Danh 'Ngày Điểm Danh', Gio_Diem_Danh 'Giờ Điểm Danh' from Cham_Cong_Full_Time where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Month(Ngay_Diem_Danh) = '" + month + "' and YEAR(Ngay_Diem_Danh) = '" + year + "' and Diem_Danh = '" + false + "' and Ngay_Diem_Danh BETWEEN '" + tn + "' AND '" + dn + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
                sqlDataAdapter.Fill(ds);
                datagrv_ThongKeFull.DataSource = ds.Tables[0];
            }
            else if(cb_thong_ke.Text == "Tăng Ca")
            {
                DataSet ds = new DataSet();
                string query = "select id_Cong_Viec 'Mã Công Việc', Ngay_Tang_Ca 'Ngày Tăng Ca', Gio_Bat_Dau 'Giờ Bắt Đầu', Gio_Ket_Thuc 'Giờ Kết Thúc' from Tang_Ca where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Month(Ngay_Tang_Ca) = '" + month + "' and YEAR(Ngay_Tang_Ca) = '" + year + "' and Gio_Bat_Dau is not null and Gio_Ket_Thuc is not null and Ngay_Tang_Ca BETWEEN '" + tn + "' AND '" + dn + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, c.conn);
                sqlDataAdapter.Fill(ds);
                datagrv_ThongKeFull.DataSource = ds.Tables[0];
            }
        }

        private void linkluuy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Đi làm > 08:30:00 thì sẽ tính làm đi làm muộn\nThứ 7 và Chủ Nhật được nghỉ", "Lưu Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            SqlCommand chek = new SqlCommand("select * from Tang_Ca where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Ngay_Tang_Ca = '" + DateTime.Now + "'", c.conn);
            SqlDataReader reader = chek.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {
                        th1 = "ok";
                        th2 = "";
                        th3 = "";
                    }
                    else if (!reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && !reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {
                        th2 = "ok";
                        th1 = "";
                        th3 = "";
                    }
                    else if (!reader.IsDBNull(reader.GetOrdinal("Gio_Bat_Dau")) && reader.IsDBNull(reader.GetOrdinal("Gio_Ket_Thuc")))
                    {
                        th3 = "ok";
                        th1 = "";
                        th2 = "";
                    }
                }
            }reader.Close();

            if(th1 == "ok")
            {
                MessageBox.Show("Hôm nay bạn chưa tăng ca", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                btn_batdau.Enabled = true;
                btn_ketthuc.Enabled = false;
            }else if(th2 == "ok")
            {
                MessageBox.Show("Hôm nay bạn đã tăng ca", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_batdau.Enabled = false;
                btn_ketthuc.Enabled = false;
            }
            else if(th3 == "ok")
            {
                MessageBox.Show("Bạn cần kết thúc tăng ca", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_batdau.Enabled = false;
                btn_ketthuc.Enabled = true;
            }

            if (checkBox4.Checked) {
                
                    btn_dangkytangca.Enabled = true;
                 }
        }

        private void btn_batdau_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn tăng ca", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if(DateTime.Now.TimeOfDay > new TimeSpan(18, 30, 0) && DateTime.Now.TimeOfDay < new TimeSpan(22, 0, 0)) 
                {
                    SqlCommand cmd1 = new SqlCommand("update Tang_Ca set Gio_Bat_Dau = '" + DateTime.Now + "', Gio_Ket_Thuc = '" + DateTime.Now + "'", c.conn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    dr1.Close();
                    MessageBox.Show("Bạn đã bắt đầu điểm danh vào + '" + DateTime.Now.ToString("HH:mm:ss") + "'", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_batdau.Enabled = false;
                    btn_ketthuc.Enabled = true;
                }else
                {
                    MessageBox.Show("Công ty chỉ cho tăng ca từ 8h tối đế 22h đêm và ngày này bạn đã điểm danh và làm đủ 8 tiếng", " Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                }
                
            }
        }
        

        private void btn_ketthuc_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn kết thúc tăng ca", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cmd1 = new SqlCommand("update Tang_Ca set Gio_Bat_Dau = '" + DateTime.Now + "', Gio_Ket_Thuc = '" + DateTime.Now + "'", c.conn);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                dr1.Close();
                MessageBox.Show("Bạn đã kết thúc điểm danh vào  " + DateTime.Now.ToString("HH:mm:ss") + "", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_batdau.Enabled = false;
                btn_ketthuc.Enabled = false;
            }
        }

        private void btn_dangkytangca_Click(object sender, EventArgs e)
        {
            SqlCommand chek = new SqlCommand("select COUNT(*) from Tang_Ca where id_Cong_Viec = '" + frm_Cong_Viec_New.id_Cong_Viec + "' and Ngay_Tang_Ca = '" + DateTime.Now + "'", c.conn);
            SqlDataReader reader = chek.ExecuteReader();

                while (reader.Read())
                {
                        ck1 = reader.GetInt32(0); 
                }
            reader.Close();

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn đăng ký Tăng Ca Không ?","Câu Hỏi",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ck1 == 0)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("insert into Tang_Ca(id_Cong_Viec, Ngay_Tang_Ca) values('" + frm_Cong_Viec_New.id_Cong_Viec + "', '" + DateTime.Now + "')", c.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                }
            }
            else
            {
                MessageBox.Show("Bạn đã đăng ký rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
