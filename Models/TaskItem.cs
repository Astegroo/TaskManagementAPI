using System.ComponentModel.DataAnnotations;
namespace TaskManagementAPI.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; } = string.Empty;

    public DateTime? DueDate { get; set; }

    [Required]
    public Priority Priority { get; set; } = Priority.low;

    [Required]
    public Status Status { get; set; } = Status.pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public enum Priority
{
    low,
    medium,
    high
}
public enum Status
{
    pending,
    inProgress,
    completed
}