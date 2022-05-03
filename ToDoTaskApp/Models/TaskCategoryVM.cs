using System.ComponentModel.DataAnnotations;

namespace ToDoTaskApp.Models;

public class TaskCategoryVM
{
    public int Id { get; set; }
    [Display(Name = "Category")] 
    [Required]
    public string Name { get; set; }
}