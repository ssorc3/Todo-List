using System.Net;
using System.Text;
using System.Text.Json;
using Todo.Api.Controllers;

namespace Todo.Tests.InteractionTests;

[TestFixture]
public class MarkCompletedTests
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
    public async Task GivenAValidUserIdAndTodoId_ReturnOK()
    {
        var response = await _client.PutAsync($"/todos/{_factory.TodoId}", new StringContent(JsonSerializer.Serialize(new SetCompleteRequest("TestUser", true)), Encoding.UTF8, "application/json"));
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
    }
}