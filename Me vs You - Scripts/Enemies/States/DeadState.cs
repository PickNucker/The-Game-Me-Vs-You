using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    D_DeadState stateData;

    public DeadState(Entity entity, FiniteStateMachine stateMachine, AnimationManager animManger, D_DeadState stateData, string animationName, string animationBoolName) : base(entity, stateMachine, animManger, animationName, animationBoolName)
    {
        this.stateData = stateData;
    }
}
