using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Hidden Trap Attack", fileName = "HiddenTrapAttackAction")]
public class HiddenTrapAttackAction : VarietyEventAction
{
    [SerializeField] private int _damage;

    public override void Invoke(InteractableEventHolder owner, ICharacter target)
    {
        base.Invoke(owner, target);
        var castEvent = CastEventAs<HiddenScriptableEvent>(owner.Event);

        target.ApplyDamage(_damage);
        target.ApplyEffect(castEvent.Effect);
        owner.DestroyHolder();
        MoveCharacterForward(target);
    }
}