using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecinema_site.Domain;
using Ecinema_site.Domain.Entities;

namespace Ecinema_site.Web.Controllers
{
    public class SearchController : Controller
    {
        private EcinemaDbContext db = new EcinemaDbContext();

        // GET: Search
        public ActionResult Index(string name = null, List<string> genres = null)
        {
            var allGenres = db.Movies
                .AsEnumerable()
                .SelectMany(m => m.Genre.Split(','))
                .Select(g => g.Trim())
                .Distinct()
                .OrderBy(g => g)
                .ToList();

            var movies = db.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                movies = movies.Where(m => m.Title.Contains(name));
            }
            if (genres != null && genres.Any())
            {
                movies = movies.Where(m => genres.Any(g => m.Genre.Contains(g)));
            }

            ViewBag.AllGenres = allGenres;
            ViewBag.SelectedGenres = genres ?? new List<string>();
            ViewBag.SearchName = name;

            return View(movies.ToList());
        }
    }
}