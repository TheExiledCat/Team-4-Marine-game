//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input Mappers/Pilot.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Pilot : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Pilot()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Pilot"",
    ""maps"": [
        {
            ""name"": ""Center"",
            ""id"": ""522bbbee-0a19-456e-8380-93d05d5a3480"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""Manual"",
            ""id"": ""ceef3b21-ae67-4999-853f-dbfc8369997b"",
            ""actions"": [
                {
                    ""name"": ""SwapPage"",
                    ""type"": ""Value"",
                    ""id"": ""9aa01093-b879-407d-8951-0d4be3dbde63"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Bookmark"",
                    ""type"": ""Value"",
                    ""id"": ""ab8db3bc-1671-4454-b858-8babe00c5192"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MonitorScroll"",
                    ""type"": ""Value"",
                    ""id"": ""d2de391e-d4ff-42e2-beb7-0b017add309d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Direction"",
                    ""id"": ""f487f00b-2313-430a-ab9d-c7fed3a17e72"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bookmark"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9772a39f-4e27-4351-aa95-59761305a64a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bookmark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1082569f-792d-42d0-9dc4-b0c4af8978ce"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bookmark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ea5ca1f7-ff1c-45e8-bc0a-62080ef2505a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bookmark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b2dcc638-5ece-4d4e-85ac-89b255c0e615"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bookmark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""7e820f15-2652-4720-996f-a673a3d03527"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapPage"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""12f2e60a-8bef-494b-86f3-7604050b6bc4"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1cb8090d-be44-4084-982e-35e5e9209ee2"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""de5339ec-a929-4d2d-b610-f53ec1f53947"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MonitorScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Cockpit"",
            ""id"": ""ad7c2db4-f878-45c6-a2d0-6a0b24d17699"",
            ""actions"": [
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""Value"",
                    ""id"": ""b9faac5f-fb54-4d92-bb7a-23593badfda5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ToManualScreen"",
                    ""type"": ""Button"",
                    ""id"": ""0b26c865-150c-48fd-8d7a-5ae12e979854"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToCockpitScreen"",
                    ""type"": ""Button"",
                    ""id"": ""98cf18c8-b71c-46d0-8638-4eedb8cb0d6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootingMovement"",
                    ""type"": ""Value"",
                    ""id"": ""5fd54bd4-a18c-4572-8df4-e41921bbf852"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""c5209b36-101d-4da3-b5d6-2696cda74765"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5d31f5c9-6eee-4551-9e35-18998626eb98"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e53c4d37-b710-4133-8090-fc147a1a97f5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToCockpitScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""442ee1b9-902e-440f-a504-70eb64c60a42"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToManualScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""468774ad-ee17-4a79-b8d3-0b5b7f00bbe1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootingMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2eac39b-8676-4bb4-b1ec-4d534f529b3e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Center
        m_Center = asset.FindActionMap("Center", throwIfNotFound: true);
        // Manual
        m_Manual = asset.FindActionMap("Manual", throwIfNotFound: true);
        m_Manual_SwapPage = m_Manual.FindAction("SwapPage", throwIfNotFound: true);
        m_Manual_Bookmark = m_Manual.FindAction("Bookmark", throwIfNotFound: true);
        m_Manual_MonitorScroll = m_Manual.FindAction("MonitorScroll", throwIfNotFound: true);
        // Cockpit
        m_Cockpit = asset.FindActionMap("Cockpit", throwIfNotFound: true);
        m_Cockpit_MoveCamera = m_Cockpit.FindAction("MoveCamera", throwIfNotFound: true);
        m_Cockpit_ToManualScreen = m_Cockpit.FindAction("ToManualScreen", throwIfNotFound: true);
        m_Cockpit_ToCockpitScreen = m_Cockpit.FindAction("ToCockpitScreen", throwIfNotFound: true);
        m_Cockpit_ShootingMovement = m_Cockpit.FindAction("ShootingMovement", throwIfNotFound: true);
        m_Cockpit_Shooting = m_Cockpit.FindAction("Shooting", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Center
    private readonly InputActionMap m_Center;
    private ICenterActions m_CenterActionsCallbackInterface;
    public struct CenterActions
    {
        private @Pilot m_Wrapper;
        public CenterActions(@Pilot wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Center; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CenterActions set) { return set.Get(); }
        public void SetCallbacks(ICenterActions instance)
        {
            if (m_Wrapper.m_CenterActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_CenterActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public CenterActions @Center => new CenterActions(this);

    // Manual
    private readonly InputActionMap m_Manual;
    private IManualActions m_ManualActionsCallbackInterface;
    private readonly InputAction m_Manual_SwapPage;
    private readonly InputAction m_Manual_Bookmark;
    private readonly InputAction m_Manual_MonitorScroll;
    public struct ManualActions
    {
        private @Pilot m_Wrapper;
        public ManualActions(@Pilot wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwapPage => m_Wrapper.m_Manual_SwapPage;
        public InputAction @Bookmark => m_Wrapper.m_Manual_Bookmark;
        public InputAction @MonitorScroll => m_Wrapper.m_Manual_MonitorScroll;
        public InputActionMap Get() { return m_Wrapper.m_Manual; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ManualActions set) { return set.Get(); }
        public void SetCallbacks(IManualActions instance)
        {
            if (m_Wrapper.m_ManualActionsCallbackInterface != null)
            {
                @SwapPage.started -= m_Wrapper.m_ManualActionsCallbackInterface.OnSwapPage;
                @SwapPage.performed -= m_Wrapper.m_ManualActionsCallbackInterface.OnSwapPage;
                @SwapPage.canceled -= m_Wrapper.m_ManualActionsCallbackInterface.OnSwapPage;
                @Bookmark.started -= m_Wrapper.m_ManualActionsCallbackInterface.OnBookmark;
                @Bookmark.performed -= m_Wrapper.m_ManualActionsCallbackInterface.OnBookmark;
                @Bookmark.canceled -= m_Wrapper.m_ManualActionsCallbackInterface.OnBookmark;
                @MonitorScroll.started -= m_Wrapper.m_ManualActionsCallbackInterface.OnMonitorScroll;
                @MonitorScroll.performed -= m_Wrapper.m_ManualActionsCallbackInterface.OnMonitorScroll;
                @MonitorScroll.canceled -= m_Wrapper.m_ManualActionsCallbackInterface.OnMonitorScroll;
            }
            m_Wrapper.m_ManualActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SwapPage.started += instance.OnSwapPage;
                @SwapPage.performed += instance.OnSwapPage;
                @SwapPage.canceled += instance.OnSwapPage;
                @Bookmark.started += instance.OnBookmark;
                @Bookmark.performed += instance.OnBookmark;
                @Bookmark.canceled += instance.OnBookmark;
                @MonitorScroll.started += instance.OnMonitorScroll;
                @MonitorScroll.performed += instance.OnMonitorScroll;
                @MonitorScroll.canceled += instance.OnMonitorScroll;
            }
        }
    }
    public ManualActions @Manual => new ManualActions(this);

    // Cockpit
    private readonly InputActionMap m_Cockpit;
    private ICockpitActions m_CockpitActionsCallbackInterface;
    private readonly InputAction m_Cockpit_MoveCamera;
    private readonly InputAction m_Cockpit_ToManualScreen;
    private readonly InputAction m_Cockpit_ToCockpitScreen;
    private readonly InputAction m_Cockpit_ShootingMovement;
    private readonly InputAction m_Cockpit_Shooting;
    public struct CockpitActions
    {
        private @Pilot m_Wrapper;
        public CockpitActions(@Pilot wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCamera => m_Wrapper.m_Cockpit_MoveCamera;
        public InputAction @ToManualScreen => m_Wrapper.m_Cockpit_ToManualScreen;
        public InputAction @ToCockpitScreen => m_Wrapper.m_Cockpit_ToCockpitScreen;
        public InputAction @ShootingMovement => m_Wrapper.m_Cockpit_ShootingMovement;
        public InputAction @Shooting => m_Wrapper.m_Cockpit_Shooting;
        public InputActionMap Get() { return m_Wrapper.m_Cockpit; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CockpitActions set) { return set.Get(); }
        public void SetCallbacks(ICockpitActions instance)
        {
            if (m_Wrapper.m_CockpitActionsCallbackInterface != null)
            {
                @MoveCamera.started -= m_Wrapper.m_CockpitActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.performed -= m_Wrapper.m_CockpitActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.canceled -= m_Wrapper.m_CockpitActionsCallbackInterface.OnMoveCamera;
                @ToManualScreen.started -= m_Wrapper.m_CockpitActionsCallbackInterface.OnToManualScreen;
                @ToManualScreen.performed -= m_Wrapper.m_CockpitActionsCallbackInterface.OnToManualScreen;
                @ToManualScreen.canceled -= m_Wrapper.m_CockpitActionsCallbackInterface.OnToManualScreen;
                @ToCockpitScreen.started -= m_Wrapper.m_CockpitActionsCallbackInterface.OnToCockpitScreen;
                @ToCockpitScreen.performed -= m_Wrapper.m_CockpitActionsCallbackInterface.OnToCockpitScreen;
                @ToCockpitScreen.canceled -= m_Wrapper.m_CockpitActionsCallbackInterface.OnToCockpitScreen;
                @ShootingMovement.started -= m_Wrapper.m_CockpitActionsCallbackInterface.OnShootingMovement;
                @ShootingMovement.performed -= m_Wrapper.m_CockpitActionsCallbackInterface.OnShootingMovement;
                @ShootingMovement.canceled -= m_Wrapper.m_CockpitActionsCallbackInterface.OnShootingMovement;
                @Shooting.started -= m_Wrapper.m_CockpitActionsCallbackInterface.OnShooting;
                @Shooting.performed -= m_Wrapper.m_CockpitActionsCallbackInterface.OnShooting;
                @Shooting.canceled -= m_Wrapper.m_CockpitActionsCallbackInterface.OnShooting;
            }
            m_Wrapper.m_CockpitActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
                @ToManualScreen.started += instance.OnToManualScreen;
                @ToManualScreen.performed += instance.OnToManualScreen;
                @ToManualScreen.canceled += instance.OnToManualScreen;
                @ToCockpitScreen.started += instance.OnToCockpitScreen;
                @ToCockpitScreen.performed += instance.OnToCockpitScreen;
                @ToCockpitScreen.canceled += instance.OnToCockpitScreen;
                @ShootingMovement.started += instance.OnShootingMovement;
                @ShootingMovement.performed += instance.OnShootingMovement;
                @ShootingMovement.canceled += instance.OnShootingMovement;
                @Shooting.started += instance.OnShooting;
                @Shooting.performed += instance.OnShooting;
                @Shooting.canceled += instance.OnShooting;
            }
        }
    }
    public CockpitActions @Cockpit => new CockpitActions(this);
    public interface ICenterActions
    {
    }
    public interface IManualActions
    {
        void OnSwapPage(InputAction.CallbackContext context);
        void OnBookmark(InputAction.CallbackContext context);
        void OnMonitorScroll(InputAction.CallbackContext context);
    }
    public interface ICockpitActions
    {
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnToManualScreen(InputAction.CallbackContext context);
        void OnToCockpitScreen(InputAction.CallbackContext context);
        void OnShootingMovement(InputAction.CallbackContext context);
        void OnShooting(InputAction.CallbackContext context);
    }
}
