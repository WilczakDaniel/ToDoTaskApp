using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoTaskApp.Database;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Exceptions;
using ToDoTaskApp.Models;
using ToDoTaskApp.Settings;

namespace ToDoTaskApp.Services;

public class TaskCategoryService : ITaskCategoryService
{
    private readonly AppDbContext _context;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserContextService _userContextService;

    public TaskCategoryService(AppDbContext context, IAuthorizationService authorizationService, IUserContextService userContextService)
    {
        _context = context;
        _authorizationService = authorizationService;
        _userContextService = userContextService;
    }
    
    public async Task<TaskCategory> GetByIdAsync(int id)
    {
        var user =  _userContextService.GetUserId;
        var taskCategory = await _context
            .TaskCategories
            .FirstOrDefaultAsync(r => r.Id == id && r.User.Id == user);
        
        if (taskCategory is null) throw new NotFoundException("Task Category not found");
        
        return taskCategory;
    }
    
    public async Task<IEnumerable<TaskCategory>> GetAllAsync()
    {
        var user =  _userContextService.GetUserId;
        var taskCategories = await _context
            .TaskCategories
            .Where(r => r.User.Id == user)
            .ToListAsync();
        
        return taskCategories;
    }
    
    public async Task CreateAsync(TaskCategoryVM taskCategoryVM)
    {
        var user =  _userContextService.GetUserId;
        var newCategory = new TaskCategory()
        {
            Name = taskCategoryVM.Name,
            User = await _context.Users.FirstOrDefaultAsync(u => u.Id == user)
        };

        await _context.TaskCategories.AddAsync(newCategory);
        await _context.SaveChangesAsync();
    }
        
    public async Task UpdateAsync(int id ,TaskCategoryVM taskCategoryVM)
    {
        var dbCategory = await _context.TaskCategories.FirstOrDefaultAsync(c => c.Id == id);
        if (dbCategory is null) throw new NotFoundException("Task Category not found");
         dbCategory.Name = taskCategoryVM.Name;
         await _context.SaveChangesAsync();
    }
    
    public async Task RemoveAsync(int id)
    {
        var category = await _context.TaskCategories.FirstOrDefaultAsync(c => c.Id == id);
        if(category==null) throw new NotFoundException("Task Category not found");
        _context.TaskCategories.Remove(category);
        await _context.SaveChangesAsync();
    }
    
}