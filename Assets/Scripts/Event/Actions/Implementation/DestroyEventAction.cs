using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Destroy", fileName = "DestroyEventAction")]
public class DestroyEventAction : ScriptableEventAction<TrapEvent>
{
    public override void Invoke(TrapEvent owner, ICharacter target)
    {
        var avoidValue = Dice.RollD20() + GetModifier(target, owner.DamageType);

        Debug.Log($"{target} rolled {avoidValue}.");
        if (TryOvercomeThreshold(avoidValue))
        {
            Debug.Log($"{owner} is destroyed.");
            Destroy(owner.gameObject);
            return;
        }

        Debug.Log($"Failure. {target} can't destroy trap.");
        DealDamage(target, owner.Damage / 2, 0);
    }
}