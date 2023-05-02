using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Avoid", fileName = "AvoidEventAction")]
public class AvoidTrapAction : TrapEventAction
{
    public override void Invoke(TrapEvent owner, ICharacter target)
    {
        base.Invoke(owner, target);
        var data = owner.TrapData;
        if (TryOvercomeThreshold(data, target))
        {
            target.ApplyEffect(owner.Effect);
            return;
        }

        var defenseType = _mapper.GetValue(data.DamageType);
        var defense = target.CompositeStats.GetStat(defenseType);
        DealDamage(target, data.Damage, defense);
        owner.DestroyEvent();
    }
}