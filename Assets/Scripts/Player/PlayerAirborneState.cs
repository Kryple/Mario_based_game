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