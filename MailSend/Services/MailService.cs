using MailKit.Net.Smtp;
using MailKit.Security;
using MailSend.Data;
using MailSend.Settings;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MailSend.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> options)
        {
            _mailSettings=options.Value;
        }
        public async Task SendMailAsync(Mail mail)
        {

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mail.Email));
            email.Subject = mail.Email;
            var builder = new BodyBuilder();
            builder.HtmlBody= mail.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port,SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }        
    }
}
