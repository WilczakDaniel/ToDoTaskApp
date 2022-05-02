using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoTaskApp.Database;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Exceptions;
using ToDoTaskApp.Settings;

namespace ToDoTaskApp.Services;

public class TaskCategoryService
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
        var taskCategory = await _context
            .TaskCategories
            .FirstOrDefaultAsync(r => r.Id == id);
        
        if (taskCategory is null) throw new NotFoundException("Task Category not found");
        
        return taskCategory;
    }
    
    
}