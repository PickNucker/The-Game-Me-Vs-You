using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_GotHitState : BehaviourState
{
    Enemy5 enemy;

    public E5_GotHitState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateDatar, Enemy5 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateDatar, animationName, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.enabled = false;

    }

    public override void Exit()
    {
        base.Exit();
        enemy.agent.enabled = true;
    }

    public override void LogicUpdate()
    {
        if (enemy.isDead) return;
        enemy.anim.SetTrigger("hit");
        enemy.rigid.AddForce(-enemy.transform.forward * 5f, ForceMode.Impulse);
        base.LogicUpdate();

        if (targetingRange)
        {
            stateMachine.ChangeState(enemy.targetingState);
        }
    }
}
