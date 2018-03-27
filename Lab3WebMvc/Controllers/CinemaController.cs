using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3WebMvc.Data;
using Lab3WebMvc.Models;

namespace Lab3WebMvc.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaContext _context;

        public CinemaController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Cinema
        public async Task<IActionResult> Index()
        {
            var movies = _context.Movies.Include(m => m.Tickets);
            return View(await movies.ToListAsync());
        }

        //GET: Booking
        public async Task<IActionResult> Booking(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.AsNoTracking().SingleOrDefaultAsync(m => m.MovieId == id);
            
            // didn't find any movie with that Id!
            if (movie == null)
            {
                return NotFound();
            }

            //exception handling
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again, and if the problem persists " +
            "see your system administrator.";
            }
            return View(new Visitor());
        }

        //POST: Booking
        [HttpPost]
        public async Task<IActionResult> Booking(int id, [Bind("Name,TicketCount,Tickets")] Visitor visitor)
        {
            // EXEMPEL CSHTML HYPERLINK KOD!!!
            // <a asp-action="Index" asp-route-sortOrder="@ViewData["NameSortParm"]">@Html.DisplayNameFor(model => model.LastName)</a>

            /*if (id != movie.MovieId)
            {
                return NotFound();
            }*/

            //if (ModelState.IsValid)
            //{

            try
            {

                    for (var i = 0; i < visitor.TicketCount; i++)
                    {
                        visitor.Tickets.Add(new Ticket{ MovieId = id, VisitorId = visitor.VisitorId });

                    }
                    foreach (var ticket in visitor.Tickets)
                    {
                        ticket.Movie.SeatsTaken += 1;
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                catch (DbUpdateException)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    return RedirectToAction(nameof(Booking), new { id = id, saveChangesError = true });
                }
                /*try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }*/
                //return RedirectToAction(nameof(Index));

            //}
            //return View(movie);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
