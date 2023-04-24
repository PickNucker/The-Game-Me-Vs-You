using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_GotHitState : BehaviourState
{
    Enemy3 enemy;

    public E3_GotHitState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateDatar, Enemy3 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateDatar, animationName, animationBoolName)
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
