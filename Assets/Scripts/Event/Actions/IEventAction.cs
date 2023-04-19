public interface IEventAction<in TEvent> where TEvent : IInteractableEvent
{
    void Invoke(TEvent owner, ICharacter target);
}