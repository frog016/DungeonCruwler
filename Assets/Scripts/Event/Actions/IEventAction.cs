public interface IEventAction
{
    int Chance { get; }
    void Invoke(InteractableEventHolder owner, ICharacter target);
}