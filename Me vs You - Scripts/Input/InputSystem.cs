using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public static InputSystem instance;

    [HideInInspector]
    public PlayerControls playerControls;
    Player player;

    public Vector3 Movement { get; private set; }

    public bool JumpInput { get; private set; }
    public bool DodgeInput { get; private set; }
    public bool XPressed { get; private set; }
    public bool KreisPressed { get; private set; }
    public bool ViereckPressed { get; private set; }
    public bool DreieckPressed { get; private set; }
    public bool LockOn { get; private set; }
    public bool UnLockOn { get; private set; }
    public bool GetSecondL1Dropdown { get; private set; }
    public bool R1Dropdown { get; private set; }
    public bool PauseEnabled { get; private set; }
    public bool Sprint { get; private set; }

    public float verticalInput;
    public float horizontalInput;
   
    public Vector2 movementInput;

    public KeyCode[] interact;
    public KeyCode[] finisher;

    [Space]

    public Combo[] combo;

    private void Awake()
    {
        instance = this;
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();

            //Gameplay
            playerControls.Gameplay.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            playerControls.Gameplay.Jump.started += i => JumpInput = player.isGrounded ? true : false;

            playerControls.Gameplay.DodgeGround.started += i => DodgeInput = player.isGrounded ? true : false;
            playerControls.Gameplay.DodgeGround.canceled -= i => DodgeInput = false;

            //Gameplay Action
            playerControls.GameplayAction.X.started += i => XPressed = true;
            playerControls.GameplayAction.X.canceled += i => XPressed = false;

            playerControls.GameplayAction.Kreis.started += i => KreisPressed = true;
            playerControls.GameplayAction.Kreis.canceled += i => KreisPressed = false;

            playerControls.GameplayAction.Viereck.started += i => ViereckPressed = true;
            playerControls.GameplayAction.Viereck.canceled += i => ViereckPressed = false;

            playerControls.GameplayAction.Dreieck.started += i => DreieckPressed = true;
            playerControls.GameplayAction.Dreieck.canceled += i => DreieckPressed = false;

            playerControls.GameplayAction.LockOn.started += i => LockOn = true;
            playerControls.GameplayAction.UnLockOn.started += i => UnLockOn = true;

            playerControls.Gameplay.Sprint.started += i => Sprint = true;
            playerControls.Gameplay.Sprint.canceled += i => Sprint = false;

            // UI
            playerControls.UIOverall.L1Dropdown.started += i => GetSecondL1Dropdown = true;
            playerControls.UIOverall.L1Dropdown.canceled += i => GetSecondL1Dropdown = false;

            playerControls.UIOverall.R1Dropdown.started += i => R1Dropdown = true;
            playerControls.UIOverall.R1Dropdown.canceled += i => R1Dropdown = false;

            playerControls.UIOverall.Pause.started += i => PauseEnabled = !PauseEnabled;

            //playerControls.UIOverall.DPad += if => 
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInput()
    {
        HandleMovementInput();

        JumpHasBeenUsed();
        DodgeHasBeenUsed();
        //LockOnHasBeenUsed();
        //UnLockOnHasBeenUsed();

        XHasBeenUsed();
        KreisHasBeenUsed();
        ViereckHasBeenUsed();
        DreieckHasBeenUsed();
    }

    void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        Movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
    }  
    
    public void JumpHasBeenUsed() => JumpInput = false;
    public void DodgeHasBeenUsed() => DodgeInput = false;
    public void XHasBeenUsed() => XPressed = false;
    public void KreisHasBeenUsed() => KreisPressed = false;
    public void ViereckHasBeenUsed() => ViereckPressed = false;
    public void DreieckHasBeenUsed() => DreieckPressed = false;
    public void LockOnHasBeenUsed() => LockOn = false;
    public void UnLockOnHasBeenUsed() => UnLockOn = false;
    public void DisablePause() => PauseEnabled = false;
    public void DisableSprint() => Sprint = false;
    public void DisableL1() => R1Dropdown = false;
    public void DisableR1() => GetSecondL1Dropdown = false;

    public bool GetXPressed()
    {
        return XPressed;
    }
}
