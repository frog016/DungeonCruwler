using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Try Break Object", fileName = "TryBreakObjectAction")]
public class TryBreakObjectAction : NegativeEventAction
{
    public override void Invoke(EventBehaviour owner, ICharacter target)
    {
        base.Invoke(owner, target);
        var hiddenObject = (HiddenEventBehaviour)owner;
        if (TryOvercomeThreshold(hiddenObject, target))
        {
            owner.DestroyEvent();
            return;
        }


        var (damage, _) = GetEventParameters(hiddenObject, target);
        DealDamage(target, damage, 0);
    }
}
