using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.Input.PauseEnabled) return;

        player.IngameUi.ChangeText("Attack", "Sprint", "Dodge", "Interact");

        if (movement.magnitude < 0.01f && player.isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if(!player.Input.Sprint && player.Input.Movement.magnitude > 0.01f)
        {
            player.ApplyMovement(playerData.movementSpeed);
        }
        else if (player.Input.Sprint && player.Input.Movement.magnitude > 0.01f && !player.Input.GetSecondL1Dropdown)
        {
            stateMachine.ChangeState(player.SprintState);
        }
    }
}
