namespace TaskManagementDemo.Application.Dtos;

public record TaskEntityDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; }
}