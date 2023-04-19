﻿using UnityEngine;

public class TrapEvent : HiddenInteractableEvent<TrapEvent>
{
    [SerializeField] private TrapData _data;
    [SerializeField] private MapTickableEffect _effect;
    
    public TrapData TrapData => _data;
    public ITickableEffect Effect => _effect;

    protected override void Awake()
    {
        base.Awake();
        _hiddenObject.DetectionClass = _data.DetectionClass;
    }

    protected override bool OnInteract(ICharacter character)
    {
        if (_hiddenObject.Detected)
            return true;

        _hiddenAction?.Invoke(this, character);
        return false;
    }
}