using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3WebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3WebMvc.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var movieModel = modelBuilder.Entity<Movie>();
            var ticketModel = modelBuilder.Entity<Ticket>();
            var visitorModel = modelBuilder.Entity<Visitor>();


            movieModel.ToTable("Movie").HasMany(m => m.Tickets).WithOne(t => t.Movie);
            ticketModel.ToTable("Ticket");
            visitorModel.ToTable("Visitor").HasMany(v => v.Tickets).WithOne(t => t.Visitor);
        }
    }
}
