using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public int EventId { get; set; }

        public virtual Event EventSelected { get; set; }

        public int Tickets { get; set; }

        public DateTime DateCreated { get; set; }
    }
}