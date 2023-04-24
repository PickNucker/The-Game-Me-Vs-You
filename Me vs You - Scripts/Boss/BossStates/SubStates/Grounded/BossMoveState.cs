using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveState : BossGroundedState
{
    int random;
    public BossMoveState(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        random = Random.Range(0, 100);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        boss.SetDestination(Player.instance.transform.position, bossData.standardMovementSpeed);

        if (chasePlayer)
        {
            if(random > 50) bossStateMachine.ChangeState(boss.BossChaseState);
            else bossStateMachine.ChangeState(boss.BossBreathFire);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
