using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecinema_site.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Profile()
        {
            // Fetch user data (mock example)
            var user = new { Name = "John Doe", Email = "john.doe@example.com" };
            return View(user);
        }
    }
}