using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface ITaskCategoryService
{
    /// <summary>
    /// Get by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TaskCategoryDto> GetByIdAsync(int id);
    /// <summary>
    /// Get all
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TaskCategoryDto>> GetAllAsync();
    /// <summary>
    /// Create
    /// </summary>
    /// <param name="taskCategoryVM"></param>
    /// <returns></returns>
    Task CreateAsync(TaskCategoryVM taskCategoryVM);
    /// <summary>
    /// Update
    /// </summary>
    /// <param name="id"></param>
    /// <param name="taskCategoryVM"></param>
    /// <returns></returns>
    Task UpdateAsync(int id ,TaskCategoryVM taskCategoryVM);
    /// <summary>
    /// Remove
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task RemoveAsync(int id);
}