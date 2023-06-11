using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    private string animBoolName;
    protected float xInput;
    protected Rigidbody2D rb;
    protected float stateTimer;
    public bool trigger;
    [SerializeField] protected float dashCooldown = 5f;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter() {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        trigger = false;
    }

    public virtual void Update() {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        player.SetVelocity(xInput *player.moveSpeed, rb.velocity.y);
        player.anim.SetFloat("yVelocity", rb.velocity.y);
        CheckForDashInput();
    }

    public virtual void Exit() {
        player.anim.SetBool(animBoolName, false);
    }

    
    public void CheckForDashInput()
    {
        dashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R) && dashCooldown < 0)
        {
            dashCooldown = 5f;
            stateMachine.ChangeState(player.dashState);
        }
    }

    public void AnimationFinishTrigger() {
        trigger = true;
    }
}
