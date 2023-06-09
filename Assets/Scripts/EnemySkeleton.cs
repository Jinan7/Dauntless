using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{

    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        idleState = new SkeletonIdleState(stateMachine,this, "Idle", this);
        moveState = new SkeletonMoveState(stateMachine, this, "Idle", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
