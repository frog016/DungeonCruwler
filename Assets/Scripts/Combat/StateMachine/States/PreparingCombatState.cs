using System;
using System.Collections;
using UnityEngine;

public class PreparingCombatState : ICombatState
{
    private CombatEntity _entity;
    private ICombatState _nextState;

    public void Enter(CombatEntity entity)
    {
        _entity = entity;
        _entity.StartCoroutine(WaitAttackAndTargetCoroutine());
    }

    private IEnumerator WaitAttackAndTargetCoroutine()
    {
        var attackGiver = _entity.AttackGiver;
        Attack attack = null;
        CombatEntity target = null;
        yield return new WaitUntil(() => attackGiver.TryGetAttack(out attack, out target));
        Debug.Log($"The {_entity} has chosen {attack} and target {target}.");
        _nextState = new AttackAnimationState(attack, target);
        Next();
    }

    public void Next()
    {
        if (_nextState == null)
            throw new InvalidOperationException("You cannot move to a new state until you select an action and enemy.");

        _entity.SetState(_nextState);
    }
}