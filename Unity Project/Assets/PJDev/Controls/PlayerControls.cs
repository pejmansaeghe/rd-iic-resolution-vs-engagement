// GENERATED AUTOMATICALLY FROM 'Assets/PJDev/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""6793d4a1-13c0-4bc6-a181-df24463f384b"",
            ""actions"": [
                {
                    ""name"": ""HighBeep"",
                    ""type"": ""Button"",
                    ""id"": ""40252eeb-5330-451d-96e3-2c61f32adc61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LowBeep"",
                    ""type"": ""Button"",
                    ""id"": ""72589535-bd6a-4d36-aa92-f9a9b1f10a53"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartTutorial"",
                    ""type"": ""Button"",
                    ""id"": ""4ce2d5d8-6d94-4ff4-8ee2-064f5f87d8fc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QuitTutorial"",
                    ""type"": ""Button"",
                    ""id"": ""59ebbfe4-0e4a-4b4e-be10-56e0a9faed1e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AnyKeyPressed"",
                    ""type"": ""Button"",
                    ""id"": ""6781bafa-c169-434a-88cd-22d7ef9dbddc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eeb307d7-5f92-45eb-9c58-dae2556b814a"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""HighBeep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7c94fc8-46a1-4081-a215-afd32effc145"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LowBeep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c66784a9-f682-456a-af92-30d868bbee98"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StartTutorial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f10b1db2-3c3f-45b3-bcbf-0112853ac771"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""QuitTutorial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b5489d9-2a66-4112-8f02-7f403500e395"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AnyKeyPressed"",
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
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_HighBeep = m_Player.FindAction("HighBeep", throwIfNotFound: true);
        m_Player_LowBeep = m_Player.FindAction("LowBeep", throwIfNotFound: true);
        m_Player_StartTutorial = m_Player.FindAction("StartTutorial", throwIfNotFound: true);
        m_Player_QuitTutorial = m_Player.FindAction("QuitTutorial", throwIfNotFound: true);
        m_Player_AnyKeyPressed = m_Player.FindAction("AnyKeyPressed", throwIfNotFound: true);
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
    private readonly InputAction m_Player_HighBeep;
    private readonly InputAction m_Player_LowBeep;
    private readonly InputAction m_Player_StartTutorial;
    private readonly InputAction m_Player_QuitTutorial;
    private readonly InputAction m_Player_AnyKeyPressed;
    public struct PlayerActions
    {
        private PlayerControls m_Wrapper;
        public PlayerActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HighBeep => m_Wrapper.m_Player_HighBeep;
        public InputAction @LowBeep => m_Wrapper.m_Player_LowBeep;
        public InputAction @StartTutorial => m_Wrapper.m_Player_StartTutorial;
        public InputAction @QuitTutorial => m_Wrapper.m_Player_QuitTutorial;
        public InputAction @AnyKeyPressed => m_Wrapper.m_Player_AnyKeyPressed;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                HighBeep.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHighBeep;
                HighBeep.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHighBeep;
                HighBeep.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHighBeep;
                LowBeep.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLowBeep;
                LowBeep.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLowBeep;
                LowBeep.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLowBeep;
                StartTutorial.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartTutorial;
                StartTutorial.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartTutorial;
                StartTutorial.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartTutorial;
                QuitTutorial.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuitTutorial;
                QuitTutorial.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuitTutorial;
                QuitTutorial.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuitTutorial;
                AnyKeyPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAnyKeyPressed;
                AnyKeyPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAnyKeyPressed;
                AnyKeyPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAnyKeyPressed;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                HighBeep.started += instance.OnHighBeep;
                HighBeep.performed += instance.OnHighBeep;
                HighBeep.canceled += instance.OnHighBeep;
                LowBeep.started += instance.OnLowBeep;
                LowBeep.performed += instance.OnLowBeep;
                LowBeep.canceled += instance.OnLowBeep;
                StartTutorial.started += instance.OnStartTutorial;
                StartTutorial.performed += instance.OnStartTutorial;
                StartTutorial.canceled += instance.OnStartTutorial;
                QuitTutorial.started += instance.OnQuitTutorial;
                QuitTutorial.performed += instance.OnQuitTutorial;
                QuitTutorial.canceled += instance.OnQuitTutorial;
                AnyKeyPressed.started += instance.OnAnyKeyPressed;
                AnyKeyPressed.performed += instance.OnAnyKeyPressed;
                AnyKeyPressed.canceled += instance.OnAnyKeyPressed;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnHighBeep(InputAction.CallbackContext context);
        void OnLowBeep(InputAction.CallbackContext context);
        void OnStartTutorial(InputAction.CallbackContext context);
        void OnQuitTutorial(InputAction.CallbackContext context);
        void OnAnyKeyPressed(InputAction.CallbackContext context);
    }
}
