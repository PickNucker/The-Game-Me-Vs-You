// GENERATED AUTOMATICALLY FROM 'Assets/The Game/Script/Player/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""eb76f1b7-b077-4b7e-9a7d-bde4db6493e1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""031ed8fa-147d-442c-a430-ddab9b41e9ac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""640b4338-75b5-456b-a6bb-770b34303cb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap(tapCount=1)""
                },
                {
                    ""name"": ""DodgeGround"",
                    ""type"": ""Button"",
                    ""id"": ""f35826b2-a301-4455-b6b4-bea19a39fd55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""e8f9055e-4fe0-4434-97aa-2da4f2f19d2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD-Movement"",
                    ""id"": ""88e1fa76-543d-44e6-a6db-62a0298cd854"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7554478c-d620-45a8-80d1-8f44dd131ce6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e38317a0-cb70-4aaa-9ca1-78af794e090f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ab8d86ff-556d-4f78-9c47-29c75e3245ec"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0d17e430-eb5e-484b-be26-b527a43dd9e3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""8a0a4577-7a2b-44f6-b298-dcbec61545ae"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eeb8a793-bd30-43a5-a925-67779e1a69c5"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""42053077-bb2e-47c5-8102-2b722d74eec1"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ef515353-f979-4dcf-a7b7-a7f758705c5a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5ae6f0ad-5c9b-4970-926f-e80ed20c6843"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""413877dc-7941-4fba-a513-902873abee49"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fb7ac07-d5c6-42ea-ab6d-1d0f1fb99924"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9af499d7-de2e-4db8-9979-268289bb47e0"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DodgeGround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0acf6069-6712-4eea-a756-fb36dbdd3580"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DodgeGround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ba7cbb2-28a6-4395-ae21-bb6ec2dea2f9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c790dd8-b63d-4e8c-9a31-93c0f0caf8fc"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay Action"",
            ""id"": ""c5ddc21a-8fea-4e16-98cc-d1ee57d2b7ed"",
            ""actions"": [
                {
                    ""name"": ""Dreieck"",
                    ""type"": ""Button"",
                    ""id"": ""2e154d5c-393d-4d69-8b73-7b3dc9408386"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Viereck"",
                    ""type"": ""Button"",
                    ""id"": ""da2f2415-2320-44bc-8055-5943ff7a9caa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kreis"",
                    ""type"": ""Button"",
                    ""id"": ""84c962ba-181c-4bd2-9496-0124e292bc38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""cfe3eb15-66b9-4d4b-a4ee-7329ce0fe673"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""e334cdc1-009a-42cd-824c-622c1e4caec7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UnLockOn"",
                    ""type"": ""Button"",
                    ""id"": ""9d50fc3c-8b5e-4403-b95e-66cd4f63dee7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""401e350d-fff4-4894-8fc2-6e70824985a7"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dreieck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d300885-dbba-4b97-befb-c5af4264fac0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dreieck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01fe63b6-d227-41ef-911f-7fe74fae024a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Viereck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e384b8b-12e4-4932-bad4-75cdd60ae626"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Viereck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ac2d46f-624b-4832-90b0-bd3ba39dd4dc"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Kreis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c2fec11-272a-4167-bb78-8c22f4b7db67"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Kreis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ed8cc66-35d4-463a-a945-7e1449b0a4d8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9559c50-4f69-46c7-8acb-4d907debb9d9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d51148b-bd18-43fc-8d9d-72f444c03f84"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11fb76d8-dcab-4150-b450-39080bda6d11"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bc63ecb-594f-44eb-acc7-8f5535b8b642"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UnLockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce93912e-fe63-415c-93c3-5b8774e88024"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UnLockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIOverall"",
            ""id"": ""68d26fdf-e925-44b9-aea0-192070e83365"",
            ""actions"": [
                {
                    ""name"": ""L1-Dropdown"",
                    ""type"": ""Button"",
                    ""id"": ""72d4b047-7d1c-4960-b6bd-9369d671d990"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R1-Dropdown"",
                    ""type"": ""Button"",
                    ""id"": ""f79a169d-bfb6-459c-923a-d2f9cfbdb7a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""9358a209-ff29-44f4-b2ec-0725db942dbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""53e73aa4-aaf4-47a6-bcd0-ffcecb06918e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""2c48d486-6640-4d96-971e-84cd7b901d77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back/Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""4bef8a4a-4161-405e-a877-689a676e45f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPad"",
                    ""type"": ""Value"",
                    ""id"": ""14c73993-5fd8-479b-984e-7ed6c3c7b283"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1cbe47ea-e53e-4c30-9229-f4ff41419262"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""L1-Dropdown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50ad0979-b297-48f6-8707-9a342dadad64"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""L1-Dropdown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce8f5142-a502-48a6-8d28-422039ef234e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa6f446d-1cee-4258-b732-6aefc27a83e6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""ca1ba6be-2309-438b-b6bd-bb565ec17a20"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""696f663c-61e2-49b9-9d7f-763a520de42e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f3182d3d-50a3-43c1-9edd-ac14937aeb80"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""95eeb1ec-7560-4e87-b5d3-d9b288e5dbbb"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ec247d8d-ed72-4be2-a900-8822ea54518b"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f59bc91-34ef-4d86-bf51-a98218682ba1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f16b95a0-f451-42c8-8c56-b981244b6d6f"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""18b6727d-08ae-4e68-a232-de2c06a4dde5"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""24d59ce6-454c-4f37-beb4-7a04470d4f2c"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""d159c85e-40c1-4ae2-8f5f-f589775a378d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cac4330d-92eb-4d7b-9a81-b14e7389700d"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2d1d1731-79fe-4e91-a714-7094e46dd0fc"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7b6f86a7-e761-409a-ac0f-3529be377e6d"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c0762688-398d-49a1-9c1c-a75c20b08a78"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""5da25089-0047-4fd4-8fae-09b7d153409b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a09d7b68-39d5-431f-8f9e-caeac13753d5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5d132dae-8d24-4801-a4a5-94154b6cafee"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e90ab0e0-1d72-4bef-a4c0-36787ff35d9b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0525819a-1315-4f4f-a4ad-f6491364c496"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4c41486e-b5d6-4d9c-a8e8-fbb9fda91c21"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""edfdb4e2-5e69-4ed1-93cf-649b320eca8f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ed847890-089f-47f2-9d1c-c12442ac12b3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a336e17b-4fdc-451a-9752-da20ac9334d9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f30c0273-5a23-4ae4-9c11-a9395f50372d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5302c4f1-0b28-4fa7-a17e-e4adada6958d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ae44973-3576-4e2a-95ad-91e56117efd6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acbc9dfa-e127-4ee0-b530-1883d422c340"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back/Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""863b29ac-44fd-4099-b44d-0945672f323d"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back/Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da29ff5a-b56b-438f-ba12-1b87ba630949"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back/Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9d54ae3-3da1-42ab-b0ec-c6a5dcb571c0"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dfa47b1-6b55-43b6-980a-f8fa87a9148b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6885a283-e79a-4642-a277-9db9f8a0246c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""R1-Dropdown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad46955b-569b-4e68-bfcc-be4c63bdbdb9"",
                    ""path"": ""<Keyboard>/capsLock"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""R1-Dropdown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_DodgeGround = m_Gameplay.FindAction("DodgeGround", throwIfNotFound: true);
        m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
        // Gameplay Action
        m_GameplayAction = asset.FindActionMap("Gameplay Action", throwIfNotFound: true);
        m_GameplayAction_Dreieck = m_GameplayAction.FindAction("Dreieck", throwIfNotFound: true);
        m_GameplayAction_Viereck = m_GameplayAction.FindAction("Viereck", throwIfNotFound: true);
        m_GameplayAction_Kreis = m_GameplayAction.FindAction("Kreis", throwIfNotFound: true);
        m_GameplayAction_X = m_GameplayAction.FindAction("X", throwIfNotFound: true);
        m_GameplayAction_LockOn = m_GameplayAction.FindAction("LockOn", throwIfNotFound: true);
        m_GameplayAction_UnLockOn = m_GameplayAction.FindAction("UnLockOn", throwIfNotFound: true);
        // UIOverall
        m_UIOverall = asset.FindActionMap("UIOverall", throwIfNotFound: true);
        m_UIOverall_L1Dropdown = m_UIOverall.FindAction("L1-Dropdown", throwIfNotFound: true);
        m_UIOverall_R1Dropdown = m_UIOverall.FindAction("R1-Dropdown", throwIfNotFound: true);
        m_UIOverall_Pause = m_UIOverall.FindAction("Pause", throwIfNotFound: true);
        m_UIOverall_Navigate = m_UIOverall.FindAction("Navigate", throwIfNotFound: true);
        m_UIOverall_Submit = m_UIOverall.FindAction("Submit", throwIfNotFound: true);
        m_UIOverall_BackCancel = m_UIOverall.FindAction("Back/Cancel", throwIfNotFound: true);
        m_UIOverall_DPad = m_UIOverall.FindAction("DPad", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_DodgeGround;
    private readonly InputAction m_Gameplay_Sprint;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @DodgeGround => m_Wrapper.m_Gameplay_DodgeGround;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @DodgeGround.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodgeGround;
                @DodgeGround.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodgeGround;
                @DodgeGround.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodgeGround;
                @Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @DodgeGround.started += instance.OnDodgeGround;
                @DodgeGround.performed += instance.OnDodgeGround;
                @DodgeGround.canceled += instance.OnDodgeGround;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Gameplay Action
    private readonly InputActionMap m_GameplayAction;
    private IGameplayActionActions m_GameplayActionActionsCallbackInterface;
    private readonly InputAction m_GameplayAction_Dreieck;
    private readonly InputAction m_GameplayAction_Viereck;
    private readonly InputAction m_GameplayAction_Kreis;
    private readonly InputAction m_GameplayAction_X;
    private readonly InputAction m_GameplayAction_LockOn;
    private readonly InputAction m_GameplayAction_UnLockOn;
    public struct GameplayActionActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dreieck => m_Wrapper.m_GameplayAction_Dreieck;
        public InputAction @Viereck => m_Wrapper.m_GameplayAction_Viereck;
        public InputAction @Kreis => m_Wrapper.m_GameplayAction_Kreis;
        public InputAction @X => m_Wrapper.m_GameplayAction_X;
        public InputAction @LockOn => m_Wrapper.m_GameplayAction_LockOn;
        public InputAction @UnLockOn => m_Wrapper.m_GameplayAction_UnLockOn;
        public InputActionMap Get() { return m_Wrapper.m_GameplayAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActionActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActionActions instance)
        {
            if (m_Wrapper.m_GameplayActionActionsCallbackInterface != null)
            {
                @Dreieck.started -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnDreieck;
                @Dreieck.performed -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnDreieck;
                @Dreieck.canceled -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnDreieck;
                @Viereck.started -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnViereck;
                @Viereck.performed -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnViereck;
                @Viereck.canceled -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnViereck;
                @Kreis.started -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnKreis;
                @Kreis.performed -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnKreis;
                @Kreis.canceled -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnKreis;
                @X.started -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnX;
                @LockOn.started -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnLockOn;
                @UnLockOn.started -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnUnLockOn;
                @UnLockOn.performed -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnUnLockOn;
                @UnLockOn.canceled -= m_Wrapper.m_GameplayActionActionsCallbackInterface.OnUnLockOn;
            }
            m_Wrapper.m_GameplayActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Dreieck.started += instance.OnDreieck;
                @Dreieck.performed += instance.OnDreieck;
                @Dreieck.canceled += instance.OnDreieck;
                @Viereck.started += instance.OnViereck;
                @Viereck.performed += instance.OnViereck;
                @Viereck.canceled += instance.OnViereck;
                @Kreis.started += instance.OnKreis;
                @Kreis.performed += instance.OnKreis;
                @Kreis.canceled += instance.OnKreis;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @UnLockOn.started += instance.OnUnLockOn;
                @UnLockOn.performed += instance.OnUnLockOn;
                @UnLockOn.canceled += instance.OnUnLockOn;
            }
        }
    }
    public GameplayActionActions @GameplayAction => new GameplayActionActions(this);

    // UIOverall
    private readonly InputActionMap m_UIOverall;
    private IUIOverallActions m_UIOverallActionsCallbackInterface;
    private readonly InputAction m_UIOverall_L1Dropdown;
    private readonly InputAction m_UIOverall_R1Dropdown;
    private readonly InputAction m_UIOverall_Pause;
    private readonly InputAction m_UIOverall_Navigate;
    private readonly InputAction m_UIOverall_Submit;
    private readonly InputAction m_UIOverall_BackCancel;
    private readonly InputAction m_UIOverall_DPad;
    public struct UIOverallActions
    {
        private @PlayerControls m_Wrapper;
        public UIOverallActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @L1Dropdown => m_Wrapper.m_UIOverall_L1Dropdown;
        public InputAction @R1Dropdown => m_Wrapper.m_UIOverall_R1Dropdown;
        public InputAction @Pause => m_Wrapper.m_UIOverall_Pause;
        public InputAction @Navigate => m_Wrapper.m_UIOverall_Navigate;
        public InputAction @Submit => m_Wrapper.m_UIOverall_Submit;
        public InputAction @BackCancel => m_Wrapper.m_UIOverall_BackCancel;
        public InputAction @DPad => m_Wrapper.m_UIOverall_DPad;
        public InputActionMap Get() { return m_Wrapper.m_UIOverall; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIOverallActions set) { return set.Get(); }
        public void SetCallbacks(IUIOverallActions instance)
        {
            if (m_Wrapper.m_UIOverallActionsCallbackInterface != null)
            {
                @L1Dropdown.started -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnL1Dropdown;
                @L1Dropdown.performed -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnL1Dropdown;
                @L1Dropdown.canceled -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnL1Dropdown;
                @R1Dropdown.started -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnR1Dropdown;
                @R1Dropdown.performed -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnR1Dropdown;
                @R1Dropdown.canceled -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnR1Dropdown;
                @Pause.started -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnPause;
                @Navigate.started -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnSubmit;
                @BackCancel.started -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnBackCancel;
                @BackCancel.performed -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnBackCancel;
                @BackCancel.canceled -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnBackCancel;
                @DPad.started -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnDPad;
                @DPad.performed -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnDPad;
                @DPad.canceled -= m_Wrapper.m_UIOverallActionsCallbackInterface.OnDPad;
            }
            m_Wrapper.m_UIOverallActionsCallbackInterface = instance;
            if (instance != null)
            {
                @L1Dropdown.started += instance.OnL1Dropdown;
                @L1Dropdown.performed += instance.OnL1Dropdown;
                @L1Dropdown.canceled += instance.OnL1Dropdown;
                @R1Dropdown.started += instance.OnR1Dropdown;
                @R1Dropdown.performed += instance.OnR1Dropdown;
                @R1Dropdown.canceled += instance.OnR1Dropdown;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @BackCancel.started += instance.OnBackCancel;
                @BackCancel.performed += instance.OnBackCancel;
                @BackCancel.canceled += instance.OnBackCancel;
                @DPad.started += instance.OnDPad;
                @DPad.performed += instance.OnDPad;
                @DPad.canceled += instance.OnDPad;
            }
        }
    }
    public UIOverallActions @UIOverall => new UIOverallActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDodgeGround(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IGameplayActionActions
    {
        void OnDreieck(InputAction.CallbackContext context);
        void OnViereck(InputAction.CallbackContext context);
        void OnKreis(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnUnLockOn(InputAction.CallbackContext context);
    }
    public interface IUIOverallActions
    {
        void OnL1Dropdown(InputAction.CallbackContext context);
        void OnR1Dropdown(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnBackCancel(InputAction.CallbackContext context);
        void OnDPad(InputAction.CallbackContext context);
    }
}
