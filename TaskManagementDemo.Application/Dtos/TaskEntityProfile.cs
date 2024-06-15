
using AutoMapper;
using TaskManagementDemo.Domain.Entities;

namespace TaskManagementDemo.Application.Dtos;

public class TaskEntityProfile : Profile
{

    public TaskEntityProfile()
    {
        CreateMap<TaskEntity, TaskEntityDto>();
    }
}