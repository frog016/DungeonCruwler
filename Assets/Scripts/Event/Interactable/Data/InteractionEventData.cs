using UnityEngine;

public readonly struct InteractionEventData
{
    public readonly ICharacter InteractedWith;
    public readonly IInteractableEvent Event;
    public readonly InteractableEventHolder EventObject;

    public InteractionEventData(ICharacter interactedWith, IInteractableEvent @event, InteractableEventHolder eventObject)
    {
        InteractedWith = interactedWith;
        Event = @event;
        EventObject = eventObject;
    }
}