public interface IEventAction
{
    void Invoke(EventBehaviour owner, ICharacter target);
}