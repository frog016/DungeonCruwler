using UnityEngine;

public class PlayerFreeActionState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager stateManager)
    {
        Debug.Log("FreeAction round starts!");
    }

    public override void UpdateState(PlayerStateManager stateManager)
    {

    }

    public override void ExitState(PlayerStateManager stateManager)
    {

    }
}
