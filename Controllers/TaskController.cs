using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;
namespace TaskManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks([FromQuery] Status? Status = null)
    {
        var tasks = await _taskService.getAllTasksAsync(Status);
        return Ok(tasks);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTask(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null) return NotFound(new { message = $"Task {id} not found" });
        return Ok(task);
    }
    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _taskService.CreateTaskAsync(task);
        return CreatedAtAction(nameof(GetTask), new { id = created.Id }, created);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<TaskItem>> UpdateTask(int id, TaskItem task)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = await _taskService.UpdateTaskAsync(id, task);
        if (updated == null) return NotFound(new { message = $"Task {id} not found" });
        return Ok(updated);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskItem>> DeleteTask(int id)
    {
        var deleted = await _taskService.DeleteTaskAsync(id);
        if (!deleted) return NotFound(new { message = $"Task {id} not found" });
        return NoContent();
    }
}