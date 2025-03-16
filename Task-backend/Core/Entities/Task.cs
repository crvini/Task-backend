namespace Task_backend.Core.Entities;

public class Task : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}