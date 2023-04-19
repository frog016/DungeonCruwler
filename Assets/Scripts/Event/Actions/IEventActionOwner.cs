using System.Collections.Generic;

public interface IEventActionOwner<in TEvent> where TEvent : IInteractableEvent
{
    IEnumerable<IEventAction<TEvent>> Actions { get; }
}