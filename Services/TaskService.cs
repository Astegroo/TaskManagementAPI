using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;
namespace TaskManagementAPI.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<TaskItem> CreateTaskAsync(TaskItem task)
    {
        task.CreatedAt = DateTime.UtcNow;
        task.UpdatedAt = DateTime.UtcNow;
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if(task == null) return false;
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TaskItem>> getAllTasksAsync(Status? status = null)
    {
        var query = _context.Tasks.AsQueryable();
        if(status.HasValue) query = query.Where(t => t.Status == status.Value);
        return await query.ToListAsync();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<TaskItem?> UpdateTaskAsync(int id, TaskItem task)
    {
        var existing = await _context.Tasks.FindAsync(id);
        if(existing == null) return null;
        existing.Title = task.Title;
        existing.Description = task.Description;
        existing.DueDate = task.DueDate;
        existing.Priority = task.Priority;
        existing.Status = task.Status;
        existing.UpdatedAt = task.UpdatedAt;
        await _context.SaveChangesAsync();
        return existing;
    }
}