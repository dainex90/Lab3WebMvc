using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab3WebMvc.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
    }
}
