using Ecinema_site.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ecinema_site.BusinessLogic.Interfaces
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAll();
        Movie GetById(int id);
        IEnumerable<Movie> GetRelatedMovies(int currentMovieId, int count);
        IEnumerable<Movie> SearchMovies(string searchTerm);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
} 