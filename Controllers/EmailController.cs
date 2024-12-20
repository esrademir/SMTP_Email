
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Text;

namespace SmtpEMailExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpGet]
        public void Send()
        {
            SmtpClient client = new SmtpClient();
            client.Port = 596;
            client.Host = "smtp.mail.com";
            client.EnableSsl = false;
            client.Timeout = 1000000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential
            ("gönderici mail adresi", "gönderici mail şifresi");


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("alıcı mail adresi");
            mail.To.Add("To alıcı");
            mail.Subject = "mail Başlığı";
            mail.IsBodyHtml = true;
            mail.Body = "mail içeriği";
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mail);
        }

    }
}
