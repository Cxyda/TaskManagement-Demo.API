﻿using TaskManagementDemo.Domain.Constants;
using TaskStatus = TaskManagementDemo.Domain.Constants.TaskStatus;

namespace TaskManagementDemo.Application.Dtos;

public record TaskEntityDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }

    public TaskStatus Status { get; set; }
    public Priority Priority { get; set; }
    public Complexity Complexity { get; set; }

    public List<int> SubTaskIds { get; set; } = [];
    public int? ParentTaskId { get; set; } // Nullable to allow root tasks

    public string CreatorId { get; set; }
}