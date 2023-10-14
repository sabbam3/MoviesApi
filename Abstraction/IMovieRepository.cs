using MoviesApi.Models;
using MoviesApi.Requests;

namespace MoviesApi.Abstraction
{
    public interface IMovieRepository
    {
      Task CreateMovieAsync(CreateMovieRequest request);
      Task<List<Movie>> GetAllMoviesAsync();
      Task<Movie?> GetMovieAsync(int id);
      Task RemoveMovieAsync(int id);
      Task<Movie?> SearchMovieAsync(SearchMovieRequest request);
      Task UpdateMovieAsync(int id, MovieRequest request);
    }
}
