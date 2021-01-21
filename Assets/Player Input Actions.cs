// GENERATED AUTOMATICALLY FROM 'Assets/Player Input Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input Actions"",
    ""maps"": [
        {
            ""name"": ""Main Action Map"",
            ""id"": ""f58d8430-2ad3-454b-945a-92a6c252147e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3922d41a-b23d-4910-a13d-3be8d9a0ca14"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""6ca8ec1c-0d2d-466a-a3eb-6a5db7618536"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugNum1"",
                    ""type"": ""Button"",
                    ""id"": ""6d513710-cdb0-42e1-9cb2-a9e96a6ace13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugNum2"",
                    ""type"": ""Button"",
                    ""id"": ""8c841030-fa64-4622-be75-85e18b212482"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugNum4"",
                    ""type"": ""Button"",
                    ""id"": ""dee6d50d-ef78-4157-8dd5-1df79d4ecb59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugNum5"",
                    ""type"": ""Button"",
                    ""id"": ""78ab837c-2e41-43e4-8267-e39922b979bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""891a7816-106b-4fbf-b252-46e28afc9330"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e0635643-6c3d-4c78-a7a8-80689ecdc409"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""59a1fbaf-0326-4e67-b6c1-2a37d5907b4e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a37c839b-1da6-4189-ac41-c06498dd96af"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cccb1cc6-ab7b-4ed1-aae8-a299210f0dc9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""158c8528-2106-4120-923a-eb16f557667d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b10fb2c9-bbf7-44c8-98f5-c6721ce10a7c"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45c031b9-6115-4f4d-852a-77b2eac85e1b"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugNum1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d840fd7b-d797-4aad-a392-3b81e147c273"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugNum2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""157c3d1a-2694-41a9-8449-97452eb4e10a"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugNum4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d7f90b1-2063-4eee-8db3-e758bf84d709"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugNum5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Default"",
            ""bindingGroup"": ""Default"",
            ""devices"": []
        }
    ]
}");
        // Main Action Map
        m_MainActionMap = asset.FindActionMap("Main Action Map", throwIfNotFound: true);
        m_MainActionMap_Move = m_MainActionMap.FindAction("Move", throwIfNotFound: true);
        m_MainActionMap_Attack = m_MainActionMap.FindAction("Attack", throwIfNotFound: true);
        m_MainActionMap_DebugNum1 = m_MainActionMap.FindAction("DebugNum1", throwIfNotFound: true);
        m_MainActionMap_DebugNum2 = m_MainActionMap.FindAction("DebugNum2", throwIfNotFound: true);
        m_MainActionMap_DebugNum4 = m_MainActionMap.FindAction("DebugNum4", throwIfNotFound: true);
        m_MainActionMap_DebugNum5 = m_MainActionMap.FindAction("DebugNum5", throwIfNotFound: true);
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

    // Main Action Map
    private readonly InputActionMap m_MainActionMap;
    private IMainActionMapActions m_MainActionMapActionsCallbackInterface;
    private readonly InputAction m_MainActionMap_Move;
    private readonly InputAction m_MainActionMap_Attack;
    private readonly InputAction m_MainActionMap_DebugNum1;
    private readonly InputAction m_MainActionMap_DebugNum2;
    private readonly InputAction m_MainActionMap_DebugNum4;
    private readonly InputAction m_MainActionMap_DebugNum5;
    public struct MainActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public MainActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MainActionMap_Move;
        public InputAction @Attack => m_Wrapper.m_MainActionMap_Attack;
        public InputAction @DebugNum1 => m_Wrapper.m_MainActionMap_DebugNum1;
        public InputAction @DebugNum2 => m_Wrapper.m_MainActionMap_DebugNum2;
        public InputAction @DebugNum4 => m_Wrapper.m_MainActionMap_DebugNum4;
        public InputAction @DebugNum5 => m_Wrapper.m_MainActionMap_DebugNum5;
        public InputActionMap Get() { return m_Wrapper.m_MainActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IMainActionMapActions instance)
        {
            if (m_Wrapper.m_MainActionMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnAttack;
                @DebugNum1.started -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum1;
                @DebugNum1.performed -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum1;
                @DebugNum1.canceled -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum1;
                @DebugNum2.started -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum2;
                @DebugNum2.performed -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum2;
                @DebugNum2.canceled -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum2;
                @DebugNum4.started -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum4;
                @DebugNum4.performed -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum4;
                @DebugNum4.canceled -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum4;
                @DebugNum5.started -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum5;
                @DebugNum5.performed -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum5;
                @DebugNum5.canceled -= m_Wrapper.m_MainActionMapActionsCallbackInterface.OnDebugNum5;
            }
            m_Wrapper.m_MainActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @DebugNum1.started += instance.OnDebugNum1;
                @DebugNum1.performed += instance.OnDebugNum1;
                @DebugNum1.canceled += instance.OnDebugNum1;
                @DebugNum2.started += instance.OnDebugNum2;
                @DebugNum2.performed += instance.OnDebugNum2;
                @DebugNum2.canceled += instance.OnDebugNum2;
                @DebugNum4.started += instance.OnDebugNum4;
                @DebugNum4.performed += instance.OnDebugNum4;
                @DebugNum4.canceled += instance.OnDebugNum4;
                @DebugNum5.started += instance.OnDebugNum5;
                @DebugNum5.performed += instance.OnDebugNum5;
                @DebugNum5.canceled += instance.OnDebugNum5;
            }
        }
    }
    public MainActionMapActions @MainActionMap => new MainActionMapActions(this);
    private int m_DefaultSchemeIndex = -1;
    public InputControlScheme DefaultScheme
    {
        get
        {
            if (m_DefaultSchemeIndex == -1) m_DefaultSchemeIndex = asset.FindControlSchemeIndex("Default");
            return asset.controlSchemes[m_DefaultSchemeIndex];
        }
    }
    public interface IMainActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDebugNum1(InputAction.CallbackContext context);
        void OnDebugNum2(InputAction.CallbackContext context);
        void OnDebugNum4(InputAction.CallbackContext context);
        void OnDebugNum5(InputAction.CallbackContext context);
    }
}
