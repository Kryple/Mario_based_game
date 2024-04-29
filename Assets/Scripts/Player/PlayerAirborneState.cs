using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;


public class PlayerAirborneState : PlayerAllStates
{
    public PlayerAirborneState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        grounded = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (rigidbody2D.velocity.y < 0)
        {
            playerStateMachine.ChangeState(playerStateMachine._pFallState);
        }
        
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