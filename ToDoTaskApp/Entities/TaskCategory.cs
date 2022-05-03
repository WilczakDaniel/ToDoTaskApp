using System.ComponentModel.DataAnnotations;

namespace ToDoTaskApp.Entities;

public class TaskCategory
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int? UserId { get; set; }
    public User User { get; set; }
}