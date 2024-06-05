using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementBaseState;

public class WalkState :MovementBaseState
{
    public override void EnterState(PlayerMovement movement)
{
        movement.anim.SetBool("Walking", true);
}

// Update is called once per frame
public override void UpdateState(PlayerMovement movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            ExitState(movement, movement.Run);
        }
        else if (Input.GetKey(KeyCode.C)) { 
            ExitState(movement, movement.Crouch);
        }
        else if (movement.dir.magnitude < 0.1f)
        {
            ExitState(movement, movement.Idle);
        }
        if (movement.verticalInput < 0)
        {
            movement.currentMoveSpeed = movement.walkBackSpeed;
        }
        else
        {
            movement.currentMoveSpeed=movement.walkSpeed;
        }
    }
    void ExitState(PlayerMovement movement,MovementBaseState state)
    {
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
