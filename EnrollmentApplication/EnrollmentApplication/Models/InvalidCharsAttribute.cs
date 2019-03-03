using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string invalidChar;

        public InvalidCharsAttribute(string invalidChar) :base("{0} contains invalid characters!")
        {
            this.invalidChar = invalidChar;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().Contains(invalidChar))
            {
                var errormessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errormessage);
            }
            return ValidationResult.Success;
        }
    }
}