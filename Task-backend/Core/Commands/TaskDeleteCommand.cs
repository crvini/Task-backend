using MediatR;

namespace Task_backend.Core.Commands;

public class TaskDeleteCommand : IRequest<bool>
{
    public string Id { get; set; }
}