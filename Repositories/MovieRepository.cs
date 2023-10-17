using Microsoft.EntityFrameworkCore;
using MoviesApi.Abstraction;
using MoviesApi.Db;
using MoviesApi.Models;
using MoviesApi.Requests;

namespace MoviesApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task CreateMovieAsync(Movie movie)
        {
            await _db.Movies.AddAsync(movie);
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _db.Movies.ToListAsync();
        }
        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _db.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Movie>?> GetMoviesByName(string name)
        {
            return await _db.Movies.Where( m => m.Name == name).ToListAsync();
        }
        public async Task<List<Movie>?> GetMoviesByDirector(string director)
        {
            return await _db.Movies.Where(m => m.Director == director).ToListAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
