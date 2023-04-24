using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeAttack2 : BehaviourState
{
    Enemy1 enemy;

    public E1_MeleeAttack2(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateDatar, Enemy1 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateDatar, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.anim.Play("Attack02");
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

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
