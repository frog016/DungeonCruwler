using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    PlayerScoutingState scoutingState = new PlayerScoutingState();
    PlayerFreeActionState freeActionState = new PlayerFreeActionState();
    PlayerMovementState movementState = new PlayerMovementState();
    PlayerEventState eventState = new PlayerEventState();

    // Start is called before the first frame update
    private void Start()
    {
        currentState = freeActionState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState.ExitState(this);

        currentState = state;
        currentState.EnterState(this);
    }
}
