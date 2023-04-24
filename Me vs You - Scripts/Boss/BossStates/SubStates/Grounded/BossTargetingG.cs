using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetingG : BossGroundedState
{
    float startTimer = 0;

    bool startTimert;
    public BossTargetingG(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        boss.Anim.SetBool("noAggro", true);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (chasePlayer)
        {

            boss.Anim.SetBool("noAggro", false);
            boss.Anim.SetBool("standUp", true);
            startTimert = true;
        }

        if (startTimert) startTimer += Time.deltaTime;

        if(startTimer >= 6)
        {
            boss.Anim.SetBool("standUp", false);
            bossStateMachine.ChangeState(boss.BossIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
