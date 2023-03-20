using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class StateTurnBasedCombat : MonoBehaviour, ITurnBasedCombat
{
    public event Action<CombatStateMachine[]> TurnStarted;

    private ICombatTurnPlanner _turnPlanner;
    private CombatStateMachine[] _stateMachines;
    private Coroutine _combatCoroutine;

    public void Constructor(ICombatTurnPlanner turnPlanner, CombatStateMachine[] stateMachines)
    {
        _turnPlanner = turnPlanner;
        _stateMachines = stateMachines;
    }

    public void StartCombat()
    {
        _combatCoroutine ??= StartCoroutine(CombatCoroutine());
    }

    private IEnumerator CombatCoroutine()
    {
        while (_stateMachines.All(machine => machine?.Health > 0))
        {
            TurnStarted?.Invoke(_stateMachines);

            var sequence = GetSequence();
            foreach (var machine in sequence)
            {
                Debug.Log($"Now it's player turn {machine}.");
                var currentMachine = machine;
                currentMachine?.SetState(new PreparingCombatState());
                yield return new WaitUntil(() => currentMachine?.CurrentState is CompletedCombatState);
            }

            yield return null;
        }
    }

    private CombatStateMachine[] GetSequence()
    {
        return _turnPlanner
            .PlaneTurnSequence(_stateMachines)
            .Where(machine => !machine.Interrupted)
            .ToArray();
    }
}