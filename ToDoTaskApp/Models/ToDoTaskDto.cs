using ToDoTaskApp.Entities;

namespace ToDoTaskApp.Models;

public class ToDoTaskDto
{
    public string TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public DateTime TaskDate { get; set; }
    public bool IsCompleted { get; set; }
    public TaskCategory TaskCategory { get; set; }
}