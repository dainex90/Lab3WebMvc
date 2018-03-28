using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab3WebMvc.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }

        public int TicketCount { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
    }
}
