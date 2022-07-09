using ToDoTaskApp.Models;

namespace ToDoTaskApp.Services;

public interface IUserService
{
    /// <summary>
    /// REgister user
    /// </summary>
    /// <param name="Login"></param>
    /// <param name="Email"></param>
    /// <param name="Password"></param>
    /// <param name="RoleId"></param>
    void RegisterUser(string Login, string Email, string Password, int RoleId);
    /// <summary>
    /// Generete JWT token
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    string GenerateJwt(LoginDto dto);
}