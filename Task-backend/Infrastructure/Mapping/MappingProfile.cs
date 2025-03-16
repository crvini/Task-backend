using AutoMapper;
using Task_backend.Core.Commands;

namespace Sales.infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskCreateCommand,Task_backend.Core.Entities.Task>();
       
    }
}