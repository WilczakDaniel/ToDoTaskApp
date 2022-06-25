namespace ToDoTaskApp.Commands;

public class CreateAccount:ICommand
{
    public string Login;
    public string Email;
    public string Password;
    public int RoleId;
    
    public CreateAccount(string Login, string Email, string Password, int RoleId)
    {
        this.Login = Login;
        this.Email = Email;
        this.Password = Password;
        this.RoleId = RoleId;
    }
}