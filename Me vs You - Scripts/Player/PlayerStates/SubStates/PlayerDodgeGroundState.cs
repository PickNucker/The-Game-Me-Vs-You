using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeGroundState : PlayerGroundedState
{
    public PlayerDodgeGroundState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Input.DisableSprint();
        player.currentlyAttacking = true;
        player.currentlyDodging = true;
        player.dodgeAttack = true;

        player.AnimManager.PlayTargetAnimation("Dodge", true, true);
        player.dodge.Play(Player.instance.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
        player.currentlyAttacking = false;
        player.currentlyDodging = false;
        //player.Input.DodgeHasBeenUsed();
    }

    public override void LogicUpdate()
    {
        if (player.canCombo && player.Input.XPressed)
        {
            stateMachine.ChangeState(player.Attack_1_4_G);
        }

        player.IngameUi.ChangeText("Dodge-Attack", "", "", "");

        if (!player.IsUsingRootMotion)
        {
            if (movement.magnitude != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }


        base.LogicUpdate();
    }
}
