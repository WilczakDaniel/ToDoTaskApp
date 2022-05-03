using System.ComponentModel.DataAnnotations;

namespace ToDoTaskApp.Models;

public class ToDoTaskVM
{
    [Display(Name = "Title")] 
    [Required(ErrorMessage = "Title is required")]
    public string TaskName { get; set; }
    [Display(Name = "Date")] 
    [Required(ErrorMessage = "Date is required")]
    public DateTime TaskDate { get; set; }
    [Display(Name = "Description")] 
    public string? TaskDescription { get; set; }
    [Display(Name = "Category")]
    [Range(1, int.MaxValue,ErrorMessage = "Category is required")]
    public int TaskCategoryId { get; set; }
}