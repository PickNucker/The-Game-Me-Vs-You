using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{

    protected Vector3 movement;

    protected bool isGrounded;
    protected bool isSprinting;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        player.CheckSurroundings();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.Input.PauseEnabled) return;

        movement = player.Input.Movement;

        if (CheckIfIsGrounded() && player.velocity.y < 0)
        {
            player.velocity.y = -2f;
        }
        if (player.canInteractWithSomething) return;

        player.ApplyGravityForce();

        if (player.Input.ViereckPressed && CheckIfIsGrounded() && !player.currentlyDodging && player.Input.GetSecondL1Dropdown && PlayerHealthBar.instance.ReadyToBleyblade)
        {
            stateMachine.ChangeState(player.Ability1);
        }
        else if (player.Input.DreieckPressed && CheckIfIsGrounded() && !player.currentlyDodging && player.Input.GetSecondL1Dropdown)
        {
            //stateMachine.ChangeState(player.Ability2);
        }
        else if (player.Input.KreisPressed && CheckIfIsGrounded() && !player.currentlyDodging && player.Input.GetSecondL1Dropdown)
        {
            //stateMachine.ChangeState(player.Ability3);
        }
        else if (player.Input.XPressed && CheckIfIsGrounded() && !player.currentlyDodging && player.Input.GetSecondL1Dropdown && PlayerHealthBar.instance.ReadyToHeal)
        {
            stateMachine.ChangeState(player.Ability4);
        }


        //if (player.Input.JumpInput && CheckIfIsGrounded() && !player.currentlyDodging && !player.Input.GetSecondL1Dropdown)
        //{
        //    stateMachine.ChangeState(player.JumpState);
        //}
        if (player.Input.DodgeInput && CheckIfIsGrounded() && !player.IsUsingRootMotion && !player.Input.GetSecondL1Dropdown && !isSprinting)
        {
            stateMachine.ChangeState(player.DodgeGroundState);
        }
        
        if (CheckIfIsGrounded() && !player.currentlyDodging && !player.currentlyAttacking && player.canStartCombo && player.Input.XPressed && !player.Input.GetSecondL1Dropdown && !isSprinting)
        {
            stateMachine.ChangeState(player.Attack_1_1_G);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public bool CheckIfIsGrounded()
    {
        if (player.isGrounded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
