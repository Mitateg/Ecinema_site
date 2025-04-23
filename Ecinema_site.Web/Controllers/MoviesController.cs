using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecinema_site.Web.Controllers
{
    public class MoviesController : Controller
    {
        // Sample movie data - in a real app, this would come from a database
        private static List<dynamic> _movies = new List<dynamic>
        {
            new { 
                Id = 1, 
                Title = "Alien", 
                Description = "In deep space, the crew of the commercial starship Nostromo is awakened from their cryo-sleep capsules halfway through their journey home to investigate a distress call from an alien vessel.", 
                Year = 1979, 
                Genre = "Action, Adventure, Horror", 
                Rating = 4.5, 
                ImagePath = "~/Content/Images/Movies/Movie_poster_1.png", 
                VideoPath = "~/Content/Videos/sample.mp4" 
            },
            new { 
                Id = 2, 
                Title = "Fight Club", 
                Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", 
                Year = 1999, 
                Genre = "Drama, Thriller", 
                Rating = 4.7, 
                ImagePath = "~/Content/Images/Movies/Movie_poster_2.png", 
                VideoPath = "~/Content/Videos/sample.mp4" 
            },
            new { 
                Id = 3, 
                Title = "The Goonies", 
                Description = "A group of young misfits called The Goonies discover an ancient map and set out on an adventure to find a legendary pirate's long-lost treasure.", 
                Year = 1985, 
                Genre = "Adventure, Comedy", 
                Rating = 4.8, 
                ImagePath = "~/Content/Images/Movies/Movie_poster_3.png", 
                VideoPath = "~/Content/Videos/sample.mp4" 
            }
        };

        public ActionResult Index()
        {
            // Pass the list of movies to the view
            return View(_movies);
        }

        public ActionResult Details(int id)
        {
            try
            {
                // Find the movie with the specified ID
                var movie = _movies.FirstOrDefault(m => m.Id == id);
                
                // If movie not found, return 404
                if (movie == null)
                {
                    return HttpNotFound();
                }
                
                // Pass the movie to the view
                return View(movie);
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine($"Error in Details action: {ex.Message}");
                
                // Return a default movie if there's an error
                return View(new { 
                    Id = id, 
                    Title = "Movie Details", 
                    Description = "Movie information could not be loaded.", 
                    Genre = "N/A", 
                    Year = 0, 
                    Rating = 0.0, 
                    ImagePath = "~/Content/Images/Movies/Movie_poster_1.png",
                    VideoPath = "~/Content/Videos/sample.mp4"
                });
            }
        }
    }
}