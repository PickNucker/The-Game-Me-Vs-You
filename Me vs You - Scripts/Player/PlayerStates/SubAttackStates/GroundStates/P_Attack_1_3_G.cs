using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Attack_1_3_G : PlayerAbilityState
{
    public P_Attack_1_3_G(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        player.AnimManager.PlayTargetAnimation(player.Input.combo[0].animationName[2], true, true);
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
        player.IngameUi.ChangeText("Attack", "", "DodgeAttack", "");

        if (!player.currentlyDodging && player.currentTarget != null)
            player.ApplyRotationToTarget();

        if (player.canCombo && player.isGrounded && player.Input.ViereckPressed)
        {
            stateMachine.ChangeState(player.Attack_1_4_G);
        }

        if (player.canCombo && player.isGrounded && player.Input.XPressed)
        {
            stateMachine.ChangeState(player.Attack_4_6_G);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
