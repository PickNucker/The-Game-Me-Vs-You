using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine
{
    public BossState CurrentState { get; private set; }

    public void Initialize(BossState startingState)
    {
        CurrentState = startingState;
        //Debug.Log("Starting State: " + CurrentState);
        CurrentState.Enter();
    }

    public void ChangeState(BossState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        //Debug.Log("New State: " + CurrentState);
        CurrentState.Enter();
    }
}
