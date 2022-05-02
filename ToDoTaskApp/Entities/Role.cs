using System.ComponentModel.DataAnnotations;

namespace ToDoTaskApp.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}