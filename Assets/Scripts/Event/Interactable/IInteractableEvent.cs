using System;

public interface IInteractableEvent
{
    event Action<InteractionEventData> Interacted;
    void Interact(ICharacter character);
}