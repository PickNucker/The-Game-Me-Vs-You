using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerState : State
{
    D_ChasePlayerState stateData;
    protected bool agroRange;
    protected bool attackRange;
    protected bool targetingRange;
    protected float chaseRange;

    public ChasePlayerState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_ChasePlayerState stateData, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, animationName, animationBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        Check();

        entity.agent.speed = stateData.chaseMovementSpeed;
        entity.agent.stoppingDistance = stateData.stoppingDistance;
    }


    public override void Exit()
    {
        base.Exit();
        entity.agent.stoppingDistance = 0;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Check();
    }
    private void Check()
    {
        agroRange = entity.CheckDistanceToAgro();
        attackRange = entity.CheckDistanceToAttack();
        targetingRange = entity.CheckDistanceForTargeting();
    }
}
