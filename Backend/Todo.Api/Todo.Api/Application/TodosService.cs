using Todo.Api.Domain;

namespace Todo.Api.Application;

public class TodosService : ITodosService
{
    private readonly ITodoStore _store;

    public TodosService(ITodoStore _store)
    {
        this._store = _store;
    }

    public IEnumerable<TodoItem> GetAll(string userId)
    {
        return _store.GetAll(userId);
    }

    public async Task CreateTodo(string userId, string description)
    {
        var todo = new TodoItem(userId, description);
        await _store.Save(todo);
    }

    public Task SetComplete(string userId, int todoId, bool completed)
    {
        return _store.WithTodo(userId, todoId, todo =>
        {
            if (todo is null) throw new ApplicationException($"Could not find an item for {userId} with id {todoId}.");
            todo.SetCompleted(completed);
        });
    }
}