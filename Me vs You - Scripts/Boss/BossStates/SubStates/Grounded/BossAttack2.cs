using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2 : BossGroundedState
{
    public BossAttack2(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        boss.Anim.CrossFade("Attack 2", .2f);
        boss.transform.LookAt(Player.instance.transform.position);
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
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
