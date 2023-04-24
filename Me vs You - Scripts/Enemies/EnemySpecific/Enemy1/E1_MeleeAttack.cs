using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeAttack : BehaviourState
{
    Enemy1 enemy;
    
    public E1_MeleeAttack(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateData, Enemy1 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.anim.Play("Attack01");
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
