using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleTakeof : BossGroundedState
{
    public BossIdleTakeof(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        boss.StopAgent();
        //boss.Anim.SetTrigger("takeof");
        boss.Anim.CrossFade("Take Off", .1f);

        boss.Anim.SetBool("run", false);
        boss.Anim.SetBool("idle", false);
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (boss.abilityDone)
        {
            bossStateMachine.ChangeState(boss.BossFlyIdle);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
