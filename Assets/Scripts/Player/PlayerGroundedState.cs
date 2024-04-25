using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;


public class PlayerGroundedState : PlayerAllStates
{
    public PlayerGroundedState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Mathf.Abs(xInput) > 0)
        {
            playerStateMachine.ChangeState(playerStateMachine._pRunState);
        }
        else
        {
            playerStateMachine.ChangeState(playerStateMachine._pIdleState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            playerStateMachine.ChangeState(playerStateMachine._pJumpState);
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