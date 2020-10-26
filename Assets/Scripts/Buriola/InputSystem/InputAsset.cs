// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Buriola/InputSystem/InputAsset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Buriola.InputSystem
{
    public class @InputAsset : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputAsset()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputAsset"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""488a0161-2119-415b-838b-c5c3666fb953"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""f9dea557-4be1-495a-be14-186c9f9f5abd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""706e57a4-aaed-436d-9a02-bb3fc2d15c1a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton0"",
                    ""type"": ""Button"",
                    ""id"": ""9b81a81d-2ab9-4f9e-86f2-485d3a176c9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton1"",
                    ""type"": ""Button"",
                    ""id"": ""bcdc263d-33e7-4c27-a188-cbdd9733781f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton2"",
                    ""type"": ""Button"",
                    ""id"": ""6d43cd9b-f8a9-4555-8226-cca223a69ded"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton3"",
                    ""type"": ""Button"",
                    ""id"": ""08c561b9-719f-49ad-bf2a-54f4abd555e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton4"",
                    ""type"": ""Button"",
                    ""id"": ""f412f74f-dac1-45ac-9de2-dca0bf0ff51e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton5"",
                    ""type"": ""Button"",
                    ""id"": ""816c8e54-e90d-415e-ab48-cac9d33c542b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton6"",
                    ""type"": ""Button"",
                    ""id"": ""d82385bd-71b0-45dd-b942-ad711d4e6938"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton7"",
                    ""type"": ""Button"",
                    ""id"": ""6cce4538-52ed-499f-9e5c-93fa6f0009d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton8"",
                    ""type"": ""Button"",
                    ""id"": ""a2485134-f5b9-4171-8ab9-b8bcf7362c85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton9"",
                    ""type"": ""Button"",
                    ""id"": ""62a41e04-ae35-4b9a-bb54-54e803e4d8c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""4f9123c6-fdce-4053-972e-942e435176e4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""5d70b53a-ba2e-4d9e-aa0d-3dab8835615b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dpad"",
                    ""type"": ""Value"",
                    ""id"": ""e14c7f54-3325-43ce-b274-8239def0f5ac"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d5345e2-c75a-4f3f-98fe-8337094def38"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01620284-31ef-4379-b1f4-fbc5361f1c87"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ActionButton0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80b64d22-44fe-49e2-9b55-2070079c8483"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ActionButton0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d9fec7a-0265-4999-9db3-84c6975687ef"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f156d565-5b2d-4c91-a505-061af8ce07ba"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""137b59a3-37f2-4737-a8c2-782d0a141d88"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9baa1fdf-89c2-46e1-bcfd-b45f6978f4de"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fb2eb1d-4cc6-4b7e-af4b-5cdcc4074897"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e442eedc-46e6-4711-93c3-fa285ab9bcfb"",
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
                    ""id"": ""71267e46-0645-45b4-b6cc-657c85416dba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""265b4bee-4606-43b9-94a8-4874010f79f2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c482b6f3-661b-4ec1-92ca-c999421ba673"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""caf95610-9819-49a4-9002-481bf13cf6f1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""796dcc6d-9016-43d2-a3e7-e02c5562968e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca6bf2a4-e7ee-4d2a-b100-54816c462e0d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30c74f8b-ca8a-471c-9aba-4f6e6f52d6b4"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a61e1f5-3bd9-4ef8-bdd8-c32430fc5660"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c0e2f00-0123-4b45-904b-cd3989dabd6c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4396665-6c3e-49b4-b903-f45e78ff655b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff89e792-aae4-4211-bc06-75e68c2f944e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29a38128-3a5b-4b77-bb35-12cb9c46a4f6"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fa688c0-e955-4247-9924-9d0a22f6fe3d"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActionButton9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""0bcdf13b-1e6d-463f-b5ff-2dd913271227"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f46d03c6-d31b-4864-8561-5d8b5b1dc653"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bee7dd30-4789-4c96-ab70-56c78949c05b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""06d3863d-3067-471b-9df6-8c8dfab2384e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d36dd7dc-ece4-463c-aa7f-bcfbbaf09aeb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b99dfe25-5bc4-41e0-89a0-5b7074260e2b"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""95b36cf5-9221-4cb0-8093-4995f7cbb563"",
            ""actions"": [
                {
                    ""name"": ""ConfirmAction"",
                    ""type"": ""Button"",
                    ""id"": ""0d2eed5b-80c8-408d-9a47-5ec2c7d320c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelAction"",
                    ""type"": ""Button"",
                    ""id"": ""507a1b0b-cf74-4603-a99c-c93c9bb50011"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigateAction"",
                    ""type"": ""Value"",
                    ""id"": ""67904220-42e9-4661-98e6-66c427b7a342"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AuxAction0"",
                    ""type"": ""Button"",
                    ""id"": ""3fd6a539-8a20-454e-bbd4-6d1a4f71c7d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AuxAction1"",
                    ""type"": ""Button"",
                    ""id"": ""a5b0b6cc-2f81-432b-b551-3c45f725ee61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""78eca091-649a-44a2-86b0-f6fad592be43"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ConfirmAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a00bfe0a-02f8-4bc2-801d-4f5593725ea0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ConfirmAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a594cc4-6bd8-447b-923f-b01597f8d5d1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""CancelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8732ee5d-7061-4402-9a16-752bc962e524"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CancelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f23f0a4b-0430-439e-8a6c-670304b3b5fe"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AuxAction0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2f518d0-31f3-4069-a533-1ce0a0cd5ea8"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""AuxAction0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b53a5871-9ffe-410a-837f-eb2d8194afa7"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AuxAction1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c77938c-31db-4f44-8c16-dceb6c8f1442"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""AuxAction1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""d0b0cb57-ff75-426a-acd9-5b1ee3a1aecc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ac1ffe76-289f-4e33-a320-3713e1d9d2a7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""NavigateAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cc8fab1e-ce1e-4dca-8b59-38c7449f53e1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""NavigateAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9e3a0bb7-5004-44c7-8cb7-b3ec2f6f2f9d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""NavigateAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1ae662eb-75cf-4090-9791-d4c7104e1e07"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""NavigateAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1fe9810b-8f0b-4d7f-8284-8f35f1726217"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NavigateAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
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
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_Movement = m_Game.FindAction("Movement", throwIfNotFound: true);
            m_Game_Look = m_Game.FindAction("Look", throwIfNotFound: true);
            m_Game_ActionButton0 = m_Game.FindAction("ActionButton0", throwIfNotFound: true);
            m_Game_ActionButton1 = m_Game.FindAction("ActionButton1", throwIfNotFound: true);
            m_Game_ActionButton2 = m_Game.FindAction("ActionButton2", throwIfNotFound: true);
            m_Game_ActionButton3 = m_Game.FindAction("ActionButton3", throwIfNotFound: true);
            m_Game_ActionButton4 = m_Game.FindAction("ActionButton4", throwIfNotFound: true);
            m_Game_ActionButton5 = m_Game.FindAction("ActionButton5", throwIfNotFound: true);
            m_Game_ActionButton6 = m_Game.FindAction("ActionButton6", throwIfNotFound: true);
            m_Game_ActionButton7 = m_Game.FindAction("ActionButton7", throwIfNotFound: true);
            m_Game_ActionButton8 = m_Game.FindAction("ActionButton8", throwIfNotFound: true);
            m_Game_ActionButton9 = m_Game.FindAction("ActionButton9", throwIfNotFound: true);
            m_Game_LeftTrigger = m_Game.FindAction("LeftTrigger", throwIfNotFound: true);
            m_Game_RightTrigger = m_Game.FindAction("RightTrigger", throwIfNotFound: true);
            m_Game_Dpad = m_Game.FindAction("Dpad", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_ConfirmAction = m_UI.FindAction("ConfirmAction", throwIfNotFound: true);
            m_UI_CancelAction = m_UI.FindAction("CancelAction", throwIfNotFound: true);
            m_UI_NavigateAction = m_UI.FindAction("NavigateAction", throwIfNotFound: true);
            m_UI_AuxAction0 = m_UI.FindAction("AuxAction0", throwIfNotFound: true);
            m_UI_AuxAction1 = m_UI.FindAction("AuxAction1", throwIfNotFound: true);
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

        // Game
        private readonly InputActionMap m_Game;
        private IGameActions m_GameActionsCallbackInterface;
        private readonly InputAction m_Game_Movement;
        private readonly InputAction m_Game_Look;
        private readonly InputAction m_Game_ActionButton0;
        private readonly InputAction m_Game_ActionButton1;
        private readonly InputAction m_Game_ActionButton2;
        private readonly InputAction m_Game_ActionButton3;
        private readonly InputAction m_Game_ActionButton4;
        private readonly InputAction m_Game_ActionButton5;
        private readonly InputAction m_Game_ActionButton6;
        private readonly InputAction m_Game_ActionButton7;
        private readonly InputAction m_Game_ActionButton8;
        private readonly InputAction m_Game_ActionButton9;
        private readonly InputAction m_Game_LeftTrigger;
        private readonly InputAction m_Game_RightTrigger;
        private readonly InputAction m_Game_Dpad;
        public struct GameActions
        {
            private @InputAsset m_Wrapper;
            public GameActions(@InputAsset wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Game_Movement;
            public InputAction @Look => m_Wrapper.m_Game_Look;
            public InputAction @ActionButton0 => m_Wrapper.m_Game_ActionButton0;
            public InputAction @ActionButton1 => m_Wrapper.m_Game_ActionButton1;
            public InputAction @ActionButton2 => m_Wrapper.m_Game_ActionButton2;
            public InputAction @ActionButton3 => m_Wrapper.m_Game_ActionButton3;
            public InputAction @ActionButton4 => m_Wrapper.m_Game_ActionButton4;
            public InputAction @ActionButton5 => m_Wrapper.m_Game_ActionButton5;
            public InputAction @ActionButton6 => m_Wrapper.m_Game_ActionButton6;
            public InputAction @ActionButton7 => m_Wrapper.m_Game_ActionButton7;
            public InputAction @ActionButton8 => m_Wrapper.m_Game_ActionButton8;
            public InputAction @ActionButton9 => m_Wrapper.m_Game_ActionButton9;
            public InputAction @LeftTrigger => m_Wrapper.m_Game_LeftTrigger;
            public InputAction @RightTrigger => m_Wrapper.m_Game_RightTrigger;
            public InputAction @Dpad => m_Wrapper.m_Game_Dpad;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Look.started -= m_Wrapper.m_GameActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnLook;
                    @ActionButton0.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton0;
                    @ActionButton0.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton0;
                    @ActionButton0.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton0;
                    @ActionButton1.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton1;
                    @ActionButton1.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton1;
                    @ActionButton1.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton1;
                    @ActionButton2.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton2;
                    @ActionButton2.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton2;
                    @ActionButton2.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton2;
                    @ActionButton3.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton3;
                    @ActionButton3.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton3;
                    @ActionButton3.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton3;
                    @ActionButton4.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton4;
                    @ActionButton4.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton4;
                    @ActionButton4.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton4;
                    @ActionButton5.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton5;
                    @ActionButton5.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton5;
                    @ActionButton5.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton5;
                    @ActionButton6.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton6;
                    @ActionButton6.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton6;
                    @ActionButton6.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton6;
                    @ActionButton7.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton7;
                    @ActionButton7.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton7;
                    @ActionButton7.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton7;
                    @ActionButton8.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton8;
                    @ActionButton8.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton8;
                    @ActionButton8.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton8;
                    @ActionButton9.started -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton9;
                    @ActionButton9.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton9;
                    @ActionButton9.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnActionButton9;
                    @LeftTrigger.started -= m_Wrapper.m_GameActionsCallbackInterface.OnLeftTrigger;
                    @LeftTrigger.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnLeftTrigger;
                    @LeftTrigger.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnLeftTrigger;
                    @RightTrigger.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRightTrigger;
                    @RightTrigger.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRightTrigger;
                    @RightTrigger.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRightTrigger;
                    @Dpad.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDpad;
                    @Dpad.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDpad;
                    @Dpad.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDpad;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @ActionButton0.started += instance.OnActionButton0;
                    @ActionButton0.performed += instance.OnActionButton0;
                    @ActionButton0.canceled += instance.OnActionButton0;
                    @ActionButton1.started += instance.OnActionButton1;
                    @ActionButton1.performed += instance.OnActionButton1;
                    @ActionButton1.canceled += instance.OnActionButton1;
                    @ActionButton2.started += instance.OnActionButton2;
                    @ActionButton2.performed += instance.OnActionButton2;
                    @ActionButton2.canceled += instance.OnActionButton2;
                    @ActionButton3.started += instance.OnActionButton3;
                    @ActionButton3.performed += instance.OnActionButton3;
                    @ActionButton3.canceled += instance.OnActionButton3;
                    @ActionButton4.started += instance.OnActionButton4;
                    @ActionButton4.performed += instance.OnActionButton4;
                    @ActionButton4.canceled += instance.OnActionButton4;
                    @ActionButton5.started += instance.OnActionButton5;
                    @ActionButton5.performed += instance.OnActionButton5;
                    @ActionButton5.canceled += instance.OnActionButton5;
                    @ActionButton6.started += instance.OnActionButton6;
                    @ActionButton6.performed += instance.OnActionButton6;
                    @ActionButton6.canceled += instance.OnActionButton6;
                    @ActionButton7.started += instance.OnActionButton7;
                    @ActionButton7.performed += instance.OnActionButton7;
                    @ActionButton7.canceled += instance.OnActionButton7;
                    @ActionButton8.started += instance.OnActionButton8;
                    @ActionButton8.performed += instance.OnActionButton8;
                    @ActionButton8.canceled += instance.OnActionButton8;
                    @ActionButton9.started += instance.OnActionButton9;
                    @ActionButton9.performed += instance.OnActionButton9;
                    @ActionButton9.canceled += instance.OnActionButton9;
                    @LeftTrigger.started += instance.OnLeftTrigger;
                    @LeftTrigger.performed += instance.OnLeftTrigger;
                    @LeftTrigger.canceled += instance.OnLeftTrigger;
                    @RightTrigger.started += instance.OnRightTrigger;
                    @RightTrigger.performed += instance.OnRightTrigger;
                    @RightTrigger.canceled += instance.OnRightTrigger;
                    @Dpad.started += instance.OnDpad;
                    @Dpad.performed += instance.OnDpad;
                    @Dpad.canceled += instance.OnDpad;
                }
            }
        }
        public GameActions @Game => new GameActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_ConfirmAction;
        private readonly InputAction m_UI_CancelAction;
        private readonly InputAction m_UI_NavigateAction;
        private readonly InputAction m_UI_AuxAction0;
        private readonly InputAction m_UI_AuxAction1;
        public struct UIActions
        {
            private @InputAsset m_Wrapper;
            public UIActions(@InputAsset wrapper) { m_Wrapper = wrapper; }
            public InputAction @ConfirmAction => m_Wrapper.m_UI_ConfirmAction;
            public InputAction @CancelAction => m_Wrapper.m_UI_CancelAction;
            public InputAction @NavigateAction => m_Wrapper.m_UI_NavigateAction;
            public InputAction @AuxAction0 => m_Wrapper.m_UI_AuxAction0;
            public InputAction @AuxAction1 => m_Wrapper.m_UI_AuxAction1;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @ConfirmAction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmAction;
                    @ConfirmAction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmAction;
                    @ConfirmAction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmAction;
                    @CancelAction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancelAction;
                    @CancelAction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancelAction;
                    @CancelAction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancelAction;
                    @NavigateAction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateAction;
                    @NavigateAction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateAction;
                    @NavigateAction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateAction;
                    @AuxAction0.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAuxAction0;
                    @AuxAction0.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAuxAction0;
                    @AuxAction0.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAuxAction0;
                    @AuxAction1.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAuxAction1;
                    @AuxAction1.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAuxAction1;
                    @AuxAction1.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAuxAction1;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ConfirmAction.started += instance.OnConfirmAction;
                    @ConfirmAction.performed += instance.OnConfirmAction;
                    @ConfirmAction.canceled += instance.OnConfirmAction;
                    @CancelAction.started += instance.OnCancelAction;
                    @CancelAction.performed += instance.OnCancelAction;
                    @CancelAction.canceled += instance.OnCancelAction;
                    @NavigateAction.started += instance.OnNavigateAction;
                    @NavigateAction.performed += instance.OnNavigateAction;
                    @NavigateAction.canceled += instance.OnNavigateAction;
                    @AuxAction0.started += instance.OnAuxAction0;
                    @AuxAction0.performed += instance.OnAuxAction0;
                    @AuxAction0.canceled += instance.OnAuxAction0;
                    @AuxAction1.started += instance.OnAuxAction1;
                    @AuxAction1.performed += instance.OnAuxAction1;
                    @AuxAction1.canceled += instance.OnAuxAction1;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
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
        public interface IGameActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnActionButton0(InputAction.CallbackContext context);
            void OnActionButton1(InputAction.CallbackContext context);
            void OnActionButton2(InputAction.CallbackContext context);
            void OnActionButton3(InputAction.CallbackContext context);
            void OnActionButton4(InputAction.CallbackContext context);
            void OnActionButton5(InputAction.CallbackContext context);
            void OnActionButton6(InputAction.CallbackContext context);
            void OnActionButton7(InputAction.CallbackContext context);
            void OnActionButton8(InputAction.CallbackContext context);
            void OnActionButton9(InputAction.CallbackContext context);
            void OnLeftTrigger(InputAction.CallbackContext context);
            void OnRightTrigger(InputAction.CallbackContext context);
            void OnDpad(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnConfirmAction(InputAction.CallbackContext context);
            void OnCancelAction(InputAction.CallbackContext context);
            void OnNavigateAction(InputAction.CallbackContext context);
            void OnAuxAction0(InputAction.CallbackContext context);
            void OnAuxAction1(InputAction.CallbackContext context);
        }
    }
}
