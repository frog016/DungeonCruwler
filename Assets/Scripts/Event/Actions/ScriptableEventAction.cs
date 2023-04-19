using UnityEngine;

public abstract class ScriptableEventAction<TEvent> : ScriptableObject, IEventAction<TEvent> where TEvent : IInteractableEvent
{
    public abstract void Invoke(TEvent owner, ICharacter target);
}