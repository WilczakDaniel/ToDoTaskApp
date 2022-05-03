using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ToDoTaskApp.Database;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Exceptions;
using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserContextService _userContextService;

    public TaskService(AppDbContext context, IAuthorizationService authorizationService,
        IUserContextService userContextService)
    {
        _context = context;
        _authorizationService = authorizationService;
        _userContextService = userContextService;
    }


    public async Task<IEnumerable<ToDoTask>> GetAllAsync(string name)
    {
        var currentUser = _userContextService.GetUserId;
        IQueryable<ToDoTask> taskQuery = _context.ToDoTasks.Include(x => x.TaskCategory);

        taskQuery = taskQuery
            .Where(t => t.User.Id == currentUser);

        if (!string.IsNullOrEmpty(name))
        {
            taskQuery = taskQuery.Where(x => x.TaskName.Contains(name));
        }

        var tasks = await taskQuery.ToListAsync();
        return tasks;
    }

    public async Task<ToDoTask> GetByIdAsync(int id)
    {
        var currentUser = _userContextService.GetUserId;
        var task = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.User.Id == currentUser && t.Id == id);
        if(task==null) throw new NotFoundException("Task not found");
        return task;
    }

    public async Task CreateAsync(ToDoTaskVM toDoTaskVM)
    {
        var currentUser = _userContextService.GetUserId;
        var newToDoTask = new ToDoTask()
        {
            TaskName = toDoTaskVM.TaskName,
            TaskDate = toDoTaskVM.TaskDate,
            TaskDescription = toDoTaskVM.TaskDescription,
            TaskCategoryId = toDoTaskVM.TaskCategoryId,
            User = await _context.Users.FirstOrDefaultAsync(u => u.Id == currentUser)
        };
        await _context.ToDoTasks.AddAsync(newToDoTask);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var task = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == id);
        if(task==null) throw new NotFoundException("Task not found");
        _context.ToDoTasks.Remove(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, ToDoTaskVM toDoTaskVM)
    {
        var newTask = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == id);
        if (newTask == null) throw new NotFoundException("Task not found");

        newTask.TaskName = toDoTaskVM.TaskName;
        newTask.TaskDate = toDoTaskVM.TaskDate;
        newTask.TaskDescription = toDoTaskVM.TaskDescription;
        newTask.TaskCategoryId = toDoTaskVM.TaskCategoryId;

        await _context.SaveChangesAsync();
    }

    public async Task Done(int id)
    {
        var doneTask = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == id);
        if(doneTask==null) throw new NotFoundException("Task not found");
        doneTask.IsCompleted = true;
        await _context.SaveChangesAsync();
    }
}