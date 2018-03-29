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

            var movie = await _context.Movies
        .Include(m => m.Tickets)
            .ThenInclude(t => t.Visitor)
        .AsNoTracking()
        .SingleOrDefaultAsync(m => m.MovieId == id);

            // didn't find any movie with that Id!
            if (movie == null)
            {
                return NotFound();
            }
            //exception handling
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Booking failed, please try again!";
            }
            return View(new Visitor() {  Tickets = new List<Ticket>()});
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
            try
            {
                if (ModelState.IsValid)
                {

                    var movieToBook = (from movie in _context.Movies
                                       where movie.MovieId == id
                                       select movie).Single();

                    for (var i = 0; i < visitor.TicketCount; i++)
                    {
                        if (movieToBook.AvailableSeats == 0)
                        {
                            RedirectToAction(nameof(BookingError), new { id = id, numOfTickets = i});
                        }
                        visitor.Tickets.Add(new Ticket { MovieId = id, VisitorId = visitor.VisitorId });
                        movieToBook.AvailableSeats--;
                        
                    }
                    _context.Visitors.Add(visitor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(BookingSuccess), new { id = id});
                }
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
            return View(visitor);
        }

        //HTTP: GET BookingSuccess
        public IActionResult BookingSuccess(int? id)
        {
            var bookedMovie = (from movie in _context.Movies
                               where movie.MovieId == id
                               select movie).Single();

            var thisCustomer = (from visitor in _context.Visitors
                               where visitor.Tickets.First().MovieId == id
                               select visitor).Last();

                ViewData["SuccessMessage"] = $"You successfully booked {thisCustomer.TicketCount} tickets to the movie  {bookedMovie.Title}. There are currently {bookedMovie.AvailableSeats} seats left for this show!";

            return View();
        }

        public IActionResult BookingError(int? id, int numOfTickets)
        {

            ViewData["ErrorMessage"] = $"There wasn't enough seats left for that order! Do you want to book the{numOfTickets} tickets that is available?";

            return View();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
