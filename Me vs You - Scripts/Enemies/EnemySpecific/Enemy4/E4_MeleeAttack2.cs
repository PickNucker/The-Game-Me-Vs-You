using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_MeleeAttack2 : BehaviourState
{
    Enemy4 enemy;

    public E4_MeleeAttack2(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateData, Enemy4 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.agent.isStopped = true;
        enemy.anim.Play("Attack02");
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
