using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_Cham_Cong_TT
{
    public class ConnectData
    {
        public  SqlConnection conn;

        public void connect()
        {
            String strCon = @"Data Source=DESKTOP-TCHOJH4;Initial Catalog=QL_Cham_Cong_TT;Integrated Security=True";
            try
            {
                conn = new SqlConnection(strCon);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void disconnect()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }
    }
}
