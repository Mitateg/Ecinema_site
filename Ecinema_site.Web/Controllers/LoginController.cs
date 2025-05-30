﻿using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ecinema_site.Domain.Entities;
using Ecinema_site.Domain;

namespace Ecinema_site.Web.Controllers
{
    public class LoginController : Controller
    {
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EcinemaDbContext()));

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string username, string password)
        {
            var user = userManager.Find(username, password);
            if (user != null)
            {
                var authManager = HttpContext.GetOwinContext().Authentication;
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                Session["IsAppUserLoggedIn"] = true;
                return RedirectToAction("Profile", "User");
            }
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

        // GET: Logout
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session["IsAppUserLoggedIn"] = null;
            // Clear anti-forgery cookie
            if (Request.Cookies["__RequestVerificationToken"] != null)
            {
                var cookie = new HttpCookie("__RequestVerificationToken");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}