using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAtackState : PlayerState
{

    private int count = 1;
    public PlayerAtackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        player.anim.SetInteger("ComboCount", count);
        base.Enter();
    }

    public override void Exit()
    {
        count = ((count + 1) % 3)+1;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (trigger ==  false)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    
}
