using Newtonsoft.Json;
using Plain.RabbitMQ;
using ToDoTaskApp.Services;

namespace ToDoTaskApp.Events.External;

public class UserCreatedHandler : IEventHandler<UserCreated>
{
    private readonly IUserService _userService;
    private readonly IPublisher _publisher;

    public UserCreatedHandler(IUserService userService,IPublisher publisher)
    {
        _userService = userService;
        _publisher = publisher;
    }
    
    public Task Handle(UserCreated @event)
    {
        _userService.RegisterUser(@event.Login, @event.Email, @event.Password, @event.RoleId);
        var newUser = new UserCreated(@event.Login, @event.Email, @event.Password, @event.RoleId);
        var message = JsonConvert.SerializeObject(newUser);
        try
        {
            _publisher.Publish(message, "account.create", null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return Task.CompletedTask;
    }
}