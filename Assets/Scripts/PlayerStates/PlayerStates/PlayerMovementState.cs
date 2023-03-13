using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager stateManager)
    {
        Debug.Log("Movement round starts!");
    }

    public override void UpdateState(PlayerStateManager stateManager)
    {

    }

    public override void ExitState(PlayerStateManager stateManager)
    {

    }
}
