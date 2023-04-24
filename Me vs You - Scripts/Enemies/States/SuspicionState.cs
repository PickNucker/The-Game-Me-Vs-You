using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionState : State
{
    D_SuspicionStateData stateData;

    protected bool agroRange;
    protected bool attackRange;

    protected bool canReturnBack;

    float timer;

    public SuspicionState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_SuspicionStateData stateData, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, animationName, animationBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        Check();

        timer = 0;
        canReturnBack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        timer += Time.deltaTime;

        if (timer >= stateData.suspicionTime) canReturnBack = true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Check();
    }

    void Check()
    {
        agroRange = entity.CheckDistanceToAgro();
        attackRange = entity.CheckDistanceToAttack();
    }
}
