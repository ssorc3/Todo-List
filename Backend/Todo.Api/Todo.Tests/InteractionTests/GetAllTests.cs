using System.Net;

namespace Todo.Tests.InteractionTests;

[TestFixture]
public class GetAllTests
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
    public async Task GivenNoUserId_ShouldReturnBadRequest()
    {
        var response = await _client.GetAsync("/todos");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    public async Task GivenAValidUserId_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/todos?userId=test");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}