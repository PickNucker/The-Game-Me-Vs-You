using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Attack_3_6_G : PlayerAbilityState
{
    public P_Attack_3_6_G(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.Input.DisableSprint();
        player.canStartCombo = false;
        player.currentlyAttacking = true;
        player.dodgeAttack = false;
        player.canCombo = false;

        abilityDone = true;

        player.AnimManager.PlayTargetAnimation(player.Input.combo[2].animationName[4], false, true);
        player.swordHit.Play(player.transform.position);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.Input.PauseEnabled) return;
        player.IngameUi.ChangeText("", "Attack", "", "");

        if (!player.currentlyDodging && player.currentTarget != null)
            player.ApplyRotationToTarget();

        if(player.isGrounded && player.Input.ViereckPressed)
        {
            if (player.Input.horizontalInput == -1 || player.Input.horizontalInput == -0.707107)
            {
                 stateMachine.ChangeState(player.DodgeLeftState); 
            }
            else if (player.Input.horizontalInput == 1 || player.Input.horizontalInput == 0.707107)
            {
                stateMachine.ChangeState(player.DodgeRightState);
            }
            else
            {
                stateMachine.ChangeState(player.DodgeBackState);
            }
        }

        if (player.canCombo && player.isGrounded && player.Input.KreisPressed)
        {
            stateMachine.ChangeState(player.Attack_3_7_G);
        }
    }
}
