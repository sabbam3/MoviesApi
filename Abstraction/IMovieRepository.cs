using MoviesApi.Models;
using MoviesApi.Requests;

namespace MoviesApi.Abstraction
{
    public interface IMovieRepository
    {
      Task CreateMovieAsync(CreateMovieRequest request);
      
    }
}
