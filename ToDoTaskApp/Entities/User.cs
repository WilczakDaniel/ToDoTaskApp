using System.ComponentModel.DataAnnotations;

namespace ToDoTaskApp.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}