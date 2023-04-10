using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Avoid", fileName = "AvoidEventAction")]
public class AvoidEventAction : ScriptableEventAction<TrapEvent>
{
    public override void Invoke(TrapEvent owner, ICharacter target)
    {
        var avoidValue = Dice.RollD20() + GetModifier(target, owner.DamageType);

        Debug.Log($"{target} rolled {avoidValue}.");
        if (TryOvercomeThreshold(avoidValue)) 
            return;

        var defenseType = _mapper.GetValue(owner.DamageType);
        var defense = target.CompositeStats.GetStat(defenseType);
        DealDamage(target, owner.Damage, defense);
        owner.DestroyOnInteract = true;
    }
}