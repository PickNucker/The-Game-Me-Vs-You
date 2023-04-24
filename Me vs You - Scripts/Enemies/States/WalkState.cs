using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    protected D_WalkState stateData;

    protected bool agroRange;
    protected bool attackRange;

    protected bool canChangeToIdle;

    public WalkState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger,D_WalkState stateData, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, animationName, animationBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        canChangeToIdle = false;
        entity.agent.speed = stateData.walkSpeed;

        agroRange = entity.CheckDistanceToAgro();
        attackRange = entity.CheckDistanceToAttack();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(entity.patrolPath == null)
        {
            entity.SetDestination(entity.guardPos);
            canChangeToIdle = true;
        }
        else
        {
            entity.PatrolBehaviour();
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        agroRange = entity.CheckDistanceToAgro();
        attackRange = entity.CheckDistanceToAttack();
    }

    
}
