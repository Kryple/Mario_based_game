using System;
using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerStateMachine : StateMachine
{
    
    [HideInInspector] public PlayerRunState PRunState;
    [HideInInspector] public PlayerIdleState PIdleState;
    [HideInInspector] public PlayerJumpState PJumpState;
    [HideInInspector] public PlayerFallState PFallState;


    public List<BaseState> stateList = new List<BaseState>();
    public Animator animator;
    public Rigidbody2D rigidbody2D;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();


        PRunState = new PlayerRunState("PlayerRunState", this);
        PIdleState = new PlayerIdleState("PlayerIdleState", this);
        PJumpState = new PlayerJumpState("PlayerJumpState", this);
        PFallState = new PlayerFallState("PlayerFallState", this);
        
        stateList.Add(PRunState);
        stateList.Add(PIdleState);
        stateList.Add(PJumpState);
        stateList.Add(PFallState);
    }

    private void Start()
    {
        base.Start();
        
    }

    private void Update()
    {
        
    }
    

    protected override BaseState GetInitialState()
    {
        return PIdleState;
    }
}
