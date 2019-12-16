using Microsoft.AspNetCore.Mvc;

namespace MroczekDotDev.ContactForm.Controllers
{
    public class StatusCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
