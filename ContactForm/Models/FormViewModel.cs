using MroczekDotDev.ContactForm.Attributes.Validation;
using System.ComponentModel.DataAnnotations;

namespace MroczekDotDev.ContactForm.Models
{
    public class FormViewModel
    {
        private const string namePattern =
            "^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$";

        [Required]
        [StringLength(36, ErrorMessage = "{0} length must be between {2} and {1} characters.", MinimumLength = 1)]
        [RegularExpression(namePattern, ErrorMessage = "{0} must contain only letters.")]
        [Display(Name = "First Name", Prompt = "Enter your first name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(36, ErrorMessage = "{0} length must be between {2} and {1} characters.", MinimumLength = 1)]
        [RegularExpression(namePattern, ErrorMessage = "{0} must contain only letters.")]
        [Display(Name = "Last Name", Prompt = "Enter your last name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail", Prompt = "Enter your e-mail address")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?\+?[0-9]{1,4}\)?([-. ]?[0-9]{1,4}){2,4}$",
            ErrorMessage = "The {0} field is not a valid phone number.")]
        [Display(Prompt = "Enter your phone number")]
        public string Phone { get; set; }

        [Required]
        [Subject(ErrorMessage = "The {0} field is not a valid subject.")]
        public string Subject { get; set; }

        [Required]
        [StringLength(360, ErrorMessage = "{0} length must be between {2} and {1} characters.", MinimumLength = 3)]
        [Display(Prompt = "Write your message in 360 characters or less")]
        public string Message { get; set; }
    }
}
