using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool idleTimeOver;

    protected bool agroRange;
    protected bool attackRange;

    float idleTime;
    public IdleState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_IdleState idleState, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, animationName, animationBoolName)
    {
        this.stateData = idleState;
    }

    public override void Enter()
    {
        base.Enter();

        idleTimeOver = false;
        entity.agent.isStopped = true;

        agroRange = entity.CheckDistanceToAgro();
        attackRange = entity.CheckDistanceToAttack();

        IdleTime();

    }

    public override void Exit()
    {
        base.Exit();
        entity.agent.isStopped = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startingTime + idleTime && stateData.doHaveOwnPath)
        {
            idleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        agroRange = entity.CheckDistanceToAgro();
        attackRange = entity.CheckDistanceToAttack();
    }

    public virtual void IdleTime()
    {
        idleTime = Random.Range(stateData.minTime, stateData.maxTime);
    }
}
