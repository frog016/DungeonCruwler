using UnityEngine;

public abstract class ScriptableEventAction<TEvent> : ScriptableObject, IEventAction<TEvent> where TEvent : IInteractableEvent
{
    public virtual void Invoke(TEvent owner, ICharacter target)
    {
        target.Interrupted = false;
    }
}