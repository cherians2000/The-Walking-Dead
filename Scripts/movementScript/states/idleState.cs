using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState:  MovementBaseState
{
    public override void EnterState(PlayerMovement movement)
    {

    }

    // Update is called once per frame
    public override void UpdateState(PlayerMovement movement)
    {
        if (movement.dir.magnitude > 0.1f)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                movement.SwitchState(movement.Run);
            }
            else
            {
                movement.SwitchState(movement.Walk);
            }
           
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            movement.SwitchState(movement.Crouch);
        }
    }
}
