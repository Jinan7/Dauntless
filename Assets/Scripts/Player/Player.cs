using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player : Entity
{

    [Header("Move info")]
    public float moveSpeed = 3f;
    public float jumpForce = 12f;
    public float dashSpeed;
    public float dashDuration = 2f;

    

    

    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState {get; private set;}
    public PlayerJumpState jumpState { get; private set;}
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerAtackState atackState { get; private set; }

    

    protected override void Awake()
    {
        Debug.Log("Waking up");
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        atackState = new PlayerAtackState( this, stateMachine, "Attack" );
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);

    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    


    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    

    

}
