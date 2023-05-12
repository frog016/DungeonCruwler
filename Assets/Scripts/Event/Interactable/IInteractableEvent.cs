using System;

public interface IInteractableEvent : IEventActionOwner
{
    int ComplexityClass { get; }
    event Action<InteractionEventData> Interacted;
    void Interact(ICharacter character);
}