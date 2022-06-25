using ToDoTaskApp.Commands;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;

namespace ToDoTaskApp.Events.External;

public class UserCreated : IEvent
{
    public string Login;
    public string Email;
    public string Password;
    public int RoleId;
    

    public UserCreated(string Login, string Email, string Password, int RoleId)
    {
        this.Login = Login;
        this.Email = Email;
        this.Password = Password;
        this.RoleId = RoleId;
    }
}