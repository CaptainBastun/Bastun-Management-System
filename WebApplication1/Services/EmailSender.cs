namespace BMS.Services
{
    using BMS.Services.Contracts;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class EmailSender : IEmailSender
    {
        public void Send(string recipientEmail, string content, string emailSubject)
        {
            SendEmail(recipientEmail, content, emailSubject).Wait();
        }

        private async Task SendEmail(string recipientEmail, string content,string emailSubject)
        {
            string apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("bastunmanagementsystem@gmail.com");
            var subject = emailSubject;
            var to = new EmailAddress(recipientEmail);
            string plainTextContent = content;
            string htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from,to,subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

      
    }
}
