using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_DeadState : DeadState
{
    Enemy3 enemy;

    public E3_DeadState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_DeadState stateData, Enemy3 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateData, animationName, animationBoolName)
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
