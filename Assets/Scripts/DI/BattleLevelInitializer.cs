using System;
using System.Linq;
using UnityEngine;

public class BattleLevelInitializer : MonoBehaviour
{
    [Header("Combat")]
    [SerializeField] private StateTurnBasedCombat _combat;
    [SerializeField] private CombatEntity[] _fighters;

    [Header("Level")]
    [SerializeField] private BattleLevel _level;
    [SerializeField] private CombatResultHandler _resultHandler;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        BindCombat();
        BindLevel();
    }

    private void BindCombat()
    {
        _combat.Constructor(new AgilityTurnPlanner(), _fighters);
    }

    private void BindLevel()
    {
        _level.Constructor(_combat);
        _resultHandler.Constructor(_combat, _level);
    }
}