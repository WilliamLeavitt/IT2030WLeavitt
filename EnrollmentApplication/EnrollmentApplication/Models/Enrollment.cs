﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Enrollment
    {
        public virtual int EnrollmentID { get; set; }
        public virtual int StudentID { get; set; }
        public virtual int CourseID { get; set; }
        public virtual string grade { get; set; }
        public virtual Student student { get; set; }
        public virtual Course course { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string AssignedCampus { get; set; }
        public virtual string EnrollmentSemester { get; set; }
        public virtual int EnrollmentYear { get; set; }
    }
}