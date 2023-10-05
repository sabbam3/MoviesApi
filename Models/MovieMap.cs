using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesApi.Models
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey( s => s.Id );
            builder.Property(s => s.Name).HasMaxLength(200).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(2000).IsRequired();
            builder.Property(s => s.ReleaseYear).IsRequired();
            builder.Property(s => s.Director).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
        }
    }
}
