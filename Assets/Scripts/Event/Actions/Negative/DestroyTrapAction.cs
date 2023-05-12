using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Destroy Trap", fileName = "DestroyTrapAction")]
public class DestroyTrapAction : VarietyEventAction
{
    [SerializeField] private int _damage;

    public override void Invoke(InteractableEventHolder owner, ICharacter target)
    {
        base.Invoke(owner, target);
        var castEvent = CastEventAs<HiddenScriptableEvent>(owner.Event);
        if (TryOvercomeThreshold(castEvent, target))
        {
            owner.DestroyHolder();
            return;
        }

        target.ApplyDamage(CalculateDamage());
        MoveCharacterBack(target);
    }

    private int CalculateDamage()
    {
        var totalDamage = _damage / 2;
        return totalDamage;
    }
}