using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AppSeguroPopularHidalgo.iOS.Services
{
    public class Email
    {
        public Email()
        {

        }

        public bool EmailSneder(string messageToSend)
        {

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("desarrolloprospectiva@gmail.com"); //Who it's from
                message.To.Add("desarrolloprospectiva@gmail.com"); // The E-Mail that recieves the message
                message.Subject = "Replay from PC";
                message.Body = messageToSend;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("desarrolloprospectiva@gmail.com", "Prospectiva123");
                client.Send(message);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
