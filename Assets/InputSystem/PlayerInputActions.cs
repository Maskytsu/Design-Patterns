//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""f8f7545b-ac2b-4e3d-8bbe-17aa312c7ca4"",
            ""actions"": [
                {
                    ""name"": ""MouseX"",
                    ""type"": ""Value"",
                    ""id"": ""6d444d2b-2ef2-4367-9134-1ab10411ab45"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""Value"",
                    ""id"": ""2568eb20-f46e-462e-8d6f-efe0b269319d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""20bf0bb4-4e14-4940-b7f2-3b8a9b8aed5e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""817f0002-d128-40e8-ab95-30d49192a9a1"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79d47d02-9a7a-449f-96c1-74b199ef2369"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0648d465-fbab-4ec9-8b45-71a58f34a5bd"",
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
                    ""id"": ""04b62cdb-667a-4400-96d9-8c9c0fad89aa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6fbf0a3d-6b81-46a1-aed2-eb9c87aac0bc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""db36a54b-0acf-435e-86d5-c132d2f394a7"",
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
                    ""id"": ""d01781b3-dd8f-49e9-a813-c9e3a8c98500"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UIMouseMap"",
            ""id"": ""f115de56-b06f-4204-bc60-9988e655f94a"",
            ""actions"": [
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a4f046d7-f6a3-4bb8-a46f-22c24b723c70"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""da618c43-6a6a-4ab2-96b7-05a37b71b98c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""129f56ae-951a-4d54-a96d-fb169c3388df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1182cb1a-98d5-41e0-b425-8f7d3202bc34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d2099456-f2ba-42f6-aea3-9f23e22fa399"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""25c3f110-b715-48eb-a977-e14d8247f625"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3953ae23-df25-4f1e-9f4e-2111129b1a4f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc40e0e5-7a84-4d8f-a63e-dceefae9b0e6"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75cb77e6-da9c-40f6-8d85-f40c5c602bbc"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1654b130-bca1-437d-8606-4e2670cd4bf4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
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
            ""devices"": []
        }
    ]
}");
        // PlayerMap
        m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
        m_PlayerMap_MouseX = m_PlayerMap.FindAction("MouseX", throwIfNotFound: true);
        m_PlayerMap_MouseY = m_PlayerMap.FindAction("MouseY", throwIfNotFound: true);
        m_PlayerMap_Movement = m_PlayerMap.FindAction("Movement", throwIfNotFound: true);
        // UIMouseMap
        m_UIMouseMap = asset.FindActionMap("UIMouseMap", throwIfNotFound: true);
        m_UIMouseMap_Point = m_UIMouseMap.FindAction("Point", throwIfNotFound: true);
        m_UIMouseMap_LeftClick = m_UIMouseMap.FindAction("LeftClick", throwIfNotFound: true);
        m_UIMouseMap_ScrollWheel = m_UIMouseMap.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UIMouseMap_MiddleClick = m_UIMouseMap.FindAction("MiddleClick", throwIfNotFound: true);
        m_UIMouseMap_RightClick = m_UIMouseMap.FindAction("RightClick", throwIfNotFound: true);
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

    // PlayerMap
    private readonly InputActionMap m_PlayerMap;
    private List<IPlayerMapActions> m_PlayerMapActionsCallbackInterfaces = new List<IPlayerMapActions>();
    private readonly InputAction m_PlayerMap_MouseX;
    private readonly InputAction m_PlayerMap_MouseY;
    private readonly InputAction m_PlayerMap_Movement;
    public struct PlayerMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseX => m_Wrapper.m_PlayerMap_MouseX;
        public InputAction @MouseY => m_Wrapper.m_PlayerMap_MouseY;
        public InputAction @Movement => m_Wrapper.m_PlayerMap_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Add(instance);
            @MouseX.started += instance.OnMouseX;
            @MouseX.performed += instance.OnMouseX;
            @MouseX.canceled += instance.OnMouseX;
            @MouseY.started += instance.OnMouseY;
            @MouseY.performed += instance.OnMouseY;
            @MouseY.canceled += instance.OnMouseY;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(IPlayerMapActions instance)
        {
            @MouseX.started -= instance.OnMouseX;
            @MouseX.performed -= instance.OnMouseX;
            @MouseX.canceled -= instance.OnMouseX;
            @MouseY.started -= instance.OnMouseY;
            @MouseY.performed -= instance.OnMouseY;
            @MouseY.canceled -= instance.OnMouseY;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
        }

        public void RemoveCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMapActions @PlayerMap => new PlayerMapActions(this);

    // UIMouseMap
    private readonly InputActionMap m_UIMouseMap;
    private List<IUIMouseMapActions> m_UIMouseMapActionsCallbackInterfaces = new List<IUIMouseMapActions>();
    private readonly InputAction m_UIMouseMap_Point;
    private readonly InputAction m_UIMouseMap_LeftClick;
    private readonly InputAction m_UIMouseMap_ScrollWheel;
    private readonly InputAction m_UIMouseMap_MiddleClick;
    private readonly InputAction m_UIMouseMap_RightClick;
    public struct UIMouseMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIMouseMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Point => m_Wrapper.m_UIMouseMap_Point;
        public InputAction @LeftClick => m_Wrapper.m_UIMouseMap_LeftClick;
        public InputAction @ScrollWheel => m_Wrapper.m_UIMouseMap_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UIMouseMap_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UIMouseMap_RightClick;
        public InputActionMap Get() { return m_Wrapper.m_UIMouseMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIMouseMapActions set) { return set.Get(); }
        public void AddCallbacks(IUIMouseMapActions instance)
        {
            if (instance == null || m_Wrapper.m_UIMouseMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIMouseMapActionsCallbackInterfaces.Add(instance);
            @Point.started += instance.OnPoint;
            @Point.performed += instance.OnPoint;
            @Point.canceled += instance.OnPoint;
            @LeftClick.started += instance.OnLeftClick;
            @LeftClick.performed += instance.OnLeftClick;
            @LeftClick.canceled += instance.OnLeftClick;
            @ScrollWheel.started += instance.OnScrollWheel;
            @ScrollWheel.performed += instance.OnScrollWheel;
            @ScrollWheel.canceled += instance.OnScrollWheel;
            @MiddleClick.started += instance.OnMiddleClick;
            @MiddleClick.performed += instance.OnMiddleClick;
            @MiddleClick.canceled += instance.OnMiddleClick;
            @RightClick.started += instance.OnRightClick;
            @RightClick.performed += instance.OnRightClick;
            @RightClick.canceled += instance.OnRightClick;
        }

        private void UnregisterCallbacks(IUIMouseMapActions instance)
        {
            @Point.started -= instance.OnPoint;
            @Point.performed -= instance.OnPoint;
            @Point.canceled -= instance.OnPoint;
            @LeftClick.started -= instance.OnLeftClick;
            @LeftClick.performed -= instance.OnLeftClick;
            @LeftClick.canceled -= instance.OnLeftClick;
            @ScrollWheel.started -= instance.OnScrollWheel;
            @ScrollWheel.performed -= instance.OnScrollWheel;
            @ScrollWheel.canceled -= instance.OnScrollWheel;
            @MiddleClick.started -= instance.OnMiddleClick;
            @MiddleClick.performed -= instance.OnMiddleClick;
            @MiddleClick.canceled -= instance.OnMiddleClick;
            @RightClick.started -= instance.OnRightClick;
            @RightClick.performed -= instance.OnRightClick;
            @RightClick.canceled -= instance.OnRightClick;
        }

        public void RemoveCallbacks(IUIMouseMapActions instance)
        {
            if (m_Wrapper.m_UIMouseMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIMouseMapActions instance)
        {
            foreach (var item in m_Wrapper.m_UIMouseMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIMouseMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIMouseMapActions @UIMouseMap => new UIMouseMapActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerMapActions
    {
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IUIMouseMapActions
    {
        void OnPoint(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
    }
}
