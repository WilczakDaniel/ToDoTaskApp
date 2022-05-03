using System.ComponentModel.DataAnnotations;

namespace ToDoTaskApp.Models;

public class TaskCategoryVM
{
    [Display(Name = "Category")] 
    [Required]
    public string Name { get; set; }
}