using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ecinema_site.Domain.Entities;
using Ecinema_site.Domain;

namespace Ecinema_site.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EcinemaDbContext()));

        // GET: User/Profile
        public ActionResult Profile()
        {
            var userId = User.Identity.GetUserId();
            var user = userManager.FindById(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var model = new {
                Name = user.UserName,
                Email = user.Email
            };
            return View(model);
        }
    }
}