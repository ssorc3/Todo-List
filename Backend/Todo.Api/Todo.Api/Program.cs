using Todo.Api.Application;
using Todo.Api.Infrastructure.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<ITodosService, TodosService>();
builder.Services.AddEntityFrameworkTodoStore();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();

public partial class Program {}