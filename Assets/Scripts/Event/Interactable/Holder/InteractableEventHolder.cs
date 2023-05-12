using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEventHolder : MonoBehaviour, IInteractableEvent
{
    [SerializeField] protected ScriptableEvent _event;

    public ScriptableEvent Event => _event;
    public int ComplexityClass => _event.ComplexityClass;
    public IEnumerable<IEventAction> Actions => _event.Actions;

    public event Action<InteractionEventData> Interacted
    {
        add => _event.Interacted += value;
        remove => _event.Interacted -= value;
    }

    public virtual void Interact(ICharacter character)
    {
        _event.SetHolder(this);
        _event.Interact(character);
    }

    public void DestroyHolder()
    {
        Destroy(gameObject);
    }
}