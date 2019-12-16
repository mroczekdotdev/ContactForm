using System.ComponentModel.DataAnnotations;

namespace MroczekDotDev.ContactForm.Models
{
    public class Form
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Subject Subject { get; set; }
        public string Message { get; set; }
    }

    public enum Subject
    {
        [Display(Name = "Say hello")]
        Hello = 1,

        [Display(Name = "Ask a question")]
        Question = 2,

        [Display(Name = "Request a feature")]
        FeatureRequest = 3,

        [Display(Name = "Report a bug")]
        BugReport = 4,
    }
}
