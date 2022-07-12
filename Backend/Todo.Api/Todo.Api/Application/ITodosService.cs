using Todo.Api.Domain;

namespace Todo.Api.Application;

public interface ITodosService
{
    IEnumerable<TodoItem> GetAll(string userId);
    Task CreateTodo(string userId, string description);
    Task SetComplete(string userId, int todoId, bool completed);
}