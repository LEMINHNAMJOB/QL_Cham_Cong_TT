using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace QL_Cham_Cong_TT
{
    public partial class frm_Phong_Ban_New : Form
    {
        public frm_Phong_Ban_New()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        int otp;

        public void SendEmail(string emailTo)
        {
            otp = rand.Next(100000, 1000000);
            var fromAddress = new MailAddress("leminhnamyb2004@gmail.com", "Lê Nam");
            var toAddress = new MailAddress(emailTo, " Duy Tung");
            const string fromPassword = "vzhoshhotwqitzqh";
            const string subject = "Xác nhận tài khoản";
            string body = "Xin chào,\n\nBạn đã đăng ký tài khoản thành công.+ "+" \nOTP của bạn là :  "+ otp.ToString() +"\n\nCảm ơn bạn đã sử dụng dịch vụ của chúng tôi.\n\nTrân trọng,\nYour Name";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmail(textBox1.Text);
        }
        
    }
}
