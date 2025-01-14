﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net.Mail;

namespace WebApp1.Email
{
    public class SendGridEmail : IEmailSender
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public SendGridEmail(IConfiguration configuration, ILogger<SendGridEmail> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }


        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            string sendGridApiKey = configuration["SendGridApiKey"];
            if (string.IsNullOrEmpty(sendGridApiKey))
            {
                throw new Exception("The 'SendGridApiKey' is not configured");
            }

            var client = new SendGridClient(sendGridApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("ng.hakhang309@gmail.com", "Loco Trade"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            var response = await client.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation("Email queued successfully");
            }
            else
            {
                logger.LogError("Failed to send email");
                // Adding more information related to the failed email could be helpful in debugging failure,
                // but be careful about logging PII, as it increases the chance of leaking PII
            }
        }
    }
}
