using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Year)
                .IsRequired();

            entity.Property(e => e.Genre)
                .HasMaxLength(100);

            entity.Property(e => e.Rating)
                .HasColumnType("REAL");

            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            entity.HasIndex(e => e.Title);
        });
    }
}
