using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface ITaskCategoryService
{
    Task<TaskCategoryDto> GetByIdAsync(int id);
    Task<IEnumerable<TaskCategoryDto>> GetAllAsync();
    Task CreateAsync(TaskCategoryVM taskCategoryVM);
    Task UpdateAsync(int id ,TaskCategoryVM taskCategoryVM);
    Task RemoveAsync(int id);
}