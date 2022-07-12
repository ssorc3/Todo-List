using Todo.Api.Domain;

namespace Todo.Api.Application;

public interface ITodoStore
{
    IEnumerable<TodoItem> GetAll(string userId);
    Task Save(TodoItem todo);
    Task WithTodo(string userId, int todoId, Action<TodoItem?> action);
}