using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_MeleeAttack : BehaviourState
{
    Enemy3 enemy;

    public E3_MeleeAttack(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateData, Enemy3 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.agent.isStopped = true;
        enemy.anim.Play("Attack01");
    }

    public override void Exit()
    {
        base.Exit();
        enemy.agent.isStopped = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.abilityDone)
        {
            if (targetingRange)
            {
                stateMachine.ChangeState(enemy.targetingState);
            }
            else if (agroRange)
            {
                stateMachine.ChangeState(enemy.chasePlayerState);
            }
            else
            {
                stateMachine.ChangeState(enemy.walkState);
            }
        }
    }
}
