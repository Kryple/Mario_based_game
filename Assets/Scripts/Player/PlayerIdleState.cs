using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        animator.Play("Idle");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!grounded || xInput != 0)
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