using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        [DisplayName("Course ID")]
        public virtual int CourseID { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Course Title")]
        public virtual string title { get; set; }

        [DisplayName("Description")]
        public virtual string description { get; set; }

        [Required]
        [DisplayName("Number of Credits")]
        [Range(1,4,ErrorMessage ="Number of credits must be between 1 and 4")]
        public virtual int credits { get; set; }

    }
}