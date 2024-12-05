using System.Text.Json;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.Services;

public class MovieImportService
{
    private readonly MovieDbContext _context;
    private readonly ILogger<MovieImportService> _logger;

    public MovieImportService(MovieDbContext context, ILogger<MovieImportService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task ImportMoviesFromJson(string jsonFilePath)
    {
        try
        {
            var jsonString = await File.ReadAllTextAsync(jsonFilePath);
            var movies = JsonSerializer.Deserialize<List<Movie>>(jsonString);

            if (movies != null)
            {
                await _context.Movies.AddRangeAsync(movies);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Successfully imported {movies.Count} movies");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error importing movies from JSON");
            throw;
        }
    }
}
