using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_WalkState : WalkState
{
    Enemy1 enemy;

    public E1_WalkState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_WalkState stateData, Enemy1 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();  

        if (canChangeToIdle && Vector3.Distance(enemy.transform.position, entity.guardPos) <= 0.15f)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
        

        if (agroRange)
        {
            stateMachine.ChangeState(enemy.chasePlayerState);
        }
    }

}
