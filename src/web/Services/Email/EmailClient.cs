﻿using Microsoft.Extensions.Configuration;

using SendGrid;
using SendGrid.Helpers.Mail;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Services.Email
{
    public interface IEmailService
    {
        void Send(string EmailTo, string emailLink, string pass, string html);
    }
    public class EmailClient : IEmailService
    {
        private readonly string Email = "dev.test001@outlook.com";
        private readonly string Password = "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";
      
        public EmailClient(IConfiguration configuration)
        {
            //Email = configuration.GetValue<string>("EmailConf:Email");
           // Password = configuration.GetValue<string>("EmailConf:Pass");
        }

        public async void Send(string EmailTo, string emailLink, string pass, string html)
        {
            var apiKey = Password;
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Email, "axy"),
                Subject = "Reset Password!",
                PlainTextContent = "Reset Password!",
                HtmlContent = html
            };
            msg.AddTo(new EmailAddress(EmailTo, "Test User"));
            var response = await client.SendEmailAsync(msg); ;
        }
    }
}
