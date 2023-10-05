using Microsoft.AspNetCore.Mvc;
using MoviesApi.Abstraction;
using MoviesApi.Models;
using MoviesApi.Repositories;
using MoviesApi.Requests;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("movie/[controller]")]
    public class MovieDbController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieDbController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository; 

        }
        [HttpPost("AddMovie")]
        public async Task CreateMovieAsync(CreateMovieRequest request)
        {
            if(string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }
            if(string.IsNullOrEmpty(request.Description))
            {
                throw new ArgumentNullException(nameof(request.Description));
            }
            if(request.ReleaseYear < 1895)
            {
                throw new ArgumentException("Release year must be at least 1895");
            }
            if (string.IsNullOrEmpty(request.Director))
            {
                throw new ArgumentNullException(nameof(request.Director));
            }
            await _movieRepository.CreateMovieAsync(request);
            
        }
    }
}
