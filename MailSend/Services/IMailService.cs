using MailSend.Data;

namespace MailSend.Services
{
    public interface IMailService
    {
        Task SendMailAsync(Mail mail);
    }
}
