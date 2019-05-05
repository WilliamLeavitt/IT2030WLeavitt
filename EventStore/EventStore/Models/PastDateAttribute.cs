using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class PastDateAttribute : ValidationAttribute
    {

        readonly DateTime testDate;

        public PastDateAttribute()
        {
            this.testDate = DateTime.Now;
        }

        public PastDateAttribute(DateTime date)
        {
            this.testDate = date;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                if ((DateTime)value < testDate)
                {
                    return new ValidationResult("Date cannot have already passed");
                }
            }
            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
}