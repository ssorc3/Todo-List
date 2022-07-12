using Todo.Api.Domain;

namespace Todo.Api.Application;

public interface ITodosService
{
    IEnumerable<TodoItem> GetAll(string userId);
}