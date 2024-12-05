using System.Text.Json;
using MoviesApp.Data;
using MoviesApp.Models;
using Microsoft.Extensions.Options;

namespace MoviesApp.Services;

public class MovieImportService
{
    private readonly MovieDbContext _context;
    private readonly ILogger<MovieImportService> _logger;
    private readonly MovieImportOptions _options;

    public MovieImportService(
        MovieDbContext context, 
        ILogger<MovieImportService> logger,
        IOptions<MovieImportOptions> options)
    {
        _context = context;
        _logger = logger;
        _options = options.Value;
    }

    public async Task ImportMoviesFromJson(string jsonFilePath = null)
    {
        try
        {
            jsonFilePath ??= _options.JsonFilePath;
            _logger.LogInformation($"Reading JSON from: {jsonFilePath}");
            
            if (!File.Exists(jsonFilePath))
            {
                _logger.LogError($"File not found at path: {jsonFilePath}");
                throw new FileNotFoundException($"JSON file not found at: {jsonFilePath}");
            }

            var jsonString = await File.ReadAllTextAsync(jsonFilePath);
            _logger.LogInformation($"JSON content length: {jsonString.Length}");
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            
            var movies = JsonSerializer.Deserialize<List<Movie>>(jsonString, options)?
                .Where(m => !string.IsNullOrEmpty(m.Title))
                .ToList();

            if (movies != null && movies.Any())
            {
                // Clear existing movies first
                _context.Movies.RemoveRange(_context.Movies);
                await _context.SaveChangesAsync();
                
                await _context.Movies.AddRangeAsync(movies);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Successfully imported {movies.Count} movies");
            }
            else
            {
                throw new InvalidOperationException("No valid movies were found in the JSON file");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error importing movies from JSON");
            throw;
        }
    }
}
