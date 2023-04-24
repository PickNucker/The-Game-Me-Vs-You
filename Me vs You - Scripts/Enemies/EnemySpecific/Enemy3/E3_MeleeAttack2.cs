using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_MeleeAttack2 : BehaviourState
{
    Enemy3 enemy;

    public E3_MeleeAttack2(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateDatar, Enemy3 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateDatar, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.anim.Play("Attack02");
        enemy.agent.isStopped = true;
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
