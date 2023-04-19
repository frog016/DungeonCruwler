using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Destroy Trap", fileName = "DestroyTrapAction")]
public class DestroyTrapAction : TrapEventAction
{
    public override void Invoke(TrapEvent owner, ICharacter target)
    {
        var data = owner.TrapData;
        if (TryOvercomeThreshold(data, target))
        {
            owner.DestroyEvent();
            return;
        }

        DealDamage(target, data.Damage / 2, 0);
    }
}