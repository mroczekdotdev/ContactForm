using System.Threading.Tasks;

namespace MroczekDotDev.ContactForm.Services.EmailSender
{
    public interface IEmailSender
    {
        public void SendEmail(string email, string subject, string htmlMessage);
    }
}
