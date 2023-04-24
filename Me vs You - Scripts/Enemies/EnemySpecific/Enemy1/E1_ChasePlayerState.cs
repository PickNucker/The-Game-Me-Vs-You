using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChasePlayerState : ChasePlayerState
{
    Enemy1 enemy;

    float timer;

    public E1_ChasePlayerState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_ChasePlayerState stateData, Enemy1 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
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
        else if(!attackRange && !agroRange)
        {
            timer += Time.deltaTime;
            if(timer >= chaseRange)
                stateMachine.ChangeState(enemy.suspicionState);
        }
    }
}
