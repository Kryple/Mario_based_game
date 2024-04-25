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

        float velX = rigidbody2D.velocity.x;
        animator.speed = Helpers.Map(maxXSpeed, 0, 1, 0, 1.6f, true);

        if (!grounded || Mathf.Abs(velX) < 0.1f)
        {
            isCompleted = true;
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