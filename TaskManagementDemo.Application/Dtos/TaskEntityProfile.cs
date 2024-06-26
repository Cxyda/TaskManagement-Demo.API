﻿
using AutoMapper;
using TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand;
using TaskManagementDemo.Application.Tasks.Commands.UpdateTaskCommand;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Dtos;

public class TaskEntityProfile : Profile
{
    public TaskEntityProfile()
    {
        CreateMap<TaskEntity, TaskEntityDto>()
            .ForMember(t => t.SubTaskIds, 
                opt => 
                opt.MapFrom(src => src.SubTasks.Select(x => x.Id)));

        CreateMap<CreateTaskCommand, TaskEntity>();

        CreateMap<UpdateTaskCommand, TaskEntity>();
    }
}