using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/Base event", fileName = "ScriptableEvent")]
public class ScriptableEvent : ScriptableObject, IInteractableEvent
{
    [SerializeField] private int _complexityClass;
    [SerializeField] private ScriptableEventAction[] _actions;
    [SerializeField] private DescriptionData _descriptionData;

    public int ComplexityClass => _complexityClass;
    public IEnumerable<IEventAction> Actions => _actions;
    public DescriptionData DescriptionData => _descriptionData;
    public event Action<InteractionEventData> Interacted;

    private InteractableEventHolder _holder;

    public virtual void Interact(ICharacter character)
    {
        if (_holder == null)
            throw new Exception($"Initialize holder before interacting.");

        Interacted?.Invoke(new InteractionEventData(character, this, _holder));
        _holder = null;
    }

    public void SetHolder(InteractableEventHolder interactedObject)
    {
        _holder = interactedObject;
    }
}