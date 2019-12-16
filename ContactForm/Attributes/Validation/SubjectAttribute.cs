using MroczekDotDev.ContactForm.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MroczekDotDev.ContactForm.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    sealed public class SubjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = value as string ?? "";

            if (!Enum.TryParse<Subject>(input, out _) || input?.Length == 0)
            {
                return new ValidationResult(GetErrorMessage(validationContext.DisplayName, input));
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        public string GetErrorMessage(string displayName, string input)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, displayName, input);
        }
    }
}
