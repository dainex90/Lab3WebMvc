using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab3WebMvc.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set;}

        // Foreign Keys! Behövs dom?
        public int MovieId { get; set; }
        public int VisitorId { get; set;}

        public int Count { get; set; }
        public Movie Movie { get; set; }
        public Visitor Visitor { get; set; }
    }
}
