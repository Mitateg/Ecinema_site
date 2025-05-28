using Ecinema_site.Domain.Entities;
using Ecinema_site.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ecinema_site.BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public IEnumerable<Movie> GetRelatedMovies(int currentMovieId, int count)
        {
            return _movieRepository.GetRelatedMovies(currentMovieId, count);
        }

        public IEnumerable<Movie> SearchMovies(string searchTerm)
        {
            return _movieRepository.SearchMovies(searchTerm);
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.Delete(id);
        }
    }
} 