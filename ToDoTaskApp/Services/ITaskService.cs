using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface ITaskService
{
    Task<IEnumerable<ToDoTask>> GetAllAsync(string name);
    Task<ToDoTask> GetByIdAsync(int id);
    Task CreateAsync(ToDoTaskVM toDoTaskVM);
    Task RemoveAsync(int id);
    Task UpdateAsync(int id,ToDoTaskVM toDoTaskVM);
    Task Done(int id);
}