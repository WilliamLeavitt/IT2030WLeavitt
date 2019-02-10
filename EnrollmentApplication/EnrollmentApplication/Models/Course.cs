using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        public virtual int CourseID { get; set; }
        public virtual string title { get; set; }
        public virtual string description { get; set; }
        public virtual int credits { get; set; }

    }
}