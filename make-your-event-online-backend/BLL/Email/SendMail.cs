using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Email
{
    public class SendMail
    {
        public static string Mail(MailDataDTO data)
        {
            var client = MailServer.Server();
            MailAddress from = new MailAddress("19-41621-3@student.aiub.edu", "Event Management");
            MailAddress to = new MailAddress(data.Email, data.Name);
            MailMessage message = new MailMessage(from, to);
            message.Subject = data.Subject;
            message.Body = data.Body;

            try
            {
                client.Send(message);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

