using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_IdleState : IdleState
{
    Enemy6 enemy;

    public E6_IdleState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_IdleState idleState, Enemy6 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, idleState, animationName, animationBoolName)
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
