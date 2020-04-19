namespace BMS.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BMS.Services.Contracts;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class EmailSender : IEmailSenderService
    {

        private readonly string _apiKey;
        public EmailSender(string apiKey)
        {
            this._apiKey = apiKey;
        }

        public void Send()
        {
            this.SendEmailAsync().Wait();
        }


        private async Task SendEmailAsync()
        {
            var sendGridClient = new SendGridClient(this._apiKey);
            var from = new EmailAddress("kevin11@mail.bg", "Chicho Mitko");
            string messageSubject = "SendGridTest";
            var to = new EmailAddress("predator131@mail.bg", "BMS");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with c#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, messageSubject, plainTextContent, htmlContent);
            var response = await sendGridClient.SendEmailAsync(msg);

        }
    }
}
