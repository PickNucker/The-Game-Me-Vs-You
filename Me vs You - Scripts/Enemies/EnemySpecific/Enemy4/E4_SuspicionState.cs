using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_SuspicionState : SuspicionState
{
    Enemy4 enemy;
    public E4_SuspicionState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_SuspicionStateData stateData, Enemy4 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
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
