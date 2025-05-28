using Ecinema_site.Domain.Entities;
using Ecinema_site.BusinessLogic.Interfaces;
using Ecinema_site.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Ecinema_site.BusinessLogic.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly EcinemaDbContext _context;

        public MovieRepository(EcinemaDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> GetAll()
        {
            return _context.Movies;
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public IEnumerable<Movie> GetRelatedMovies(int currentMovieId, int count)
        {
            return _context.Movies
                .Where(m => m.Id != currentMovieId)
                .Take(count)
                .ToList();
        }

        public IEnumerable<Movie> SearchMovies(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Movie>();

            return _context.Movies
                .Where(m => m.Title.Contains(searchTerm) || 
                           m.Genre.Contains(searchTerm) || 
                           m.Description.Contains(searchTerm))
                .ToList();
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
} 