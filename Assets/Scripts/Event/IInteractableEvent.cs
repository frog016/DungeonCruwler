using System;

public interface IInteractableEvent
{
    event Action<ICharacter> Interacted;
    void Interact(ICharacter character);
}