using Todo.Api.Application;
using Todo.Api.Domain;

namespace Todo.Api.Infrastructure.EntityFramework;

public class EntityFrameworkTodoStore : ITodoStore
{
    private readonly TodoContext _ctx;

    public EntityFrameworkTodoStore(TodoContext ctx)
    {
        _ctx = ctx;
    }
    
    public IEnumerable<TodoItem> GetAll(string userId)
    {
        return _ctx.Todos.Where(x => x.CreatedBy == userId);
    }

    public async Task Save(TodoItem todo)
    {
        await _ctx.AddAsync(todo);
        await _ctx.SaveChangesAsync();
    }
}