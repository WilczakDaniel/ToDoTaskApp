using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Models;
using ToDoTaskApp.Services;

namespace ToDoTaskApp.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly IPublishEndpoint _publishEndpoint;


    public AccountController(IUserService userService,IPublishEndpoint publishEndpoint)
    {
        _userService = userService;
        _publishEndpoint = publishEndpoint;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser([FromBody]RegisterUserDto dto)
    {
        await _publishEndpoint.Publish<RegisterUserDto>( new
        {
            Login = dto.Login,
            Email = dto.Email,
            Password = dto.Password,
            ConfirmPassword = dto.ConfirmPassword,
            RoleId = dto.RoleId
        });
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody]LoginDto dto)
    {
        string token = _userService.GenerateJwt(dto);
        return Ok(token);
    }
}