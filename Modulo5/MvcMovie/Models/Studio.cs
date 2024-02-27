namespace MvcMovie.Models;
public class Studio
{
    public int StudioId { get; set; }
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }
    public List<Movie>? Movies { get; set; }
}
