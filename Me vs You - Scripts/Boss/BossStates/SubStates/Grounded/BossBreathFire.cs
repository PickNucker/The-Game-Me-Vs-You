using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBreathFire : BossGroundedState
{
    public BossBreathFire(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
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
        boss.Anim.CrossFade("Breath Fire", .2f);
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
            if (chasePlayer)
            {
                bossStateMachine.ChangeState(boss.BossChaseState);
            }
            else
            {
                bossStateMachine.ChangeState(boss.BossMoveState);
            }
        }
    }
}
