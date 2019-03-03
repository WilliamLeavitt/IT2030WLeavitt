using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Enrollment
    {
        public virtual int EnrollmentID { get; set; }
        public virtual int StudentID { get; set; }
        public virtual int CourseID { get; set; }

        [Required]
        [RegularExpression(@"[A-F]$",ErrorMessage ="Grade must be A - F only")]
        public virtual string grade { get; set; }
        public virtual Student student { get; set; }
        public virtual Course course { get; set; }
        public virtual bool IsActive { get; set; }

        [Required]
        [DisplayName("Assigned Campus")]
        public virtual string AssignedCampus { get; set; }

        [Required]
        [DisplayName("Enrolled in Semester")]
        public virtual string EnrollmentSemester { get; set; }

        [Required]
        [Range(2018,Int32.MaxValue,ErrorMessage ="Cannot be enrolled before 2018")]
        public virtual int EnrollmentYear { get; set; }

        [InvalidChars("-", ErrorMessage ="No hyphens allowed in Notes")]
        public virtual string Notes { get; set; }
    }
}