using Todo.Api.Domain;

namespace Todo.Api.Application;

public interface ITodoStore
{
    IEnumerable<TodoItem> GetAll(string userId);
}