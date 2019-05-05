using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class EventType
    {
        [Key]
        public virtual int EventTypeID { get; set; }

        [StringLength(50)]
        public virtual string Type { get; set; }
    }
}