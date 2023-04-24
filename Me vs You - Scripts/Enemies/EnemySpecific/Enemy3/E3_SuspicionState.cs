using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_SuspicionState : SuspicionState
{
    Enemy3 enemy;
    public E3_SuspicionState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_SuspicionStateData stateData, Enemy3 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        entity.agent.isStopped = true;
    }

    public override void Exit()
    {
        base.Exit();
        entity.agent.isStopped = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (agroRange)
        {
            stateMachine.ChangeState(enemy.chasePlayerState);
        }
        else if (attackRange)
        {
            stateMachine.ChangeState(enemy.targetingState);
        }
        else if (canReturnBack)
        {
            stateMachine.ChangeState(enemy.walkState);
        }
    }
}
