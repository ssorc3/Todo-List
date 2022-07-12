using Todo.Api.Domain;

namespace Todo.Tests.UnitTests;

[TestFixture]
public class TodoItemTests
{
    [Test]
    public void GivenValidInputs_CanCreateTodo()
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

    [Test]
    public void GivenEmptyDescription_CannotCreateTodo()
    {
        Assert.Throws<DomainException>(() =>
        {
            _ = new TodoItem("TestUser", "");
        });
    }

    [Test]
    public void CompleteTodoSucceeds()
    {
        var todo1 = new TodoItem("TestUser", "An example todo");
        Assert.That(todo1.Completed, Is.False);
        
        todo1.SetCompleted(true);
        Assert.That(todo1.Completed, Is.True);
    }
}