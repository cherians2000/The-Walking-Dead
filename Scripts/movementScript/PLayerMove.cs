using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentMoveSpeed;
    public float walkSpeed=3, walkBackSpeed=2;
    public float runSpeed=7, runBackSpeed=5;
    public float crouchSpeed=2, crouchBackSpeed=1;
    [HideInInspector] public Vector3 dir;
    public float horizontalInput, verticalInput;
    public CharacterController characterController;
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;
    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
    
    MovementBaseState currentState;
   
    public idleState Idle=new idleState();
    public WalkState Walk=new WalkState();
    public CrouchState Crouch=new CrouchState();
    public RunState Run=new RunState();
    [HideInInspector] public Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        SwitchState(Idle);
    }

    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
         verticalInput = Input.GetAxis("Vertical");

        dir=transform.forward*verticalInput+transform.right*horizontalInput;
        characterController.Move(dir.normalized *currentMoveSpeed * Time.deltaTime);

        Gravity();
        currentState.UpdateState(this);
        anim.SetFloat("Hz Input", horizontalInput);
        anim.SetFloat("Vt Input", verticalInput);
        
    }
    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if(Physics.CheckSphere(spherePos,characterController.radius-0.05f,groundMask)) 
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }
    void Gravity()
    {
        if(!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;

        }else if(velocity.y < 0) {
            velocity.y = -2;
        }
        characterController.Move(velocity*Time.deltaTime);
    }
  
    
}
