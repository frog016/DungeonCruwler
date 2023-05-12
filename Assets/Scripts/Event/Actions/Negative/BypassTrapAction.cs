using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Bypass Trap", fileName = "BypassTrapAction")]
public class BypassTrapAction : VarietyEventAction
{
    [SerializeField] private int _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private DamageTypeMapper _mapper;

    public override void Invoke(InteractableEventHolder owner, ICharacter target)
    {
        base.Invoke(owner, target);
        var trapEvent = CastEventAs<HiddenScriptableEvent>(owner.Event);
        if (TryOvercomeThreshold(trapEvent, target))
            return;

        target.ApplyDamage(CalculateDamage(target));
        target.ApplyEffect(trapEvent.Effect);
        owner.DestroyHolder();
        MoveCharacterForward(target);
    }

    private int CalculateDamage(IStatsUser target)
    {
        var defenseType = _mapper.GetValue(_damageType);
        var defense = target.CompositeStats.GetStat(defenseType);
        var totalDamage = Mathf.Max(0, _damage - defense);

        return totalDamage;
    }
}