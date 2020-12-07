using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Common.Helpers
{
    public class MailHelper
    {
        public void SendMail(string mail, string mailBody)
        {
            using (MailMessage mailMessage = new MailMessage("cnurztrk@gmail.com", mail))
            {
                mailMessage.Subject = "Account Activation";
                string body = mailBody;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("cnurztrk@gmail.com", "ceylan1234");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);

            }
        }
    }
}
