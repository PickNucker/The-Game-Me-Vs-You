using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E8_WalkState : WalkState
{
    Enemy8 enemy;

    public E8_WalkState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_WalkState stateData, Enemy8 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
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
