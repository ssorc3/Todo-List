using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Todo.Api.Controllers;
using Todo.Api.Domain;

namespace Todo.Tests.InteractionTests;

[TestFixture]
public class CreateTodoTests
{
    private TodoWebApplicationFactory _factory;
    private HttpClient _client;

    [SetUp]
    public void SetUp()
    {
        _factory = new TodoWebApplicationFactory();

        _client = _factory.CreateClient();
    }

    [Test]
    public async Task GivenAnInvalidTodo_ReturnBadRequest()
    {
        var input = new CreateTodoRequest("Test", "");
        var response = await _client.PostAsync("/todos", new StringContent(
            JsonSerializer.Serialize(input),
            Encoding.UTF8,
            "application/json"
        ));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    public async Task GivenAValidTodo_ReturnOk()
    {
        var input = new CreateTodoRequest("Test", "An example todo");
        var response = await _client.PostAsync("/todos", new StringContent(
            JsonSerializer.Serialize(input),
            Encoding.UTF8,
            "application/json"
        ));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task AddingATodo_IncreasesTheNumberOfTodos()
    {
        const string userId = "Test";
        const string description = "An example todo";
        var response1 = await _client.GetAsync($"/todos?userId={userId}");
        var items1 = await response1.Content.ReadFromJsonAsync<TodoItem[]>();
        Assert.That(items1, Has.Length.EqualTo(0));

        var input = new CreateTodoRequest("Test", "An example todo");
        var response = await _client.PostAsync("/todos", new StringContent(
            JsonSerializer.Serialize(input),
            Encoding.UTF8,
            "application/json"
        ));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var response2 = await _client.GetAsync($"/todos?userId={userId}");
        var items2 = await response2.Content.ReadFromJsonAsync<TodoItem[]>();
        Assert.That(items2, Has.Length.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(items2![0].Description, Is.EqualTo(description));
            Assert.That(items2![0].CreatedBy, Is.EqualTo(userId));
        });
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}