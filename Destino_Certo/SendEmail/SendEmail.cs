
using System.Net;
using System.Net.Mail;

namespace Destino_Certo.SendEmail
{
    public class SendEmail:ISendEmail
    {
        
        public bool Marketing(string email)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                NetworkCredential credential = new NetworkCredential("<<EMAIL>>", "<<SENHA>>");
                client.EnableSsl = true;
                client.Credentials = credential;

                MailMessage message = new MailMessage("beto-frs@hotmail.com", email);
                message.Subject = "TESTE DE ENVIO - DESTINO CERTO";
                message.Body = "<h1>DEU CERTO!!! ENVIO DE EMAIL MARKETING...</h1>";
                message.IsBodyHtml = true;
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Password(string email)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                NetworkCredential credential = new NetworkCredential("<<EMAIL>>", "<<SENHA>>");
                client.EnableSsl = true;
                client.Credentials = credential;

                MailMessage message = new MailMessage("beto-frs@hotmail.com", email);
                message.Subject = "TESTE DE ENVIO - DESTINO CERTO";
                message.Body = "<h1>DEU CERTO!!! ENVIO DE EMAIL MARKETING...</h1>";
                message.IsBodyHtml = true;
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
