using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool abilityDone;

    protected bool isGrounded;

    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        abilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.Input.PauseEnabled) return;
        if (player.canInteractWithSomething) return;

        isGrounded = player.isGrounded;



        if (abilityDone && !player.currentlyAttacking)
        {
            if (isGrounded && player.Input.Movement.magnitude != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if(isGrounded && player.Input.Movement.magnitude == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if(!isGrounded)
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
