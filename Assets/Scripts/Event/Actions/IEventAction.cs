public interface IEventAction<in T> where T : IInteractableEvent
{
    void Invoke(T owner, ICharacter target);
}