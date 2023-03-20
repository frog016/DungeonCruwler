using UnityEngine;

[RequireComponent(typeof(IAttackGiver))]
public class CombatStateMachine : Character
{
    public ICombatState CurrentState { get; private set; }
    public IAttackGiver AttackGiver { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        AttackGiver = GetComponent<IAttackGiver>();
    }

    public void SetState(ICombatState newState)
    {
        CurrentState = newState;
        newState?.Enter(this);
    }
}