using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaseState : BossGroundedState
{
    int random;

    float timer = 0;

    public BossChaseState(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName) : base(boss, bossData, bossStateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        boss.abilityDone = false;
        timer = 0f;
        random = Random.Range(0, 100);
        boss.Anim.SetBool("idle", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timer += Time.deltaTime;

        boss.Agent.stoppingDistance = bossData.stoppingDistance;

        boss.SetDestination(Player.instance.transform.position, bossData.chaseMovementSpeed);

        if(attackRange)
        {
            boss.StopAgent();
            boss.Anim.SetBool("run", false);
        }
        else
        {
            boss.Anim.SetBool("run", true);
        }

        if (attackRange && timer >= bossData.timerBtwAttack)
        {
            boss.StopAgent();

            timer = 0f;
            
            if(random >= 60)
            {
                bossStateMachine.ChangeState(boss.BossAttack1);
            }
            else if(random < 60 && random >= 20)
            {
                bossStateMachine.ChangeState(boss.BossAttack2);
            }
            else
            {
                bossStateMachine.ChangeState(boss.BossBreathFire);
            }
        }

        if (timer >= 8f)
        {
            timer = 0f;
            boss.StopAgent();
            bossStateMachine.ChangeState(boss.BossBreathFire);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
