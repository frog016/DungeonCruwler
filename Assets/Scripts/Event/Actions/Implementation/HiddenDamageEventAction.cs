using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Hidden Damage", fileName = "HiddenDamageEventAction")]
public class HiddenDamageEventAction : ScriptableEventAction<TrapEvent>
{
    public override void Invoke(TrapEvent owner, ICharacter target)
    {
        DealDamage(target, owner.Damage, 0);
        owner.DestroyOnInteract = true;
    }
}