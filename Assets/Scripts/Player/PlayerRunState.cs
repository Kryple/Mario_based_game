using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class PlayerRunState : PlayerGroundedState
{
    public float maxXSpeed = 5f;
    
    public PlayerRunState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        
        animator.Play("Run");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        HandleXMovement();
    }
    
    void HandleXMovement() {
        if (Mathf.Abs(xInput) > 0) 
        {
            //increment velocity by our accelleration, then clamp within max
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(rigidbody2D.velocity.x + increment, -runSpeed, runSpeed);
            rigidbody2D.velocity = new Vector2(newSpeed, rigidbody2D.velocity.y);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
    }
}