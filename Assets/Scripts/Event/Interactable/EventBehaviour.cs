using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBehaviour : MonoBehaviour, IInteractableEvent, IEventActionOwner
{
    [SerializeField] private int _complexityClass;
    [SerializeField] private ScriptableEventAction[] _actions;
    [SerializeField] private DescriptionData _descriptionData;

    public int ComplexityClass => _complexityClass;
    public IEnumerable<IEventAction> Actions => _actions;
    public DescriptionData DescriptionData => _descriptionData;
    public event Action<InteractionEventData> Interacted;

    public virtual void Interact(ICharacter character)
    {
        Interacted?.Invoke(new InteractionEventData(character, this, this));
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}