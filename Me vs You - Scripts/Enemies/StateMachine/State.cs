using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
    protected AnimationManager animManger;

    protected string animationStringName;
    protected string animationBoolName;

    protected bool isInteracting = false;
    protected bool isUsingRootMotion = false;
    protected float startingTime;

    public State(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, string animationName, string animationBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animManger = animManger;
        this.animationStringName = animationName;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter()
    {
        startingTime = Time.time;

        if(animationStringName != "")
        {
            animManger.PlayTargetAnimation(animationStringName, isInteracting, isUsingRootMotion);
        }
        
        if(animationBoolName != "")
        {
            entity.anim.SetBool(animationBoolName, true);
        }
    }

    public virtual void Exit()
    {
        if (animationBoolName != "")
        {
            entity.anim.SetBool(animationBoolName, false);
        }
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
