using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerGroundedState
{
    float timer;

    public PlayerSprintState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        timer = playerData.runTime;
        isSprinting = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.Input.DisableSprint();
        isSprinting = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.Input.PauseEnabled) return;

        player.IngameUi.ChangeText("G", "real", "is the", "PickNucker");

        if(player.Input.Sprint && player.Input.Movement.magnitude > 0.01f && player.isGrounded)
        {
            player.ApplyMovement(playerData.runSpeed);
        }
        else if (player.Input.Sprint && player.Input.Movement.magnitude < 0.01f && player.isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (!player.Input.Sprint && player.Input.Movement.magnitude > 0.01f && player.isGrounded)
        {
            stateMachine.ChangeState(player.MoveState);
        }
        else if (!player.Input.Sprint && player.Input.Movement.magnitude < 0.01f && player.isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else
        {
            stateMachine.ChangeState(player.MoveState);
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
