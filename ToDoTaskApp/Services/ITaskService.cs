using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface ITaskService
{
    Task<IEnumerable<ToDoTaskDto>> GetAllAsync();
    Task<ToDoTaskDto> GetByIdAsync(int id);
    Task CreateAsync(ToDoTaskVM toDoTaskVM);
    Task RemoveAsync(int id);
    Task UpdateAsync(int id,ToDoTaskVM toDoTaskVM);
    Task Done(int id);
}