// GENERATED AUTOMATICALLY FROM 'Assets/BrucesDevelopment/UserInput/UserInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class UserInput : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public UserInput()
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
                    ""id"": ""ce7c67da-e5ea-48e2-9108-a642b0181d4e"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LowBeep"",
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
        private UserInput m_Wrapper;
        public UserResponseActions(UserInput wrapper) { m_Wrapper = wrapper; }
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
                HighBeep.started -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnHighBeep;
                HighBeep.performed -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnHighBeep;
                HighBeep.canceled -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnHighBeep;
                LowBeep.started -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnLowBeep;
                LowBeep.performed -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnLowBeep;
                LowBeep.canceled -= m_Wrapper.m_UserResponseActionsCallbackInterface.OnLowBeep;
            }
            m_Wrapper.m_UserResponseActionsCallbackInterface = instance;
            if (instance != null)
            {
                HighBeep.started += instance.OnHighBeep;
                HighBeep.performed += instance.OnHighBeep;
                HighBeep.canceled += instance.OnHighBeep;
                LowBeep.started += instance.OnLowBeep;
                LowBeep.performed += instance.OnLowBeep;
                LowBeep.canceled += instance.OnLowBeep;
            }
        }
    }
    public UserResponseActions @UserResponse => new UserResponseActions(this);
    public interface IUserResponseActions
    {
        void OnHighBeep(InputAction.CallbackContext context);
        void OnLowBeep(InputAction.CallbackContext context);
    }
}
