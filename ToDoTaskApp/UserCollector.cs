using Newtonsoft.Json;
using Plain.RabbitMQ;
using ToDoTaskApp.Events.External;

namespace ToDoTaskApp;

public class UserCollector : IHostedService
{
    private readonly ISubscriber _subscriber;
    private readonly IServiceProvider _serviceProvider;

    public UserCollector(ISubscriber subscriber,IServiceProvider serviceProvider)
    {
        _subscriber = subscriber;
        _serviceProvider = serviceProvider;
    }
    
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _subscriber.Subscribe(ProcessMessage);
        return Task.CompletedTask;

    }

    private bool ProcessMessage(string message, IDictionary<string, object> headers)
    {
        if (message.Contains("create"))
        {
            var @event = JsonConvert.DeserializeObject<UserCreated>(message);
            using (var scope = _serviceProvider.CreateScope())
            {
                var userCreatedHandler = scope.ServiceProvider.GetRequiredService<UserCreatedHandler>();
                userCreatedHandler.Handle(@event);
            }
        }
        return true;
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}