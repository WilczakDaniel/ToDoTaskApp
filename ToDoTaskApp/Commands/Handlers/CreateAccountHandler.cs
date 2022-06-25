using Newtonsoft.Json;
using Plain.RabbitMQ;
using ToDoTaskApp.Events.External;
using ToDoTaskApp.Services;

namespace ToDoTaskApp.Commands.Handlers;

public class CreateAccountHandler : ICommandHandler<CreateAccount>
{
    private readonly IPublisher _publisher;
    private readonly IUserService _userService;

    public CreateAccountHandler(IPublisher publisher, IUserService userService)
    {
        _publisher = publisher;
        _userService = userService;
    }
    
    
    
    public Task HandleAsync(CreateAccount command)
    {
        _userService.RegisterUser(command.Login, command.Email, command.Password, command.RoleId);
        var newUser = new UserCreated(command.Login, command.Email, command.Password, command.RoleId);
        var message = JsonConvert.SerializeObject(newUser);
        _publisher.Publish(message, "account.create", null);
        

        return Task.CompletedTask;
    }
}