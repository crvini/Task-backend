using MediatR;

namespace Task_backend.Core.Commands;

public class TaskUpdateCommand : IRequest<bool>
{
    public string Id { get; set; }
    public bool IsCompleted { get; set; }
}