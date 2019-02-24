using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student
    {
        [DisplayName("Student ID")]
        public virtual int StudentId { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public virtual string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public virtual string FirstName { get; set; }
    }
}