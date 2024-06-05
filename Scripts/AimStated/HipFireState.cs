using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFireState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        aim.anim.SetBool("Aiming", true);
        aim.currentFov = aim.hipFov;
    }
    public override void UpdateState(AimStateManager aim)
    {
        if(Input.GetKey(KeyCode.Mouse1)) 
        {
            aim.SwitchState(aim.aim);
        }
    }
}
