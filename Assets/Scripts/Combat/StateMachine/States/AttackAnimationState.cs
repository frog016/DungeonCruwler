using System.Collections;
using UnityEngine;

public class AttackAnimationState : ICombatState
{
    private readonly Attack _attack;
    private readonly CombatStateMachine _target;

    private CombatStateMachine _stateMachine;

    public AttackAnimationState(Attack attack, CombatStateMachine target)
    {
        _attack = attack;
        _target = target;
    }

    public void Enter(CombatStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        stateMachine.StartCoroutine(AnimateAttack());
    }

    public void Next()
    {
        _stateMachine.SetState(new CompletedCombatState());
    }

    private IEnumerator AnimateAttack()
    {
        var transform = _stateMachine.transform;
        var target = _target.transform;
        const float animationTime = 3f;
        var elapsedTime = 0f;
        var start = transform.position;

        while (Vector3.Distance(transform.position, target.position) > 1)
        {
            transform.position = Vector3.Lerp(start, target.position, elapsedTime / animationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;
        _attack.Use(_stateMachine, _target);

        while (Vector3.Distance(transform.position, start) > 1e-1)
        {
            transform.position = Vector3.Lerp(transform.position, start, elapsedTime / animationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Next();
    }
}