using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventStore.Models
{
    public class Event
    {
        public virtual int EventID { get; set; }

        public virtual int EventTypeID { get; set; }

        [StringLength(50)]
        public virtual string Title { get; set; }

        [StringLength(150)]
        public virtual string Description { get; set; }

        [PastDate()]
        public virtual DateTime StartDate { get; set; }

        [PastDate()]
        public virtual DateTime EndDate { get; set; }

        public virtual string Organizer { get; set; }

        public virtual string ContactInfo { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Must have at least 1 ticket")]
        public virtual int MaxTickets { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Must have at least 1 ticket")]
        public virtual int AvailTickets { get; set; }

        public virtual EventType Type { get; set; }
    }
}