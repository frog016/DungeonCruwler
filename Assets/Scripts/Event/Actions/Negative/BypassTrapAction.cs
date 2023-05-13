using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Bypass Trap", fileName = "BypassTrapAction")]
public class BypassTrapAction : NegativeEventAction
{
    public override void Invoke(EventBehaviour owner, ICharacter target)
    {
        base.Invoke(owner, target);

        var hidden = owner as HiddenEventBehaviour;
        if (TryOvercomeThreshold(hidden, target))
            return;

        var (damage, defense) = GetEventParameters(hidden, target);
        DealDamage(target, damage, defense);

        owner.DestroyEvent();
    }
}