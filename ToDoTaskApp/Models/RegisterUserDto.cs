namespace ToDoTaskApp.Models;

public class RegisterUserDto
{
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; } = 1;


    public RegisterUserDto(string Login,string Email,string Password,int RoleId)
    {
        this.Login = Login;
        this.Email = Email;
        this.Password = Password;
        this.RoleId = RoleId;

    }
}