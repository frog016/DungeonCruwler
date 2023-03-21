using UnityEngine;

[RequireComponent(typeof(ITurnBasedCombat))]
public class CombatResultHandler : MonoBehaviour
{
    [SerializeField] private BattleLevel _level;

    private ITurnBasedCombat _combat;

    private void Awake()
    {
        _combat = GetComponent<ITurnBasedCombat>();
        _combat.CombatEnded += HandleCombatResult;
    }

    private void OnDestroy()
    {
        _combat.CombatEnded -= HandleCombatResult;
    }

    private void HandleCombatResult(CombatStateMachine winner)
    {
        _level.Unload();
    }
}