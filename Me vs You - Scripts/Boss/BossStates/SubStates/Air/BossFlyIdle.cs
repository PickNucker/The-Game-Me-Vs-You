using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlyIdle : BossAirState
{
    float timer = 0;
    public BossFlyIdle(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timer += Time.deltaTime;

        if (boss.wave1Cleared || boss.wave2Cleared)
        {
            bossStateMachine.ChangeState(boss.BossIdleLanding);
        }

        if (boss.wave2Cleared)
        {
            bossStateMachine.ChangeState(boss.BossIdleLanding);
        }

        if (timer > 5f && boss.canDoSpecialAttack)
        {
            timer = 0;
            bossStateMachine.ChangeState(boss.BossFlyBreathFire);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
