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

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter() {
        player.anim.SetBool(animBoolName, true);
    }

    public virtual void Update() {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    public virtual void Exit() {
        player.anim.SetBool(animBoolName, false);
    }
}
