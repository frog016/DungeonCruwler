using UnityEngine;

public class PlayerAttackGiver : MonoBehaviour, IPlayerAttackGiver
{
    public Attack CurrentAttack { get; set; }
    public CombatStateMachine Target { get; set; }

    public bool TryGetAttack(out Attack attack, out CombatStateMachine target)
    {
        attack = CurrentAttack;
        target = Target;
        var canGet = CurrentAttack != null && Target != null;
        if (canGet)
            ResetLinks();

        return canGet;
    }

    private void ResetLinks()
    {
        CurrentAttack = null;
        Target = null;
    }
}