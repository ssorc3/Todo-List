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
}