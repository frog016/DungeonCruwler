using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Destroy Trap", fileName = "DestroyTrapAction")]
public class DestroyTrapAction : NegativeEventAction
{
    public override void Invoke(EventBehaviour owner, ICharacter target)
    {
        base.Invoke(owner, target);

        var hidden = owner as HiddenEventBehaviour;
        if (TryOvercomeThreshold(hidden, target))
        {
            owner.DestroyEvent();
            return;
        }

        var (damage, _) = GetEventParameters(hidden, target);
        DealDamage(target, damage / 2, 0);
    }
}