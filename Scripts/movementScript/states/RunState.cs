using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunState : MovementBaseState
{
    public override void EnterState(PlayerMovement movement)
    {
        movement.anim.SetBool("Running", true);

    }

    // Update is called once per frame
    public override void UpdateState(PlayerMovement movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ExitState(movement, movement.Walk);
        }
        else if (movement.dir.magnitude < 0.1f)
        {
            ExitState(movement, movement.Idle);

        }
        if (movement.verticalInput < 0)
        {
            movement.currentMoveSpeed = movement.runBackSpeed;
        }
        else
        {
            movement.currentMoveSpeed = movement.runSpeed;
        }
    }
    void ExitState(PlayerMovement movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwitchState(state);

    }
}
