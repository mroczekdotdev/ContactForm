using Microsoft.AspNetCore.Mvc;
using MroczekDotDev.ContactForm.Models;
using MroczekDotDev.ContactForm.Services.EmailSender;
using MroczekDotDev.ContactForm.Services.Repository;
using System.Diagnostics;

namespace MroczekDotDev.ContactForm.Controllers
{
    public class HomeController : Controller
    {
        private const string emailSubject = "Thank you for contacting ContactForm";

        private const string emailMessage =
            "<p>Hello {0},</p>" +
            "<p>We have received your message.</p>" +
            "<p>Best regards,<br>" +
            "ContactForm</p>";

        private readonly IRepository repository;
        private readonly IEmailSender emailSender;

        public static string Name { get; } = nameof(HomeController)
            .Substring(0, nameof(HomeController)
            .LastIndexOf(nameof(Controller)));

        public HomeController(
            IRepository repository,
            IEmailSender emailSender)
        {
            this.repository = repository;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View(new FormViewModel());
        }

        [HttpPost]
        public IActionResult Index(FormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            repository.AddForm(form);
            emailSender.SendEmail(form.Email, emailSubject, string.Format(emailMessage, form.FirstName));

            var success = new SuccessViewModel
            {
                Name = form.FirstName,
            };

            return RedirectToAction("Success", success);
        }

        public IActionResult Success(SuccessViewModel success)
        {
            return View(success);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
