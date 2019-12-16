using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Mail;

namespace MroczekDotDev.ContactForm.Services.EmailSender
{
    public class LocalEmailSender : IEmailSender
    {
        private const string address = "contact@contactform.com";
        private const string displayname = "ContactForm";
        private readonly string pickupDirectory;

        public LocalEmailSender(IWebHostEnvironment env)
        {
            pickupDirectory = Path.Combine(new[] {env.WebRootPath, "EmailPickupDirectory"});
        }

        public void SendEmail(string email, string subject, string message)
        {
            var mail = new MailMessage()
            {
                From = new MailAddress(address, displayname),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            mail.To.Add(new MailAddress(email));


            using (var client = new SmtpClient())
            {
                Directory.CreateDirectory(pickupDirectory);

                client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                client.PickupDirectoryLocation = pickupDirectory;

                client.Send(mail);
            }

            return;
        }
    }
}
