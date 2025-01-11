using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure.Mail
{

    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSettings { get; }
        private readonly ILogger<EmailSender> _logger;
        public EmailSender(IOptions<EmailSettings> emailSettings, ILogger<EmailSender> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }
        public async Task<bool> SendEmailAsync(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            _logger.LogInformation($"Sending email: {JsonConvert.SerializeObject(message)}");

            // Uncomment this line to send email
            //var response = await client.SendEmailAsync(message);
            //return response.IsSuccessStatusCode;

            return true;
        }
    }
}
