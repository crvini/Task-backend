using AutoMapper;
using MediatR;
using Task_backend.Core.Commands;
using Task_backend.Core.Interfaces;
using Task_backend.Core.Queries;
using Task = Task_backend.Core.Entities.Task;

namespace Task_backend.Infrastructure.Handlers;

public class TaskEventHandler : IRequestHandler<TaskCreateCommand,string>,
    IRequestHandler<TaskUpdateCommand,bool>,
    IRequestHandler<TaskDeleteCommand, bool>,
    IRequestHandler<GetTasksQuery, IEnumerable<Task_backend.Core.Entities.Task>>

{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaskEventHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<string> Handle(TaskCreateCommand request, CancellationToken cancellationToken)
    {
       
        var task = await _unitOfWork.taskRepository.GetByIdAsync(request.Id);
        if (task is null)
        {
            task = _mapper.Map<Task_backend.Core.Entities.Task>(request);
            await _unitOfWork.taskRepository.InsertAsync(task);
        }
        else
        {
            task.Title = request.Title;
            task.Description = request.Description;
            task.Status = request.Status;
            _unitOfWork.taskRepository.Update(task);
        }
        await _unitOfWork.SaveChangeAsync();
        return task.Id;
    }

    public async Task<bool> Handle(TaskUpdateCommand request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.taskRepository.GetByIdAsync(request.Id);
        if (task is not null)
        {
            task.Status = request.IsCompleted;
            _unitOfWork.taskRepository.Update(task);
        }
        var result = await _unitOfWork.SaveChangeAsync();
        return result > 0;
    }

    public async Task<bool> Handle(TaskDeleteCommand request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.taskRepository.GetByIdAsync(request.Id);
        if (task is not null)
        {
            await _unitOfWork.taskRepository.DeleteAsync(request.Id);
        }
        var result = await _unitOfWork.SaveChangeAsync();
        return result > 0;
    }

    public async Task<IEnumerable<Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.taskRepository.GetAllAsync();
    }
}