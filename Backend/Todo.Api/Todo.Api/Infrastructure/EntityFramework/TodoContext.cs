using Microsoft.EntityFrameworkCore;
using Todo.Api.Domain;

namespace Todo.Api.Infrastructure.EntityFramework;

public class TodoContext : DbContext
{
    public DbSet<TodoItem> Todos { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);
    }
}