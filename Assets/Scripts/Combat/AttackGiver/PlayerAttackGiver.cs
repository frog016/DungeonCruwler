using UnityEngine;

public class PlayerAttackGiver : MonoBehaviour, IPlayerAttackGiver
{
    public Attack CurrentAttack { get; set; }
    public CombatEntityBehaviour Target { get; set; }

    public bool TryGetAttack(out Attack attack, out CombatEntityBehaviour target)
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