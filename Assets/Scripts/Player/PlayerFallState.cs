using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class PlayerFallState : PlayerAirborneState
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerFallState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        animator.Play("Fall");
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