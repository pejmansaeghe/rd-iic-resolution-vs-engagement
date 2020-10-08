// GENERATED AUTOMATICALLY FROM 'Assets/BrucesDevelopment/UserInput/UserInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UserInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserInput"",
    ""maps"": [
        {
            ""name"": ""UserResponse"",
            ""id"": ""75da0a69-1422-4fc3-8716-19903dd55104"",
            ""actions"": [
                {
                    ""name"": ""HighBeep"",
                    ""type"": ""Button"",
                    ""id"": ""ef2b3781-0e7b-47e0-9ad4-3930a6acb024"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LowBeep"",
                    ""type"": ""Button"",
                    ""id"": ""1b1635f6-4582-491c-b515-a00b39f20a5c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c1b86fe-32de-4936-ad2a-d27bcca7768b"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HighBeep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a66d1aa5-16f6-4e4e-8c35-cc739f2c437d"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HighBeep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa3c3937-826c-4bdd-865e-bd396e5e477c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HighBeep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce7c67da-e5ea-48e2-9108-a642b0181d4e"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LowBeep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e2d25f3-0b89-4a8a-bac7-ba85db726a35"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LowBeep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f8e4216-d6f5-4ff6-99a8-8812b9c2ae13"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LowBeep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ExperimentControls"",
            ""id"": ""04d9e3bf-8285-4000-817b-af28e2686fb8"",
            ""actions"": [
                {
                    ""name"": ""PauseVideo"",
                    ""type"": ""Button"",
                    ""id"": ""b30c1a6e-b0b6-447f-8045-c78952d6239a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RestartVideo"",
                    ""type"": ""Button"",
                    ""id"": ""3b9a7f8b-d9a1-4a45-9218-e3236748a9b3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""465e69a9-ef3c-4bf4-8056-c241b8d6cb07"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShowMouseCursor"",
                    ""type"": ""Value"",
                    ""id"": ""1901ba4b-f960-4bb4-842a-2cf7c728aedd"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0e650f24-a5cd-462f-bdcf-fa08ebbc9435"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseVideo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9abb2c2-4e28-4876-848e-b9be39dba903"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestartVideo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51ada245-6f6e-45a1-a4bb-4765b42fb297"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d648a709-605d-4d00-bdb2-bce6c5ad978b"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowMouseCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""896af06b-b5b4-4221-b326-416c9ccb5245"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowMouseCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UserResponse
        m_UserResponse = asset.FindActionMap("UserResponse", throwIfNotFound: true);
        m_UserResponse_HighBeep = m_UserResponse.FindAction("HighBeep", throwIfNotFound: true);
        m_UserResponse_LowBeep = m_UserResponse.FindAction("LowBeep", throwIfNotFound: true);
        // ExperimentControls
        m_ExperimentControls = asset.FindActionMap("ExperimentControls", throwIfNotFound: true);
        m_ExperimentControls_PauseVideo = m_ExperimentControls.FindAction("PauseVideo", throwIfNotFound: true);
        m_ExperimentControls_RestartVideo = m_ExperimentControls.FindAction("RestartVideo", throwIfNotFound: true);
        m_ExperimentControls_Quit = m_ExperimentControls.FindAction("Quit", throwIfNotFound: true);
        m_ExperimentControls_ShowMouseCursor = m_ExperimentControls.FindAction("ShowMouseCursor", throwIfNotFound: true);
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

    // UserResponse
    private readonly InputActionMap m_UserResponse;
    private IUserResponseActions m_UserResponseActionsCallbackInterface;
    private readonly InputAction m_UserResponse_HighBeep;
    private readonly InputAction m_UserResponse_LowBeep;
    public struct UserResponseActions
    {
        private @UserInput m_Wrapper;
        public UserResponseActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @HighBeep => m_Wrapper.m_UserResponse_HighBeep;
        public InputAction @LowBeep => m_Wrapper.m_UserResponse_LowBeep;
        public InputActionMap Get() { return m_Wrapper.m_UserResponse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UserResponseActions set) { return set.Get(); }
        public void SetCallbacks(IUserResponseActions instance)
        {
            if (m_Wrapper.m_UserResponseActionsCallbackInterface != null)
            {
                @HighBeep.started -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnHighBeep;
                @HighBeep.performed -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnHighBeep;
                @HighBeep.canceled -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnHighBeep;
                @LowBeep.started -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnLowBeep;
                @LowBeep.performed -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnLowBeep;
                @LowBeep.canceled -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnLowBeep;
            }
            m_Wrapper.m_UserResponseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HighBeep.started += instance.OnHighBeep;
                @HighBeep.performed += instance.OnHighBeep;
                @HighBeep.canceled += instance.OnHighBeep;
                @LowBeep.started += instance.OnLowBeep;
                @LowBeep.performed += instance.OnLowBeep;
                @LowBeep.canceled += instance.OnLowBeep;
            }
        }
    }
    public UserResponseActions @UserResponse => new UserResponseActions(this);

    // ExperimentControls
    private readonly InputActionMap m_ExperimentControls;
    private IExperimentControlsActions m_ExperimentControlsActionsCallbackInterface;
    private readonly InputAction m_ExperimentControls_PauseVideo;
    private readonly InputAction m_ExperimentControls_RestartVideo;
    private readonly InputAction m_ExperimentControls_Quit;
    private readonly InputAction m_ExperimentControls_ShowMouseCursor;
    public struct ExperimentControlsActions
    {
        private @UserInput m_Wrapper;
        public ExperimentControlsActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseVideo => m_Wrapper.m_ExperimentControls_PauseVideo;
        public InputAction @RestartVideo => m_Wrapper.m_ExperimentControls_RestartVideo;
        public InputAction @Quit => m_Wrapper.m_ExperimentControls_Quit;
        public InputAction @ShowMouseCursor => m_Wrapper.m_ExperimentControls_ShowMouseCursor;
        public InputActionMap Get() { return m_Wrapper.m_ExperimentControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ExperimentControlsActions set) { return set.Get(); }
        public void SetCallbacks(IExperimentControlsActions instance)
        {
            if (m_Wrapper.m_ExperimentControlsActionsCallbackInterface != null)
            {
                @PauseVideo.started -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnPauseVideo;
                @PauseVideo.performed -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnPauseVideo;
                @PauseVideo.canceled -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnPauseVideo;
                @RestartVideo.started -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnRestartVideo;
                @RestartVideo.performed -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnRestartVideo;
                @RestartVideo.canceled -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnRestartVideo;
                @Quit.started -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnQuit;
                @ShowMouseCursor.started -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnShowMouseCursor;
                @ShowMouseCursor.performed -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnShowMouseCursor;
                @ShowMouseCursor.canceled -= m_Wrapper.m_ExperimentControlsActionsCallbackInterface.OnShowMouseCursor;
            }
            m_Wrapper.m_ExperimentControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseVideo.started += instance.OnPauseVideo;
                @PauseVideo.performed += instance.OnPauseVideo;
                @PauseVideo.canceled += instance.OnPauseVideo;
                @RestartVideo.started += instance.OnRestartVideo;
                @RestartVideo.performed += instance.OnRestartVideo;
                @RestartVideo.canceled += instance.OnRestartVideo;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @ShowMouseCursor.started += instance.OnShowMouseCursor;
                @ShowMouseCursor.performed += instance.OnShowMouseCursor;
                @ShowMouseCursor.canceled += instance.OnShowMouseCursor;
            }
        }
    }
    public ExperimentControlsActions @ExperimentControls => new ExperimentControlsActions(this);
    public interface IUserResponseActions
    {
        void OnHighBeep(InputAction.CallbackContext context);
        void OnLowBeep(InputAction.CallbackContext context);
    }
    public interface IExperimentControlsActions
    {
        void OnPauseVideo(InputAction.CallbackContext context);
        void OnRestartVideo(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnShowMouseCursor(InputAction.CallbackContext context);
    }
}
