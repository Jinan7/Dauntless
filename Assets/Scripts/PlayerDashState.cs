using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
        player.moveSpeed = player.dashSpeed;
    }

    public override void Exit()
    {
        player.moveSpeed = 3f;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
