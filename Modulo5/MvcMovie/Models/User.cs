namespace MvcMovie.Models;
public class User
{
    public int UserId { get; set; }
    public string? Nome { get; set; }
    public required string Email  {get; set; }
    public required string Password  {get; set; }
}
