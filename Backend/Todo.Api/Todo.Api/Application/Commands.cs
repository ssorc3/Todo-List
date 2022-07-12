namespace Todo.Api.Application;

public record CreateTodoRequest(string? UserId, string Description);