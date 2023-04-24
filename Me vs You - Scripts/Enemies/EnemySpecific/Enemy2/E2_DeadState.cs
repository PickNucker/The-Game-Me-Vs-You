using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_DeadState : DeadState
{
    Enemy2 enemy;

    public E2_DeadState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_DeadState stateData, Enemy2 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.anim.ResetTrigger("hit");
        enemy.anim.SetBool("dead", true);
    }
}
