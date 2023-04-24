using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_4 : PlayerGroundedState
{
    public Ability_4(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        PlayerHealthBar.instance.ResetTimer();
        player.healUp.Play(player.transform.position);
        PlayerHealthBar.instance.AddHearts(10);

        GameObject.Instantiate(player.healEffekt, player.healEffektPos.position, Quaternion.identity);

        IngameUIHandler.instance.deActivateSecondL1.Invoke();

        player.Input.DisableSprint();
        player.currentlyAttacking = true;
        player.currentlyDodging = true;
        player.dodgeAttack = true;

        player.AnimManager.PlayTargetAnimation("HealUp", true, true);
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
        player.IngameUi.ChangeText("Nucker", "dem", "zu", "Pick");

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

        if (!player.currentlyDodging && player.currentTarget != null)
            player.ApplyRotationToTarget();

        base.LogicUpdate();
    }
}
