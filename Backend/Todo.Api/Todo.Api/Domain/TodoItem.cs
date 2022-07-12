namespace Todo.Api.Domain;

public class TodoItem
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string CreatedBy { get; private set; }

    public TodoItem(string createdBy, string description)
    {
        Id = 0;
        Description = description;
        CreatedBy = createdBy;
    }
}