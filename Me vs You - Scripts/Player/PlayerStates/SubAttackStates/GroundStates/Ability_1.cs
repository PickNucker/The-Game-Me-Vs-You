using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_1 : PlayerGroundedState
{
    public Ability_1(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        IngameUIHandler.instance.deActivateSecondL1.Invoke();

        PlayerHealthBar.instance.ResetTimer2();

        player.Input.DisableSprint();
        player.currentlyAttacking = true;
        player.currentlyDodging = true;
        player.dodgeAttack = true;

        player.AnimManager.PlayTargetAnimation("Skill_1", true, true);
        player.dodge.Play(Player.instance.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
        player.currentlyAttacking = false;
        player.currentlyDodging = false;
    }

    public override void LogicUpdate()
    {
        player.IngameUi.ChangeText("cool", "sehr", "ist", "Anil");

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
