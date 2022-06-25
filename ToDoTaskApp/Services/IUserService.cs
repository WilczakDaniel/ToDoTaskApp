using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface IUserService
{
    void RegisterUser(string Login, string Email, string Password, int RoleId);
    string GenerateJwt(LoginDto dto);
}