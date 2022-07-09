using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoTaskApp.Models;
using ToDoTaskApp.Services;

namespace ToDoTaskApp.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        return Ok(task);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] ToDoTaskVM task)
    {
        await _taskService.CreateAsync(task);
        return Created($"/api/tasks",null);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask([FromRoute]int id, [FromBody] ToDoTaskVM task)
    {
        await _taskService.UpdateAsync(id, task);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _taskService.RemoveAsync(id);
        return NoContent();
    }
    
    [HttpPost("{id}")]
    public async Task<IActionResult> DoneTask([FromRoute] int id)
    {
        await _taskService.Done(id);
        return Ok();
    }
    
}