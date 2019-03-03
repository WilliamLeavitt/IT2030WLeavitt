using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student : IValidatableObject
    {
        [DisplayName("Student ID")]
        public virtual int StudentId { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage ="Last Name cannot be more than 50 characters")]
        public virtual string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters")]
        public virtual string FirstName { get; set; }

        //[MinimumAge(20)]
        public virtual int Age { get; set; }

        public virtual string Address1 { get; set; }

        public virtual string Address2 { get; set; }

        public virtual string City { get; set; }

        public virtual string Zipcode { get; set; }

        public virtual string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Age must be at least 20
            if ((int)Age < 20)
            {
                yield return (new ValidationResult("Age cannot be under 20"));
            }

            //Address1 must not be the same as Address2
            if (Address2 == Address1)
            {
                yield return (new ValidationResult("Address2 cannot be the same as Address1"));
            }

            //State must be 2 digits long
            if (State.Length != 2)
            {
                yield return (new ValidationResult("Enter a 2 digit State code."));
            }

            //Zipcode must be 5 digits long
            if (Zipcode.Length != 5)
            {
                yield return (new ValidationResult("Enter a 5 digit Zipcode"));
            }
        }
    }
}