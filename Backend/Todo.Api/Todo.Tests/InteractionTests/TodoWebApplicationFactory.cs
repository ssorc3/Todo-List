using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Todo.Api.Domain;
using Todo.Api.Infrastructure.EntityFramework;

namespace Todo.Tests.InteractionTests;

public class TodoWebApplicationFactory : WebApplicationFactory<Program>
{
    private TodoContext? _context;
    public int TodoId { get; private set; }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(ConfigureServices);
    }

    private void ConfigureServices(WebHostBuilderContext webHostBuilderContext, IServiceCollection services)
    {
        var builtServiceProvider = services.BuildServiceProvider();
        using var scopedProvider = builtServiceProvider.CreateScope();

        var scopedServiceProvider = scopedProvider.ServiceProvider;

        var service = scopedServiceProvider.GetRequiredService<TodoContext>();
        _context = service;

        _context.Add(new TodoItem("TestUser", "An example todo"));
        _context.SaveChanges();

        TodoId = _context.Todos.First().Id;
    }
}