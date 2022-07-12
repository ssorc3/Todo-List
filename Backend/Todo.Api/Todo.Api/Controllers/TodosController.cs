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
        if (userId is null) return BadRequest(new { Error = "You must give a userId query parameter." });
        return Ok(_svc.GetAll(userId));
    }
}