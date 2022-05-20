using Microsoft.EntityFrameworkCore;

namespace MailSend.Data
{
    public class MailContext: DbContext
    {
        public MailContext(DbContextOptions<MailContext> options) : base(options) { }
        public DbSet<Mail>? Mails { get; set; }
    }
}
