namespace CleanArchitecture.Application.Utilities.MailService
{
    public sealed record EmailConfigurations(
        string Smtp,
        string Password,
        int Port,
        bool SSL = true,
        bool Html = true);
}
