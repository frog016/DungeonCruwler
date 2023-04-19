using UnityEngine;

[RequireComponent(typeof(HiddenObject))]
public abstract class HiddenInteractableEvent<TEvent> : InteractableEventBehaviour<TEvent> where TEvent : IInteractableEvent
{
    [SerializeField] protected ScriptableEventAction<TEvent> _hiddenAction;

    protected HiddenObject _hiddenObject;

    protected virtual void Awake()
    {
        _hiddenObject = GetComponent<HiddenObject>();
    }
}