using MediatR;

namespace Task_backend.Core.Queries;

public class GetTasksQuery : IRequest<IEnumerable<Task_backend.Core.Entities.Task>>
{
    
}