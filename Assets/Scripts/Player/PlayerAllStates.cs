using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using FSM;
using UnityEngine;
   
public class PlayerAllStates : BaseState
{
    public bool isCompleted { get; protected set; }
    public float time => Time.time - startTime;
    
    
    protected PlayerStateMachine playerStateMachine;
    protected Rigidbody2D rigidbody2D;
    protected Animator animator;
    
    protected float startTime;
        
    protected bool grounded;
    protected float xInput;
    
    
    static protected float runSpeed;


    
    public PlayerAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        playerStateMachine = (PlayerStateMachine) stateMachine;
        rigidbody2D = playerStateMachine.rigidbody2D;
        animator = playerStateMachine.animator;
        Debug.Log($"Set up for all states");
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        xInput = Input.GetAxis("Horizontal");
        
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
