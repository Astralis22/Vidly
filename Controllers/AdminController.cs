using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public ActionResult Roles()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }


        public ActionResult SaveRole(IdentityRole role)
        {
            _context.Roles.Add(role);
            return View();
        }
    }
}