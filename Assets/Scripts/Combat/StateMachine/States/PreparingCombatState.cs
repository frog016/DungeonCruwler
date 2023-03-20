using System;
using System.Collections;
using UnityEngine;

public class PreparingCombatState : ICombatState
{
    private CombatStateMachine _stateMachine;
    private ICombatState _nextState;

    public void Enter(CombatStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _stateMachine.StartCoroutine(WaitAttackAndTargetCoroutine());
    }

    private IEnumerator WaitAttackAndTargetCoroutine()
    {
        var attackGiver = _stateMachine.AttackGiver;
        Attack attack = null;
        CombatStateMachine target = null;
        yield return new WaitUntil(() => attackGiver.TryGetAttack(out attack, out target));
        Debug.Log($"The {_stateMachine} has chosen {attack} and target {target}.");
        _nextState = new AttackAnimationState(attack, target);
        Next();
    }

    public void Next()
    {
        if (_nextState == null)
            throw new InvalidOperationException("You cannot move to a new state until you select an action and enemy.");

        _stateMachine.SetState(_nextState);
    }
}