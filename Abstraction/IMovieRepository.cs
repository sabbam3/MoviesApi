using MoviesApi.Models;
using MoviesApi.Requests;

namespace MoviesApi.Abstraction
{
    public interface IMovieRepository
    {
      Task CreateMovieAsync(Movie movie);
      Task<List<Movie>> GetAllMoviesAsync();
      Task<Movie?> GetMovieByIdAsync(int id);
      Task<List<Movie>?> GetMoviesByName(string name);
      Task<List<Movie>?> GetMoviesByDirector(string director);
      Task SaveChangesAsync();
    }
}
