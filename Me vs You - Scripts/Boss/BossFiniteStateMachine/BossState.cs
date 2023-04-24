using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState
{
    protected Boss boss;
    protected BossData bossData;
    protected BossStateMachine bossStateMachine;

    protected float startingTime;

    string animName;

    public BossState(Boss boss, BossData bossData, BossStateMachine bossStateMachine, string animName)
    {
        this.boss = boss;
        this.bossData = bossData;
        this.bossStateMachine = bossStateMachine;
        this.animName = animName;
    }

    public virtual void Enter()
    {
        DoChecks();
        startingTime = Time.time;

        if(animName != "")
            boss.Anim.SetBool(animName, true);
    }

    public virtual void Exit()
    {
        startingTime = 0;
        if (animName != "")
            boss.Anim.SetBool(animName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
