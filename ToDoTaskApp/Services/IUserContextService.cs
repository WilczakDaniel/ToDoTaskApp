using System.Security.Claims;

namespace ToDoTaskApp.Services;

public interface IUserContextService
{
    ClaimsPrincipal User { get; }
    int? GetUserId { get; }
}