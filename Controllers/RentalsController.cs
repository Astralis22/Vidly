using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        public ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
      
        public ActionResult New()
        {
            return View();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult List()
        {
            var rentals = _context.Rentals.Where( r => r.DateReturned == null ).Include( r => r.Customer).Include( r => r.Movie).ToList();

            return View(rentals);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult EndRental(int id)
        {
            var rental = _context.Rentals.Include( r => r.Movie).SingleOrDefault(r => r.Id == id);

            if (rental == null)
                return HttpNotFound();

            rental.DateReturned = DateTime.Now;

            var movie = _context.Movies.Single( m => m.Id == rental.Movie.Id);
            movie.NumberAvailable++;

            _context.SaveChanges();

            return RedirectToAction("List","Rentals");
        }

    }
}