using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface IUserService
{
    void RegisterUser(RegisterUserDto dto);
    string GenerateJwt(LoginDto dto);
}