using MediatR;

namespace Task_backend.Core.Commands;

public class TaskCreateCommand : IRequest<string>
{
    public string? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; } = false;
}