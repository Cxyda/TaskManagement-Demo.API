﻿
using Microsoft.AspNetCore.Identity;
using TaskManagementDemo.Domain.Constants;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace TaskManagementDemo.Domain.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public string? Title { get; set; } = default!;
    public string? Description { get; set; }

    public TaskStatus Status { get; set; }
    public Priority Priority { get; set; }
    public Complexity Complexity { get; set; }

    public List<TaskEntity> SubTasks { get; set; } = [];
}