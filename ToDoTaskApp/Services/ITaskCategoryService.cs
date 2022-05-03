using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface ITaskCategoryService
{
    Task<TaskCategory> GetByIdAsync(int id);
    Task<IEnumerable<TaskCategory>> GetAllAsync();
    Task CreateAsync(TaskCategoryVM taskCategoryVM);
    Task UpdateAsync(int id ,TaskCategoryVM taskCategoryVM);
    Task RemoveAsync(int id);
}