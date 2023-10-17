using Azure.Core;
using Microsoft.Identity.Client;
using MoviesApi.Abstraction;
using MoviesApi.Models;
using MoviesApi.Requests;

namespace MoviesApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateMovieAsync(CreateMovieRequest request)
        {
            var movie = new Movie();
            movie.Name = request.Name;
            movie.Description = request.Description;
            movie.ReleaseYear = request.ReleaseYear;
            movie.Director = request.Director;
            movie.Status = Status.Active;
            movie.CreatedAt = DateTime.UtcNow;
            await _repository.CreateMovieAsync(movie);
            await _repository.SaveChangesAsync();
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _repository.GetAllMoviesAsync();
        }
        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _repository.GetMovieByIdAsync(id);

        }
        public async Task RemoveMovieAsync(int id)
        {
            var movie = await _repository.GetMovieByIdAsync(id);
            
            if (movie.Status == Status.Active)
            {
                movie.Status = Status.Deleted;
            }
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateMovieAsync(int id, UpdateMovieRequest request)
        {
            var movie = await _repository.GetMovieByIdAsync(id);

            movie.Name = request.Name;
            movie.Director = request.Director;
            movie.Description = request.Description;
            movie.ReleaseYear = request.ReleaseYear;

            await _repository.SaveChangesAsync();
        }
        public async Task<List<Movie>?> SearchMovieAsync(SearchMovieRequest request)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                return await _repository.GetMoviesByName(request.Name);
            }
            else return await _repository.GetMoviesByDirector(request.Director);
        }
    }
}
