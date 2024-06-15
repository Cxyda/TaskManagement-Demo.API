
namespace TaskManagementDemo.Application.Tasks;

public record TaskEntityDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; }
}