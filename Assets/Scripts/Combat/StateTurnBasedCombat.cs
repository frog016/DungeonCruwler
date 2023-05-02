using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateTurnBasedCombat : MonoBehaviour, ITurnBasedCombat
{
    public event Action<ICombatEntity[]> TurnStarted;
    public event Action<ICombatEntity> CombatEnded;
    public IEnumerable<ICombatEntity> Fighters => _stateMachines;

    private ICombatTurnPlanner _turnPlanner;
    private CombatEntity[] _stateMachines;
    private Coroutine _combatCoroutine;
    
    public void Constructor(ICombatTurnPlanner turnPlanner, CombatEntity[] stateMachines)
    {
        _turnPlanner = turnPlanner;
        _stateMachines = stateMachines;
    }

    public void Initialize(ICharacter[] characters)
    {
        var characterMachinePairs = characters.Zip(Fighters, Tuple.Create);
        foreach (var (character, machine) in characterMachinePairs)
            machine.Initialize(character);
    }

    public void Launch()
    {
        _combatCoroutine ??= StartCoroutine(CombatCoroutine());
    }

    private IEnumerator CombatCoroutine()
    {
        yield return null;
        while (_stateMachines.All(machine => machine.Health > 0))
        {
            TurnStarted?.Invoke(_stateMachines);

            var sequence = GetSequence();
            foreach (var machine in sequence)
            {
                Debug.Log($"Now it's player turn {machine}.");
                var currentMachine = machine;
                currentMachine.SetState(new PreparingCombatState());
                yield return new WaitUntil(() => currentMachine.Current is CompletedCombatState);
            }

            yield return null;
        }

        CombatEnded?.Invoke(_stateMachines.First(machine => machine.Health != 0));
    }

    private CombatEntity[] GetSequence()
    {
        return _turnPlanner
            .PlaneTurnSequence(_stateMachines)
            .Where(machine => !machine.Interrupted)
            .ToArray();
    }
}