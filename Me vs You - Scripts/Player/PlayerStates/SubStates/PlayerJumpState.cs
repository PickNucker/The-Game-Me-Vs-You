using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    float timer = Mathf.Infinity;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        timer += Time.deltaTime;

        if (player.Input.Movement.magnitude != 0)
            player.ApplyMovement(playerData.InAirForce);

        if (timer < playerData.jumpTimer)
        {
           // if (player.Input.Movement.magnitude != 0)
           //     player.ApplyMovement(playerData.InAirForce);

            player.ApplyJumpForce(playerData.jumpForce);
        }
        else
        {
            abilityDone = true;
        }
    }

}