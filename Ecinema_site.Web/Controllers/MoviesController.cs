using System;
using System.Linq;
using System.Web.Mvc;
using Ecinema_site.Domain;
using Ecinema_site.Domain.Entities;

namespace Ecinema_site.Web.Controllers
{
    public class MoviesController : Controller
    {
        private EcinemaDbContext db = new EcinemaDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.ToList();
            return View(movies);
        }

        // GET: Movies/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var movie = db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound("Movie not found");

            // Get two related movies (excluding the current one)
            var relatedMovies = db.Movies.Where(m => m.Id != id).Take(2).ToList();
            ViewBag.RelatedMovies = relatedMovies;

            return View(movie);
        }
    }
}