using System;
using System.IO;
using System.Web;
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
            return View(user);
        }

        // POST: User/UpdateProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(string FirstName, string LastName, string PhoneNumber, HttpPostedFileBase ProfilePicture)
        {
            var userId = User.Identity.GetUserId();
            var user = userManager.FindById(userId);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            try
            {
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.PhoneNumber = PhoneNumber;

                if (ProfilePicture != null && ProfilePicture.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ProfilePicture.FileName);
                    var uniqueFileName = $"{userId}_{DateTime.Now.Ticks}_{fileName}";
                    var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/Profiles"), uniqueFileName);
                    
                    // Ensure directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(uploadPath));
                    
                    ProfilePicture.SaveAs(uploadPath);
                    user.ProfilePicture = $"/Content/Images/Profiles/{uniqueFileName}";
                }

                var result = userManager.Update(user);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = string.Join(", ", result.Errors) });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}