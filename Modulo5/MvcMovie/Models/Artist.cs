namespace MvcMovie.Models;
public class Artist
{
    public int ArtistId { get; set; }
    public required string Name { get; set; }
    public string? Bio { get; set; }
    public string? Photo { get; set; }
    public List<Movie>? Movies { get; set; }
}
