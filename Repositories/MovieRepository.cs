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
        public async Task CreateMovieAsync(CreateMovieRequest request)
        {
            var movie = new Movie();
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }
            else movie.Name = request.Name;
            if (string.IsNullOrEmpty(request.Description))
            {
                throw new ArgumentNullException(nameof(request.Description));
            }
            else movie.Description = request.Description;
            if (request.ReleaseYear < 1895)
            {
                throw new ArgumentException("Release year must be at least 1895");
            }
            else movie.ReleaseYear = request.ReleaseYear;
            if (string.IsNullOrEmpty(request.Director))
            {
                throw new ArgumentNullException(nameof(request.Director));
            }
            else  movie.Director = request.Director;   
            movie.Status = Status.Active;
            movie.CreatedAt = DateTime.UtcNow;
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _db.Movies.ToListAsync();
        }
        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _db.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
            //return await _db.Movies.FirstOrDefaultAsync( s => s.Id == id );
        }
        public async Task RemoveMovieAsync(int id)
        {
            var movie =  await _db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if(movie == null)
            {
                throw new ArgumentNullException("Movies is not found");
            }
            if(movie.Status == Status.Active)
            {
                movie.Status = Status.Deleted;
            }
            await _db.SaveChangesAsync();
          
        }
        public async Task<Movie?> SearchMovieAsync(SearchMovieRequest request)
        {
            var movie = new Movie();
            if (!string.IsNullOrEmpty(request.Name))
            {
                movie = await _db.Movies.Where(m => m.Name == request.Name).FirstOrDefaultAsync();
                if (movie == null) throw new ArgumentException("movie not found");
                else return movie;
            }
            else if (!string.IsNullOrEmpty(request.Description))
            {
                movie = await _db.Movies.FirstOrDefaultAsync(m => m.Description == request.Description);
                if (movie == null) throw new ArgumentException("movie not found");
                else return movie;
            }
            else if (request.ReleaseYear != 0)
            {
                movie = await _db.Movies.FirstOrDefaultAsync(m => m.ReleaseYear == request.ReleaseYear);
                if (movie == null) throw new ArgumentException("movie not found");
                else return movie;
            }
            else if (!string.IsNullOrEmpty(request.Director))
            {
                movie = await _db.Movies.FirstOrDefaultAsync(m => m.Director == request.Director);
                if(movie == null ) throw new ArgumentException("movie not found");
                else return movie;
            }
            else throw new ArgumentException("movie not found");

        }
        public async Task UpdateMovieAsync(int id, MovieRequest request) 
        {
            var movie = await _db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                throw new ArgumentNullException("Movies is not found");
            }
            movie.Name = request.Name;
            movie.Director = request.Director;
            movie.Description = request.Description;
            movie.ReleaseYear = request.ReleaseYear;
            movie.Status = Status.Active;
            await _db.SaveChangesAsync();
        }
    }
}
