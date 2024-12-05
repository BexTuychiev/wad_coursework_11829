using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int Year { get; set; }

    [MaxLength(100)]
    public string Genre { get; set; } = string.Empty;

    [Range(0, 10)]
    public decimal Rating { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }
}
