using Ecinema_site.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ecinema_site.BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        IQueryable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetRelatedMovies(int currentMovieId, int count);
        IEnumerable<Movie> SearchMovies(string searchTerm);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
} 