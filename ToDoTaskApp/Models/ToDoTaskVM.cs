using System.ComponentModel.DataAnnotations;

namespace ToDoTaskApp.Models;

public class ToDoTaskVM
{
    public int Id { get; set; }
    [Display(Name = "Title")] 
    public string TaskName { get; set; }
    [Display(Name = "Date")] 
    public DateTime TaskDate { get; set; }
    [Display(Name = "Description")] 
    public string? TaskDescription { get; set; }
    [Display(Name = "Category")]
    [Range(1, int.MaxValue,ErrorMessage = "Category is required")]
    public int TaskCategoryId { get; set; }
}