using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Todo.Tests.InteractionTests;

[TestFixture]
public class GetAllTests
{
    private HttpClient _client;

    [SetUp]
    public void SetUp()
    {
        var application = new WebApplicationFactory<Program>();

        _client = application.CreateClient();
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
}