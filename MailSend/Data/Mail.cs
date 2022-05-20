using System.ComponentModel.DataAnnotations;

namespace MailSend.Data
{
    public class Mail
    {
        // Id каждой записи БД
        [Key]
        [Required]
        public int Id { get; set; }        
        //  Тема сообщения
        public string? Subject { get; set; }
        // Текст сообщения
        public string? Body { get; set; }
        // Email получателя        
        public string? Email { get; set; }
    }
}
