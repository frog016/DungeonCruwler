using UnityEngine;

public class ScoutingState : IState
{
    public void Enter<T>(T stateMachine) where T : IStateMachine
    {
        Debug.Log("You have opened several cells around you.");
    }

    public void Next<T>(T stateMachine) where T : IStateMachine
    {
    }
}
