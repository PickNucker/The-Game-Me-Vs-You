using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_UpperAttack_1_5_A : PlayerAbilityState
{
    public P_UpperAttack_1_5_A(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.currentlyAttacking = true;
        player.canStartCombo = false;
        player.canCombo = false;

        abilityDone = true;

        player.AnimManager.PlayTargetAnimation(player.Input.combo[0].animationName[4], true, true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //player.AppplyKnockBack(Vector3.forward, 5f, 5f, 10);
        if (player.Input.PauseEnabled) return;
        player.IngameUi.ChangeText("Attack", "", "", "");

        if (!player.currentlyDodging && player.currentTarget != null)
            player.ApplyRotationToTarget();

        if (player.canCombo && player.isGrounded && player.Input.XPressed)
        {
            stateMachine.ChangeState(player.AirAttack_1_6_A);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
