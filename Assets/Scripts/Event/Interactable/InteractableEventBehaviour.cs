using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableEventBehaviour<TEvent> : MonoBehaviour,
    IInteractableEvent, 
    IEventActionOwner<TEvent> where TEvent : IInteractableEvent
{
    [SerializeField] private ScriptableEventAction<TEvent>[] _actions;

    public event Action<ICharacter> Interacted;
    public IEnumerable<IEventAction<TEvent>> Actions => _actions;

    public void Interact(ICharacter character)
    {
        if (OnInteract(character))
            Interacted?.Invoke(character);
    }

    public virtual void DestroyEvent()
    {
        Destroy(gameObject);
    }

    protected abstract bool OnInteract(ICharacter character);
}
