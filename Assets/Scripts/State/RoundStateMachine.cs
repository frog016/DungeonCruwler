using UnityEngine;

public class RoundStateMachine : MonoBehaviour, IStateMachine
{
    public IState CurrentState { get; private set; }

    public void SetState(IState newState)
    {
        CurrentState = newState;
        CurrentState.Enter(this);
    }
}