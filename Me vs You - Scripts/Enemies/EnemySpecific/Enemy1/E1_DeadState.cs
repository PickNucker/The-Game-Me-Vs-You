using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeadState : DeadState
{
    Enemy1 enemy;

    public E1_DeadState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_DeadState stateData, Enemy1 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.anim.ResetTrigger("hit");
    }

}
