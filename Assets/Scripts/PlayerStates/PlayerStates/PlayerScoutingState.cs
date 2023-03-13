using UnityEngine;

public class PlayerScoutingState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager stateManager)
    {
        Debug.Log("Scouting round starts!");
    }

    public override void UpdateState(PlayerStateManager stateManager)
    {
        
    }

    public override void ExitState(PlayerStateManager stateManager)
    {
        
    }
}
