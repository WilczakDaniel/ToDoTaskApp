namespace ToDoTaskApp.Events;

public interface IEventHandler<in TEvent> where TEvent : class, IEvent
{
    Task Handle(TEvent @event);
}