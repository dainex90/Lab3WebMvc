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

        [Required(ErrorMessage = "Enter the issued date.")]
        [DataType(DataType.Date)]
        public DateTime Starting { get; set;}

        [Display(Name = "Available Seats")]
        public int AvailableSeats { get; set; }
        public virtual IList<Ticket> Tickets { get; set;}
    }
}
