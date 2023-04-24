using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_AirAttack_1_8_A : PlayerAbilityState
{
    public P_AirAttack_1_8_A(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        player.AnimManager.PlayTargetAnimation(player.Input.combo[0].animationName[7], true, true);
        player.swordHit.Play(player.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.Input.PauseEnabled) return;
        player.IngameUi.ChangeText("", "", "", "");

        if (!player.currentlyDodging && player.currentTarget != null)
            player.ApplyRotationToTarget();

        // if (player.canCombo && player.isGrounded && player.Input.combo[0].keycodeIndex[8].GetButtonDown())
        // {
        //     stateMachine.ChangeState();
        // }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
