using UnityEngine;

public class PlayerEventState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager stateManager)
    {
        Debug.Log("Event round starts!");
    }

    public override void UpdateState(PlayerStateManager stateManager)
    {

    }

    public override void ExitState(PlayerStateManager stateManager)
    {

    }
}
