namespace BMS.Services
{
    using BMS.Services.Contracts;
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MimeKit;
    using MimeKit.Text;
    using System.Threading.Tasks;
    public class EmailSender : IEmailSender
    {
        public void Send(string recipientEmail, string content, string emailSubject)
        {
            SendEmail(recipientEmail, content, emailSubject).Wait();
        }

        private async Task SendEmail(string recipientEmail, string content,string emailSubject)
        {
            
            var messageToSend = new MimeMessage
            {
                Sender = new MailboxAddress("BMS", "bastunmanagementsystem@gmail.com"),
                Subject = emailSubject,
            };

            messageToSend.Body = new TextPart(TextFormat.Plain)
            {
                Text = content
            };

            messageToSend.To.Add(new MailboxAddress(recipientEmail));

            using (var smtp = new SmtpClient())
            {
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("bastunmanagementsystem@gmail.com", "Greatwhiteshark_1");
                await smtp.SendAsync(messageToSend);
                await smtp.DisconnectAsync(true);
            }
        }

      
    }
}
