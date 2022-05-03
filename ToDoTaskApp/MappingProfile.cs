using AutoMapper;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace ToDoTaskApp;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ToDoTask, ToDoTaskDto>();
        CreateMap<TaskCategory, TaskCategoryDto>();
    }
}