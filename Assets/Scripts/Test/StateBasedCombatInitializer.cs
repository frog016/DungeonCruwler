﻿using UnityEngine;

public class StateBasedCombatInitializer : MonoBehaviour
{
    [SerializeField] private StateTurnBasedCombat _combat;
    [SerializeField] private CombatStateMachine[] _stateMachines;

    private void Awake()
    {
        Inject();
    }

    private void Inject()
    {
        _combat.Constructor(new AgilityCombatTurnPlanner(), _stateMachines);
    }
}