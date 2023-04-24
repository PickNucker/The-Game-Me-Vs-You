using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Attack_1_4_G : PlayerAbilityState
{
    bool dony;
    public P_Attack_1_4_G(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        player.AnimManager.PlayTargetAnimation(player.Input.combo[0].animationName[3], true, true);
        player.swordHit.Play(player.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
        player.dodgeAttack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.Input.PauseEnabled) return;
        if (!player.currentlyDodging && player.currentTarget != null)
            player.ApplyRotationToTarget();

        player.IngameUi.ChangeText("Attack", "", "", "Jump-Attack");

        //if (player.isGrounded && player.Input.ViereckPressed)
        //{
        //    if (player.Input.horizontalInput == -1 || player.Input.horizontalInput == -0.707107)
        //    {
        //        stateMachine.ChangeState(player.DodgeLeftState);
        //    }
        //    else if (player.Input.horizontalInput == 1 || player.Input.horizontalInput == 0.707107)
        //    {
        //        stateMachine.ChangeState(player.DodgeRightState);
        //    }
        //    else
        //    {
        //        stateMachine.ChangeState(player.DodgeBackState);
        //    }
        //}

        if (!player.dodgeAttack && player.canCombo && player.isGrounded && player.Input.DreieckPressed)
        {
            stateMachine.ChangeState(player.UpperAttack_1_5_A);
        }
        else if (player.dodgeAttack && player.canCombo && player.isGrounded && player.Input.XPressed)
        {
            stateMachine.ChangeState(player.Attack_1_1_G);
        }
    }

}
