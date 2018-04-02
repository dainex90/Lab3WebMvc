using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Lab3WebMvc.Data;
using System.Globalization;
using System.Threading;

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
                         Starting = DateTime.Parse("2018-04-01 17:20:00", CultureInfo.InvariantCulture),
                         AvailableSeats = 50

                     },
                     new Movie
                     {
                         Title = "Tomb Raider",
                         Starting = DateTime.Parse("2018-04-01 19:20:00", CultureInfo.InvariantCulture),
                         AvailableSeats = 50

                     },
                     new Movie
                     {
                         Title = "Pacific Rim Uprising",
                         Starting = DateTime.Parse("2018-04-01 21:20:00", CultureInfo.InvariantCulture),
                         AvailableSeats = 50
                     },
                     new Movie
                     {
                         Title = "Avengers: Infinity War",
                         Starting = DateTime.Parse("2018-04-01 23:20:00", CultureInfo.InvariantCulture),
                         AvailableSeats = 50
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
