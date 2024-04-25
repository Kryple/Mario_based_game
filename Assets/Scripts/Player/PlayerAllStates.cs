using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using FSM;
using TMPro;
using UnityEngine;
   
public class PlayerAllStates : BaseState
{
    public bool isCompleted { get; protected set; }
    public float time => Time.time - startTime;
    
    
    protected PlayerStateMachine playerStateMachine;
    protected Rigidbody2D rigidbody2D;
    protected BoxCollider2D boxCollider2D;
    protected Animator animator;
    protected Transform self;
    
    protected float startTime;
    protected bool grounded;
    protected LayerMask groundMask;
    
    //movement properties
    protected float acceleration = 0.4f;
    protected float xInput;
    protected float direction = 1;
    protected float groundDecay = 0.44f;
    
    static protected float runSpeed = 3f;


    
    public PlayerAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        playerStateMachine = (PlayerStateMachine) stateMachine;
        rigidbody2D = playerStateMachine._rigidbody2D;
        boxCollider2D = playerStateMachine._boxCollider2D;
        animator = playerStateMachine._animator;
        self = playerStateMachine._self;
        groundMask = playerStateMachine._groundMask;
        
        
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        xInput = Input.GetAxis("Horizontal");

              
        
        FaceInput();
        
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        
        CheckGround();
        ApplyFriction();
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    
    
    void FaceInput() 
    {   
        if (Mathf.Abs(xInput) > 0) 
            direction = Mathf.Sign(xInput);
        self.localScale = new Vector3(direction, 1, 1);
    }
    
    void CheckGround() {
        Debug.Log($"colliders: {Physics2D.OverlapAreaAll(boxCollider2D.bounds.min, boxCollider2D.bounds.max, groundMask).Length}");
        
        grounded = Physics2D.OverlapAreaAll(boxCollider2D.bounds.min + new Vector3(0f, 0.06f, 0f), boxCollider2D.bounds.max, groundMask).Length > 0;
    }
    
    void ApplyFriction() {
        if (grounded && xInput == 0 && rigidbody2D.velocity.y <= 0) {
            rigidbody2D.velocity *= groundDecay;
        }
    }
}
