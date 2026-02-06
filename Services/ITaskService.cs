using TaskManagementAPI.Models;
namespace TaskManagementAPI.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> getAllTasksAsync(Status? status = null);
    Task<TaskItem> GetTaskByIdAsync(int id);
    Task<TaskItem> CreateTaskAsync(TaskItem task);
    Task<TaskItem> UpdateTaskAsync(int id, TaskItem task);
    Task<bool> DeleteTaskAsync(int id);
}