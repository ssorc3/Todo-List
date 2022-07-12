using Todo.Api.Domain;

namespace Todo.Tests.UnitTests;

[TestFixture]
public class TodoItemTests
{
    [Test]
    public void CanCreateATodoItem()
    {
        const string description = "An example item";
        const string userId = "TestUser";
        
        var todo = new TodoItem("TestUser", "An example item");
        
        Assert.Multiple(() =>
        {
            Assert.That(todo.Description, Is.EqualTo(description));
            Assert.That(todo.CreatedBy, Is.EqualTo(userId));
        });
    }
}