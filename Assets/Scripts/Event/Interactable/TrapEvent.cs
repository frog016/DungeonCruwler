using System;
using UnityEngine;

public class TrapEvent : HiddenInteractableEvent<TrapEvent>
{
    [SerializeField] private TrapData _data;
    [SerializeField] private ScriptableObject _effect;
    
    public TrapData TrapData => _data;
    public IEffect Effect { get; private set; }

    public static event Action<TrapEvent, ICharacter> EventInteracted;

    private void OnValidate()
    {
        Effect = (IEffect)_effect;
    }

    protected override void Awake()
    {
        base.Awake();
        _hiddenObject.DetectionClass = _data.DetectionClass;
    }

    protected override bool OnInteract(ICharacter character)
    {
        if (_hiddenObject.Detected)
        {
            EventInteracted?.Invoke(this, character);
            return true;
        }

        _hiddenAction?.Invoke(this, character);
        return false;
    }
}