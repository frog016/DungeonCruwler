using UnityEngine;

public class StateBasedCombatInitializer : MonoBehaviour
{
    [SerializeField] private StateTurnBasedCombat _combat;
    [SerializeField] private CombatEntity[] _stateMachines;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        _combat.Constructor(new AgilityTurnPlanner(), _stateMachines);
    }
}