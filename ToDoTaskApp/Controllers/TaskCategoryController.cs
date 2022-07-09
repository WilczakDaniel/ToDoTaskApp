using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoTaskApp.Models;
using ToDoTaskApp.Services;

namespace ToDoTaskApp.Controllers;

[Route("api/categories")]
[ApiController]
public class TaskCategoryController : ControllerBase
{
    private readonly ITaskCategoryService _taskCategoryService;

    public TaskCategoryController(ITaskCategoryService taskCategoryService)
    {
        _taskCategoryService = taskCategoryService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskCategoryDto>>> GetAll()
    {
        var taskCategories = await _taskCategoryService.GetAllAsync();
        return Ok(taskCategories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskCategoryDto>> GetById([FromRoute] int id)
    {
        var taskCategory = await _taskCategoryService.GetByIdAsync(id);
        return Ok(taskCategory);
    }

    [HttpPost]
    public async Task<ActionResult<TaskCategoryVM>> Create([FromBody] TaskCategoryVM taskCategory)
    {
        await _taskCategoryService.CreateAsync(taskCategory);
        return Created($"/api/categories", null);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] TaskCategoryVM taskCategory)
    {
        await _taskCategoryService.UpdateAsync(id, taskCategory);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _taskCategoryService.RemoveAsync(id);
        return NoContent();
    }

}