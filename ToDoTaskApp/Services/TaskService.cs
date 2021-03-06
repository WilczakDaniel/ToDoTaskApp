using System.Linq;
using AutoMapper;
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
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;

    public TaskService(AppDbContext context, IAuthorizationService authorizationService,IMapper mapper,
        IUserContextService userContextService)
    {
        _context = context;
        _authorizationService = authorizationService;
        _mapper = mapper;
        _userContextService = userContextService;
    }


    public async Task<IEnumerable<ToDoTaskDto>> GetAllAsync()
    {
        // var currentUser = _userContextService.GetUserId;
        IQueryable<ToDoTask> taskQuery = _context.ToDoTasks.Include(x => x.TaskCategory);

        // taskQuery = taskQuery
            // .Where(t => t.User.Id == currentUser);

        // if (!string.IsNullOrEmpty(name))
        // {
        //     taskQuery = taskQuery.Where(x => x.TaskName.Contains(name));
        // }

        var tasks = await taskQuery.ToListAsync();
        var taskDto = _mapper.Map<IEnumerable<ToDoTaskDto>>(tasks);
        return taskDto;
    }

    public async Task<ToDoTaskDto> GetByIdAsync(int id)
    {
        // var currentUser = _userContextService.GetUserId;
        var task = await _context.ToDoTasks.FirstOrDefaultAsync(t =>t.Id == id);
        if(task==null) throw new NotFoundException("Task not found");
        return _mapper.Map<ToDoTaskDto>(task);
    }

    public async Task CreateAsync(ToDoTaskVM toDoTaskVM)
    {
        // var currentUser = _userContextService.GetUserId;
        var newToDoTask = new ToDoTask()
        {
            TaskName = toDoTaskVM.TaskName,
            TaskDate = toDoTaskVM.TaskDate,
            TaskDescription = toDoTaskVM.TaskDescription,
            TaskCategoryId = toDoTaskVM.TaskCategoryId,
        };
        // newToDoTask.UserId = currentUser;
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