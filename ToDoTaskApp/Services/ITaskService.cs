using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface ITaskService
{
    /// <summary>
    /// Get All
    /// </summary>
    /// <returns> ToDoTaskDTO list</returns>
    Task<IEnumerable<ToDoTaskDto>> GetAllAsync();
    /// <summary>
    /// Get by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ToDoTaskDTO</returns>
    Task<ToDoTaskDto> GetByIdAsync(int id);
    /// <summary>
    /// Create
    /// </summary>
    /// <param name="toDoTaskVM">ToDoTaskVM</param>
    /// <returns></returns>
    Task CreateAsync(ToDoTaskVM toDoTaskVM);
    /// <summary>
    /// Remove
    /// </summary>
    /// <param name="id">ToDoTask.Id</param>
    /// <returns></returns>
    Task RemoveAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="toDoTaskVM"></param>
    /// <returns></returns>
    Task UpdateAsync(int id,ToDoTaskVM toDoTaskVM);
    /// <summary>
    /// Set ToDoTask as Done
    /// </summary>
    /// <param name="id"></param>
    /// <returns>TodoTask.IsCompleted = True</returns>
    Task Done(int id);
}