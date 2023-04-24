using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E7_TargetingState : BehaviourState
{
    Enemy7 enemy;
    D_BehaviourState stateData;

    float timer = 0f;
    int random;

    public E7_TargetingState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateDatar, Enemy7 enemy, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, stateDatar, animationName, animationBoolName)
    {
        this.enemy = enemy;
        this.stateData = stateDatar;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.stoppingDistance = 1.9f;
        timer = 0f;
        random = Random.Range(0, 100);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool("run", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timer += Time.deltaTime;

        enemy.agent.SetDestination(Player.instance.transform.position);

        if (Vector3.Distance(enemy.transform.position, Player.instance.transform.position) < 2.1f)
        {
            enemy.anim.SetBool("run", false);
        }
        else
        {
            enemy.anim.SetBool("run", true);
        }

        if (attackRange && timer >= stateData.timeBetweenAttacks)
        {
            timer = 0;

            if (random > 40)
            {
                stateMachine.ChangeState(enemy.meeleAttackState);
            }
            //else if(random < 41 && random > 20)
            //{
            //    stateMachine.ChangeState(enemy.meeleAttackState2);
            //}
            else
            {
                stateMachine.ChangeState(enemy.meeleAttackState2);
            }
        }
        else if (!agroRange)
        {
            stateMachine.ChangeState(enemy.suspicionState);
        }

    }
}
