using Microsoft.EntityFrameworkCore;
namespace Semana1.TodoApi;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}