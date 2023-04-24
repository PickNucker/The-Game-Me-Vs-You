using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlyBreathFire : BossAirState
{
    public BossFlyBreathFire(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        boss.transform.LookAt(Player.instance.transform.position);
        boss.Anim.CrossFade("Fly Flame Attack", .2f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (abilityDone)
        {
            bossStateMachine.ChangeState(boss.BossFlyIdle);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
