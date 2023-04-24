using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGroundedState : BossState
{
    protected bool abilityDone;

    protected bool chasePlayer;
    protected bool attackRange;

    protected bool firstStage;
    public BossGroundedState(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        chasePlayer = boss.CheckDistanceForChase();
        attackRange = boss.CheckDistanceToAttack();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        abilityDone = boss.abilityDone;

        boss.transform.eulerAngles = new Vector3(0, boss.transform.eulerAngles.y, 0);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    
}
