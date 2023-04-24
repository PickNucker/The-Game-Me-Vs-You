using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerAbilityState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.AnimHasNotFinished();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log("CurrentState Landstate");

        player.IngameUi.ChangeText("", "", "", "");

        if (player.Input.Movement.magnitude != 0)
            player.ApplyMovement(playerData.InAirForce);

        if (player.AnimationHasFinished)
        {
            if(player.Input.Movement.magnitude != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
