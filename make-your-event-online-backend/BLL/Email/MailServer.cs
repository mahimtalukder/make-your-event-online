using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MailServer
    {
        public static SmtpClient Server()
        {
            SmtpClient client = new SmtpClient();

            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("19-41621-3@student.aiub.edu", "Mata 5366");
            client.EnableSsl = true;

            return client;
        }
    }
}
