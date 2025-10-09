// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""881a96a5-45a2-44cd-a4c6-1f966bd08fff"",
            ""actions"": [
                {
                    ""name"": ""AttackHigh"",
                    ""type"": ""Button"",
                    ""id"": ""14fbd290-f2e6-4549-9cf6-413c1000c8db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackLow"",
                    ""type"": ""Button"",
                    ""id"": ""1bead863-b1ed-4444-a39d-6a5a4759b51b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BlockHigh"",
                    ""type"": ""Button"",
                    ""id"": ""013d6533-d198-4120-84a0-650329f012b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BlockLow"",
                    ""type"": ""Button"",
                    ""id"": ""460f8741-0292-44ae-a63b-a783fa9cd7f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""90ccb07b-61ad-4ef3-b95d-efa4279126e2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ee7018ba-0281-45bf-8d5e-9c56c9295f39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c5478786-57b0-4f86-8c4f-23ade6b78445"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackHigh"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d4aa98dd-b5b2-4de9-8fb4-76b8cf333df4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4d4b27a7-0172-4051-90d8-44f7c5ecef9d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a6c5897d-94d0-44e1-8776-910503ac595c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""8da009b1-9c83-479b-89c5-43da5e9d36e5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""943f626e-9fea-42ad-b1a5-9606b545ad5f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""30a869e9-255f-42b6-b610-bca94874f2f3"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ce5244bc-aec5-405d-b449-7f8e0cb5dcc2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackLow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b33b7d8-8bec-4933-b628-e4726fbf2382"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BlockHigh"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e9f0d14-f1e0-4a6e-a955-664c95ffdc8e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BlockLow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c657665-071e-41eb-95b1-e305e751a460"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_AttackHigh = m_Player.FindAction("AttackHigh", throwIfNotFound: true);
        m_Player_AttackLow = m_Player.FindAction("AttackLow", throwIfNotFound: true);
        m_Player_BlockHigh = m_Player.FindAction("BlockHigh", throwIfNotFound: true);
        m_Player_BlockLow = m_Player.FindAction("BlockLow", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_AttackHigh;
    private readonly InputAction m_Player_AttackLow;
    private readonly InputAction m_Player_BlockHigh;
    private readonly InputAction m_Player_BlockLow;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @AttackHigh => m_Wrapper.m_Player_AttackHigh;
        public InputAction @AttackLow => m_Wrapper.m_Player_AttackLow;
        public InputAction @BlockHigh => m_Wrapper.m_Player_BlockHigh;
        public InputAction @BlockLow => m_Wrapper.m_Player_BlockLow;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @AttackHigh.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackHigh;
                @AttackHigh.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackHigh;
                @AttackHigh.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackHigh;
                @AttackLow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLow;
                @AttackLow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLow;
                @AttackLow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLow;
                @BlockHigh.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlockHigh;
                @BlockHigh.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlockHigh;
                @BlockHigh.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlockHigh;
                @BlockLow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlockLow;
                @BlockLow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlockLow;
                @BlockLow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlockLow;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AttackHigh.started += instance.OnAttackHigh;
                @AttackHigh.performed += instance.OnAttackHigh;
                @AttackHigh.canceled += instance.OnAttackHigh;
                @AttackLow.started += instance.OnAttackLow;
                @AttackLow.performed += instance.OnAttackLow;
                @AttackLow.canceled += instance.OnAttackLow;
                @BlockHigh.started += instance.OnBlockHigh;
                @BlockHigh.performed += instance.OnBlockHigh;
                @BlockHigh.canceled += instance.OnBlockHigh;
                @BlockLow.started += instance.OnBlockLow;
                @BlockLow.performed += instance.OnBlockLow;
                @BlockLow.canceled += instance.OnBlockLow;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnAttackHigh(InputAction.CallbackContext context);
        void OnAttackLow(InputAction.CallbackContext context);
        void OnBlockHigh(InputAction.CallbackContext context);
        void OnBlockLow(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
