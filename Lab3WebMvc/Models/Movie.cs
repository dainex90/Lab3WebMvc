using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab3WebMvc.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set;}
        public float Starting { get; set;}
        public virtual IList<Ticket> Tickets { get; set;}
    }
}
