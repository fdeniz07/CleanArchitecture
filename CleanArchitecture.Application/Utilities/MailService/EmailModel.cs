
namespace CleanArchitecture.Application.Utilities.MailService
{
    public sealed record EmailModel<TAttachment>(
        EmailConfigurations Configurations,
        string FromEmail,
        List<string> ToEmails,
        string Subject,
        string Body,
        List<TAttachment>? Attachments = null);
}
