using Microsoft.AspNetCore.Mvc;
using ToDoTaskApp.Models;
using ToDoTaskApp.Services;

namespace ToDoTaskApp.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController:ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
    {
        _userService.RegisterUser(dto);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody]LoginDto dto)
    {
        string token = _userService.GenerateJwt(dto);
        return Ok(token);
    }
}