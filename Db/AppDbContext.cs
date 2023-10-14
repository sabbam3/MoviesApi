using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
