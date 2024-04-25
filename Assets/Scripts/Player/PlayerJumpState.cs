using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class PlayerJumpState : PlayerAirborneState
{
    public float jumpSpeed = runSpeed * 1.8f;
    
    public PlayerJumpState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        animator.Play("Jump");  
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        //Seek the animator to the frame based on our y velocity 
        float time = Helpers.Map(rigidbody2D.velocity.y, jumpSpeed, -jumpSpeed, 0, 1, true);
        // animator.Play("Jump", 0, time);
        // animator.speed = 0;
        
        
        if (grounded)
        {
            playerStateMachine.ChangeState(playerStateMachine._pIdleState);
            Debug.Log("hihi");
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