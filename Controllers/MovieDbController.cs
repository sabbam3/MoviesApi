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
 
        private readonly IMovieService _movieService;
        private readonly ValidateRequests _validateRequests;
        public MovieDbController(IMovieService movieService, ValidateRequests validateRequests)
        {
            _movieService = movieService;
            _validateRequests = validateRequests;
        }
        [HttpPost("add-movie")]
        public async Task CreateMovieAsync(CreateMovieRequest request)
        {
            _validateRequests.ValidateCreateRequest(request);   
            await _movieService.CreateMovieAsync(request);   
        }
        [HttpGet("get-all-movies")]
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieService.GetAllMoviesAsync();
        }
        [HttpGet("get-movie-by-id")]
        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _movieService.GetMovieAsync(id);
        }
        [HttpPost("remove-movie")]
        public async Task RemoveMovieAsync(int id)
        {
            await _movieService.RemoveMovieAsync(id);
        }
        [HttpPost("search-movie")]
        public async Task<List<Movie>?> SearchMovieAsync([FromBody] SearchMovieRequest request)
        {
            _validateRequests.ValidateSearchMovieRequest(request);
            return await _movieService.SearchMovieAsync(request);
        } 
        [HttpPost("update-movie")]
        public async Task UpdateMovieAsync(int id, UpdateMovieRequest request)
        {
            _validateRequests.ValidateUpdateRequest(request);
            await _movieService.UpdateMovieAsync(id, request);
        }

    } 
}
