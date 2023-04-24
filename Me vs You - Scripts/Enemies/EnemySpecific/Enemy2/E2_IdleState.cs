using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_IdleState : IdleState
{
    Enemy2 enemy;

    public E2_IdleState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_IdleState idleState, Enemy2 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, idleState, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (idleTimeOver)
        {
            stateMachine.ChangeState(enemy.walkState);
        }

        if (agroRange)
        {
            stateMachine.ChangeState(enemy.chasePlayerState);
        }
    }
}
