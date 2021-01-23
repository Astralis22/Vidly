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

        public ActionResult List()
        {
            var rentals = _context.Rentals.Include( r => r.Customer).Include( r => r.Movie).ToList();

            return View(rentals);
        }

        public ActionResult EndRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rental == null)
                return HttpNotFound();

            rental.DateReturned = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("List","Rentals");
        }

    }
}