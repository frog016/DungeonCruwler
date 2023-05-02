using UnityEngine;

public class CombatResultHandler : MonoBehaviour, IResultHandler
{
    public object Reward { get; private set; }
    public bool Result { get; private set; }

    private ITurnBasedCombat _combat;
    private BattleLevel _level;

    public void Constructor(ITurnBasedCombat combat, BattleLevel level)
    {
        _combat =  combat;
        _level = level;
    }

    private void OnEnable()
    {
        _combat.CombatEnded += CreateBattleResult;
    }

    private void OnDisable()
    {
        _combat.CombatEnded -= CreateBattleResult;
    }

    private void CreateBattleResult(ICombatEntity winner)
    {
        Result = winner.Team == Team.Player;
        Reward = Result ? GetReward() : null;
        if (Result)
            Destroy(_level.Initiator);
        _level.Unload();
        var mainLevel = FindObjectOfType<MainLevel>(true);
        mainLevel.Load();
    }

    private object GetReward()
    {
        return null;
    }
}