using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3WebMvc.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set;}
        // Datetime ??
        public double Starting { get; set;}
        public int AvailableSeats { get; set; }
        public virtual IList<Ticket> Tickets { get; set;}
    }
}
