using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTaskApp.Entities;

public class ToDoTask
{
    [Key]
    public int Id { get; set; }
    public string TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public DateTime? TaskDate { get; set; }
    [DefaultValue(false)]
    public bool IsCompleted { get; set; }
    
    // public int? UserId { get; set; }
    // public virtual User User { get; set; }
    public int? TaskCategoryId { get; set; }
    public virtual TaskCategory TaskCategory { get; set; }
}