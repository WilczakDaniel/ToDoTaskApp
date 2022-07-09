using System.Security.Claims;

namespace ToDoTaskApp.Services;

public interface IUserContextService
{
    /// <summary>
    /// Get Claims
    /// </summary>
    ClaimsPrincipal User { get; }
    
    /// <summary>
    /// Get user ID
    /// </summary>
    int? GetUserId { get; }
}