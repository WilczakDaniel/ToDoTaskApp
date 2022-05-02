﻿using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoTaskApp.Database;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Exceptions;
using ToDoTaskApp.Models;
using ToDoTaskApp.Settings;

namespace ToDoTaskApp.Services;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthSettings _authSettings;

    public UserService(AppDbContext context, IPasswordHasher<User> passwordHasher, AuthSettings authSettings)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _authSettings = authSettings;
    }

    public void RegisterUser(RegisterUserDto dto)
    {
        var newUser = new User()
        {
            Login = dto.Login,
            Email = dto.Email,
            RoleId = dto.RoleId,
        };
        var hashedPassword =  _passwordHasher.HashPassword(newUser, dto.Password);
        newUser.PasswordHash = hashedPassword;
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }

    public string GenerateJwt(LoginDto dto)
    {
        var user = _context.Users
            .Include(u=>u.Role)
            .FirstOrDefault(x=>x.Email==dto.Login);
        if(user is null)
        {
            throw new BadRequestException("Invalid email or password");
        }
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new BadRequestException("Invalid email or password");
        }
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{user.Login} "),
            new Claim(ClaimTypes.Role, user.Role.Name),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authSettings.JwtExpireDays);
        var token = new JwtSecurityToken(_authSettings.JwtIssuer,
            _authSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred);
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}