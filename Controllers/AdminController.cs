using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
            var users = _context.Users.Include( u => u.Roles).ToList();

            var roleStore = new RoleStore<IdentityRole>(_context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userViewModels = new List<UserViewModel>();

            foreach ( var user in users)
            {
                var userViewModel = new UserViewModel
                {
                    User = user,
                    Roles = new List<string>(),
                };

                var roleIdList = user.Roles.Select(r => r.RoleId);
                foreach ( var roleId in roleIdList)
                {
                    var roleName = roleManager.FindById(roleId).Name;
                    userViewModel.Roles.Add(roleName);
                }
                userViewModels.Add(userViewModel);
            }
            return View(userViewModels);
        }

        public ActionResult Roles()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        public ActionResult NewRole()
        {
            var role = new IdentityRole();
            return View("NewRole", role);
        }

        [HttpPost]
        public ActionResult SaveRole(IdentityRole role)
        {
            //_context.Roles.Add(role);
            //_context.SaveChanges();

            var roleStore = new RoleStore<IdentityRole>(_context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            roleManager.Create(role);


            return RedirectToAction("Roles", "Admin");
        }

        public ActionResult DeleteRole(string id)
        {
            //var roleInDb = _context.Roles.SingleOrDefault(r => r.Id == id);

            //if(roleInDb == null)
            //    return HttpNotFound();

            var roleStore = new RoleStore<IdentityRole>(_context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roleIndDb = roleManager.FindById(id);
            roleManager.Delete(roleIndDb);

            //_context.Roles.Remove(roleInDb);
            //_context.SaveChanges();

            return RedirectToAction("Roles", "Admin");
        }

        public ActionResult AssignRole(string id)
        {

            var user = _context.Users.Include(u => u.Roles).SingleOrDefault(u => u.Id == id);

            var userViewModel = new UserViewModel
            {
                User = user,
                Roles = new List<string>(),
                RolesInDb = _context.Roles.ToList()
            };

            var roleIdList = userViewModel.User.Roles.Select ( r => r.RoleId);
            foreach (var roleId in roleIdList)
            {
                var roleName = userViewModel.RolesInDb.SingleOrDefault( r => r.Id == roleId).Name;
                userViewModel.Roles.Add(roleName);
            }

            return View(userViewModel);
        }

        public ActionResult AddToRole(string userId, string roleId)
        {

            var roleStore = new RoleStore<IdentityRole>(_context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roleInDb = roleManager.FindById(roleId);

            var userStore = new UserStore<IdentityUser>(_context);
            var userManager = new UserManager<IdentityUser>(userStore);
            var userInDb = userManager.FindById(userId);

            userManager.AddToRole(userInDb.Id, roleInDb.Name);

            return RedirectToAction("Users", "Admin");
        }
    }
}