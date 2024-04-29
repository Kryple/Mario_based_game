using System;
using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlayerStateMachine : StateMachine
{
    
    [HideInInspector] public PlayerRunState _pRunState;
    [HideInInspector] public PlayerIdleState _pIdleState;
    [HideInInspector] public PlayerJumpState _pJumpState;
    [HideInInspector] public PlayerFallState _pFallState;
    [HideInInspector] public PlayerGroundedState _pGroundedState;
    [HideInInspector] public PlayerAirborneState _pAirborneState;
    [HideInInspector] public PlayerAllStates _pAllStates;
    
    public Animator _animator;
    public Rigidbody2D _rigidbody2D;
    [FormerlySerializedAs("_boxCollider2D")] public CapsuleCollider2D _mainCollider2D;
    public Transform _self;
    public LayerMask _groundMask;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mainCollider2D = GetComponent<CapsuleCollider2D>();
        _self = GetComponent<Transform>();


        _pRunState = new PlayerRunState("PlayerRunState", this);
        _pIdleState = new PlayerIdleState("PlayerIdleState", this);
        _pJumpState = new PlayerJumpState("PlayerJumpState", this);
        _pFallState = new PlayerFallState("PlayerFallState", this);
        _pGroundedState = new PlayerGroundedState("PlayerGroundedState", this);
        _pAirborneState = new PlayerAirborneState("PlayerAirBorneState", this);
        _pAllStates = new PlayerAllStates("PlayerAllStates", this);
    }

    private void Start()
    {
        base.Start();
        
    }

    protected override BaseState GetInitialState()
    {
        return _pIdleState;
    }
}
