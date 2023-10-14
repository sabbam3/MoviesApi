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
            await _movieRepository.CreateMovieAsync(request);   
        }
        [HttpGet("get-all-movies")]
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }
        [HttpGet("get-movie-by-id")]
        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _movieRepository.GetMovieAsync(id);
        }
        [HttpPost("removie-movie")]
        public async Task RemoveMovieAsync(int id)
        {
            await _movieRepository.RemoveMovieAsync(id);
        }
        [HttpPost("search-movie")]
        public async Task<Movie?> SearchMovieAsync([FromBody] SearchMovieRequest request)
        {
            return await _movieRepository.SearchMovieAsync(request);
        }
        [HttpPost("update-movie")]
        public async Task UpdateMovieAsync(int id, MovieRequest request)
        {
            await _movieRepository.UpdateMovieAsync(id, request);
        }

    }
}
