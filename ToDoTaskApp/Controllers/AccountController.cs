using Microsoft.AspNetCore.Mvc;
using ToDoTaskApp.Commands;
using ToDoTaskApp.Commands.Handlers;
using ToDoTaskApp.Models;
using ToDoTaskApp.Services;

namespace ToDoTaskApp.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly CreateAccountHandler _createAccount;


    public AccountController(IUserService userService, CreateAccountHandler createAccount)
    {
        _userService = userService;
        _createAccount = createAccount;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto userCreated )
    {
        await _createAccount.HandleAsync(new CreateAccount(userCreated.Login, userCreated.Email,userCreated.Password,userCreated.RoleId));
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody]LoginDto dto)
    {
        string token = _userService.GenerateJwt(dto);
        return Ok(token);
    }
}