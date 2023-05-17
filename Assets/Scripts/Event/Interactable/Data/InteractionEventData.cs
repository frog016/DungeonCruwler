public readonly struct InteractionEventData
{
    public readonly ICharacter InteractedWith;
    public readonly IInteractableEvent Event;
    public readonly EventBehaviour EventObject;

    public InteractionEventData(ICharacter interactedWith, IInteractableEvent @event, EventBehaviour eventObject)
    {
        InteractedWith = interactedWith;
        Event = @event;
        EventObject = eventObject;
    }
}