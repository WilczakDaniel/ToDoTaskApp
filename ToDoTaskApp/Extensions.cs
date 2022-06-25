using ToDoTaskApp.Commands;
using ToDoTaskApp.Commands.Handlers;

namespace ToDoTaskApp;

public static class Extensions
{
    public static IServiceCollection Add(this IServiceCollection services)
    {
        services.AddCommandHandler<CreateAccount, CreateAccountHandler>();
        return services;
    }
    
    private static IServiceCollection AddCommandHandler<TCommand, TCommandHandler>(
        this IServiceCollection services
    )
        where TCommandHandler : class, ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        return services.AddTransient<TCommandHandler>()
            .AddTransient<ICommandHandler<TCommand>>(sp => sp.GetRequiredService<TCommandHandler>());
    }
}