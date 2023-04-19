using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Hidden Damage", fileName = "HiddenDamageAction")]
public class HiddenDamageAction : TrapEventAction
{
    public override void Invoke(TrapEvent owner, ICharacter target)
    {
        target.ApplyEffect(owner.Effect);
        DealDamage(target, owner.TrapData.Damage, 0);
        owner.DestroyEvent();
    }
}