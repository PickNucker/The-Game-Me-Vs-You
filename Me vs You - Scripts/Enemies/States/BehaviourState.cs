using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourState : State
{
    D_BehaviourState stateDatar;

    protected bool abilityDone;
    protected bool canAttack;

    protected bool targetingRange;
    protected bool agroRange;
    protected bool attackRange;

    protected float timerBetweenAttacks;

    //protected int random;
    

    public BehaviourState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_BehaviourState stateDatar, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, animationName, animationBoolName)
    {
        this.stateDatar = stateDatar;
    }

    public override void Enter()
    {
        base.Enter();

        Check();

        //random = Random.Range(0, 100);

        entity.abilityDone = false;
        entity.gotHit = false;
        entity.agent.speed = stateDatar.chaseSpeed;

        canAttack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate(); 

        entity.transform.LookAt(Player.instance.transform.position);
        entity.transform.eulerAngles = new Vector3(0, entity.transform.eulerAngles.y, 0);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Check();
    }

    void Check()
    {
        agroRange = entity.CheckDistanceToAgro();
        attackRange = entity.CheckDistanceToAttack();
        targetingRange = entity.CheckDistanceForTargeting();
    }
}
