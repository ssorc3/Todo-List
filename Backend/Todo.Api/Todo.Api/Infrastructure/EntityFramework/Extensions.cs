using Microsoft.EntityFrameworkCore;
using Todo.Api.Application;

namespace Todo.Api.Infrastructure.EntityFramework;

public static class Extensions
{
    public static IServiceCollection AddEntityFrameworkTodoStore(this IServiceCollection services)
    {
        services.AddDbContext<TodoContext>(options => { options.UseInMemoryDatabase("todos"); });
        services.AddTransient<ITodoStore, EntityFrameworkTodoStore>();
        return services;
    }
}