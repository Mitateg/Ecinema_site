using System;
using System.Linq;
using System.Web.Mvc;
using Ecinema_site.Domain.Entities;
using Ecinema_site.BusinessLogic.Interfaces;

namespace Ecinema_site.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _movieService.GetAllMovies().ToList();
            return View(movies);
        }

        // GET: Movies/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var movie = _movieService.GetMovieById(id);
            if (movie == null)
                return HttpNotFound("Movie not found");

            // Get two related movies (excluding the current one)
            var relatedMovies = _movieService.GetRelatedMovies(id, 2);
            ViewBag.RelatedMovies = relatedMovies;

            return View(movie);
        }
    }
}