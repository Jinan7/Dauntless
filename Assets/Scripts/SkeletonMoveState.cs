using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : EnemyState
{
    private EnemySkeleton enemy;
    public SkeletonMoveState(EnemyStateMachine _stateMachine, Enemy _enemyBase, string _animBoolName, EnemySkeleton _enemy) : base(_stateMachine, _enemyBase, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.moveSpeed*enemy.orientation, enemy.rb.velocity.y);

        if (enemy.IsWallDetected() || !enemy.IsGroundDetected())
        {
            Debug.Log("True");
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
