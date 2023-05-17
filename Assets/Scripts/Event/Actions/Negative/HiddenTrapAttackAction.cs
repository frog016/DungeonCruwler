using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Hidden Trap Attack", fileName = "HiddenTrapAttackAction")]
public class HiddenTrapAttackAction : NegativeEventAction
{
    public override void Invoke(EventBehaviour owner, ICharacter target)
    {
        base.Invoke(owner, target);

        var hidden = owner as HiddenEventBehaviour;
        var (damage, _) = GetEventParameters(hidden, target);
        DealDamage(target, damage, 0);

        owner.DestroyEvent();
    }
}