using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Mail
{
    public class TextMail
    {
        string smtpClient = string.Empty;
        string UserId = string.Empty;
        string Password = string.Empty;
        int port = 0;
        
        public TextMail(string MailClient, string MailUserId, string MailPassword, int Mailport)
        {
            smtpClient = MailClient;
            UserId = MailUserId;
            Password = MailPassword;
            port = Mailport;
        }
        public string send_click(string Destination, string Source, string BodyText, string Subject = "")
        {
            try
            {
                MailMessage message = new MailMessage(Source, Destination,  Subject, BodyText);

                SmtpClient client = new SmtpClient(smtpClient, port);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(UserId,Password);
                client.Send(message);
                return "Message Has sent successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
