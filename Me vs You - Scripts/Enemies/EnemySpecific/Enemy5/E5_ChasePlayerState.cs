using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_ChasePlayerState : ChasePlayerState
{
    Enemy5 enemy;

    float timer;

    public E5_ChasePlayerState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_ChasePlayerState stateData, Enemy5 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.SetDestination(entity.player.transform.position);

        if (targetingRange)
        {
            stateMachine.ChangeState(enemy.targetingState);
        }
        else if (!attackRange && !agroRange)
        {
            timer += Time.deltaTime;
            if (timer >= chaseRange)
                stateMachine.ChangeState(enemy.suspicionState);
        }
    }
}
