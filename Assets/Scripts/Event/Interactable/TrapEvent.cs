using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(IHiddenObject))]
public class TrapEvent : InteractableEventBehaviour, IEventActionOwner<TrapEvent>
{
    [SerializeField] private int _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private ScriptableEventAction<TrapEvent>[] _eventActions;

    public int Count => _eventActions.Length;
    public IEnumerable<IEventAction<TrapEvent>> Actions => _eventActions;
    public int Damage => _damage;
    public DamageType DamageType => _damageType;

    private IHiddenObject _hidden;

    private void Awake()
    {
        _hidden = GetComponent<IHiddenObject>();
    }

    protected override bool OnInteract(ICharacter character)
    {
        if (_hidden.Detected)
            return true;

        var action = _eventActions.FirstOrDefault(eventAction => 
            eventAction.GetType() == typeof(HiddenDamageEventAction));

        action?.Invoke(this, character);
        return false;
    }
}