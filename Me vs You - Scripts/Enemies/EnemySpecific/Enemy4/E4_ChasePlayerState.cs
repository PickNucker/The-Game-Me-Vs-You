using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_ChasePlayerState : ChasePlayerState
{
    Enemy4 enemy;

    float timer;

    public E4_ChasePlayerState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_ChasePlayerState stateData, Enemy4 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
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
