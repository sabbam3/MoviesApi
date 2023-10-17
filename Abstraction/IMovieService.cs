using MoviesApi.Models;
using MoviesApi.Requests;

namespace MoviesApi.Abstraction
{
    public interface IMovieService
    {
        Task CreateMovieAsync(CreateMovieRequest request);
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieAsync(int id);
        Task RemoveMovieAsync(int id);
        Task UpdateMovieAsync(int id, UpdateMovieRequest request);
        Task<List<Movie>?> SearchMovieAsync(SearchMovieRequest request);
    }
}
