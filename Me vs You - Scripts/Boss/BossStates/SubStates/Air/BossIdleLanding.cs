using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleLanding : BossAirState
{
    public BossIdleLanding(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
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
        //boss.Anim.SetTrigger("land");
        boss.Anim.CrossFade("Land", .1f);
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();



        if(boss.abilityDone)
        {
            if (chasePlayer)
            {
                bossStateMachine.ChangeState(boss.BossChaseState);
            }
            else if (attackRange)
            {
                bossStateMachine.ChangeState(boss.BossAttack1);
            }
            else
            {
                bossStateMachine.ChangeState(boss.BossIdleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
