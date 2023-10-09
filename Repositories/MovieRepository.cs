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
        public async Task CreateMovieAsync(CreateMovieRequest request)
        {
            var movie = new Movie();
            movie.Name = request.Name;
            movie.Director = request.Director;
            movie.Description = request.Description;
            movie.ReleaseYear = request.ReleaseYear;
            movie.Status = Status.Active;
            movie.CreatedAt = DateTime.UtcNow;
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }

    }
}
