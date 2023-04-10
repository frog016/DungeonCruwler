using System.Collections.Generic;

public interface IEventActionOwner<in T> where T : IInteractableEvent
{
    int Count { get; }
    IEnumerable<IEventAction<T>> Actions { get; }
}