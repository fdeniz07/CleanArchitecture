using System.Net.Mail;
using GenericEmailService;
using CleanArchitecture.Application.Service;


namespace CleanArchitecture.Infrastructure.Service
{
    public sealed class MailService : IMailService
    {
        //public Task SendMailAsync(EmailConfigurations configurations, EmailModel<string> emailModel)
        public async Task SendMailAsync(List<string> emails, string subject, string email, string body, List<Attachment>? attachments)
        {
            EmailConfigurations configurations = new(
                    Smtp: "smtp.example.com",
                    Password: "password",
                    Port: 587,
                    SSL: true,
                    Html: true
                );

            EmailModel<Attachment> model = new(
                    Configurations: configurations,
                    FromEmail: "",
                    ToEmails: emails,
                    Subject: "Subjects",
                    Body: "<b>Body</b>",
                    Attachments: null
                );

            await EmailService.SendEmailWithNetAsync(model);

        }
    }
}
