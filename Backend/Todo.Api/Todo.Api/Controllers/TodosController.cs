using Microsoft.AspNetCore.Mvc;
using Todo.Api.Application;
using Todo.Api.Domain;

namespace Todo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodosService _svc;

    public TodosController(ITodosService svc)
    {
        _svc = svc;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> GetAll([FromQuery] string? userId)
    {
        if (string.IsNullOrEmpty(userId)) return BadRequest(new { Error = "You must give a userId query parameter." });
        return Ok(_svc.GetAll(userId));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateTodoRequest request)
    {
        if (string.IsNullOrEmpty(request.UserId)) return BadRequest(new { Error = "You must set UserId" });
        try
        {
            await _svc.CreateTodo(request.UserId, request.Description);
        }
        catch (DomainException e)
        {
            return BadRequest(new { Error = e.Message });
        }

        return Ok();
    }
}