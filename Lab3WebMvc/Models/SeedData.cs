using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Lab3WebMvc.Data;


namespace Lab3WebMvc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CinemaContext(
                serviceProvider.GetRequiredService<DbContextOptions<CinemaContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                     new Movie
                     {
                         Title = "12 Strong",
                         Starting = 17.00

                     },
                     new Movie
                     {
                         Title = "Tomb Raider",
                         Starting = 19.00

                     },
                     new Movie
                     {
                         Title = "Pacific Rim Uprising",
                         Starting = 21.00

                     },
                     new Movie
                     {
                         Title = "Avengers: Infinity War",
                         Starting = 23.00
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
