using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab3WebMvc.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set;}
        public double Starting { get; set;}
        public virtual IList<Ticket> Tickets { get; set;}
    }
}
