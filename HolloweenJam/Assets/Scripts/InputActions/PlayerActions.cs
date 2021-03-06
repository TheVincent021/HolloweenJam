// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""84b26b5a-5f1e-4d7d-a94b-2163c4a2d2ef"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""f9cb6fd9-9a0d-47a4-b0d0-d6305fe136f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""eb382adc-2032-490a-a43f-ecb2ab64a5eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""019bf170-de49-44e7-b1d2-e18d615ecbb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""327275a2-683a-4ce0-8e0d-618049509257"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""3b2c1aac-8474-4dd5-beed-dcd0a5eaf5f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""74168781-cb55-4907-8047-e8cdcc2aecaa"",
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
                    ""id"": ""894c4c79-70ff-4d4d-ae1c-cf3b885afd5c"",
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
                    ""id"": ""ab883977-8a6d-445e-a727-1c9d0d130d56"",
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
                    ""id"": ""e64cd05c-4f62-4c2f-b0bf-a402524632fe"",
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
                    ""id"": ""853d43a8-41be-4afa-9bf0-024a06f438d8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""8a3bfb54-b750-4e5c-b8c6-264ffdf4f525"",
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
                    ""id"": ""4f97692d-95a5-45fe-aec8-06e1ffa12ff1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a76ff74c-b5be-4155-b733-c3af36073ff6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6edfe780-1be4-4883-bc53-a2b5a6df46e8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6a0a5e18-d03b-4667-b14f-9d010e806e45"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bbf900df-be81-4429-a3b0-58abe46d061b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3ba0037-4aaa-4a77-b0ac-3e1adedf28ce"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20fd8bb3-2ef3-49d1-8b48-01281eb5095a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""babed913-8d9a-4343-ae87-0ea4cb839be3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InBetweenMenu"",
            ""id"": ""22decc43-abfd-46f2-b797-d75e94db8e1f"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""f97f994f-dbe7-4d9b-b880-764bd6f5ac84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eceea58e-7e16-407a-95db-dd4e0b776123"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e5f67f4-2311-402a-b55a-ec9e46e553c8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c33ec5dc-67b0-4a28-b9c0-3ad2a7428d94"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22f24da6-a15d-4d37-b07d-ab71a8489145"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameOver"",
            ""id"": ""0ffc8e74-a547-46b1-bb4d-42d8c46d08c0"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""c5ce3350-502f-467e-b748-b3188badeab4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""be81c63b-3c7d-4ef3-a2c3-0631f9b5d54c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""95ca3b4f-7868-4141-bd85-2360c05c2e8a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""465f22f0-b3c0-407d-99e3-6a079ff5a542"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bcd1f61-4709-45b0-8ac5-c5c447ec1deb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70804e86-5db1-4dee-b8e0-684c02c60a1e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
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
        }
    ]
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Movement = m_Default.FindAction("Movement", throwIfNotFound: true);
        m_Default_Shoot = m_Default.FindAction("Shoot", throwIfNotFound: true);
        m_Default_Reload = m_Default.FindAction("Reload", throwIfNotFound: true);
        m_Default_Interact = m_Default.FindAction("Interact", throwIfNotFound: true);
        m_Default_MousePosition = m_Default.FindAction("MousePosition", throwIfNotFound: true);
        // InBetweenMenu
        m_InBetweenMenu = asset.FindActionMap("InBetweenMenu", throwIfNotFound: true);
        m_InBetweenMenu_Submit = m_InBetweenMenu.FindAction("Submit", throwIfNotFound: true);
        // GameOver
        m_GameOver = asset.FindActionMap("GameOver", throwIfNotFound: true);
        m_GameOver_Restart = m_GameOver.FindAction("Restart", throwIfNotFound: true);
        m_GameOver_Quit = m_GameOver.FindAction("Quit", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_Movement;
    private readonly InputAction m_Default_Shoot;
    private readonly InputAction m_Default_Reload;
    private readonly InputAction m_Default_Interact;
    private readonly InputAction m_Default_MousePosition;
    public struct DefaultActions
    {
        private @PlayerActions m_Wrapper;
        public DefaultActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Default_Movement;
        public InputAction @Shoot => m_Wrapper.m_Default_Shoot;
        public InputAction @Reload => m_Wrapper.m_Default_Reload;
        public InputAction @Interact => m_Wrapper.m_Default_Interact;
        public InputAction @MousePosition => m_Wrapper.m_Default_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @Shoot.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnReload;
                @Interact.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                @MousePosition.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);

    // InBetweenMenu
    private readonly InputActionMap m_InBetweenMenu;
    private IInBetweenMenuActions m_InBetweenMenuActionsCallbackInterface;
    private readonly InputAction m_InBetweenMenu_Submit;
    public struct InBetweenMenuActions
    {
        private @PlayerActions m_Wrapper;
        public InBetweenMenuActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_InBetweenMenu_Submit;
        public InputActionMap Get() { return m_Wrapper.m_InBetweenMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InBetweenMenuActions set) { return set.Get(); }
        public void SetCallbacks(IInBetweenMenuActions instance)
        {
            if (m_Wrapper.m_InBetweenMenuActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_InBetweenMenuActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_InBetweenMenuActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_InBetweenMenuActionsCallbackInterface.OnSubmit;
            }
            m_Wrapper.m_InBetweenMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
            }
        }
    }
    public InBetweenMenuActions @InBetweenMenu => new InBetweenMenuActions(this);

    // GameOver
    private readonly InputActionMap m_GameOver;
    private IGameOverActions m_GameOverActionsCallbackInterface;
    private readonly InputAction m_GameOver_Restart;
    private readonly InputAction m_GameOver_Quit;
    public struct GameOverActions
    {
        private @PlayerActions m_Wrapper;
        public GameOverActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_GameOver_Restart;
        public InputAction @Quit => m_Wrapper.m_GameOver_Quit;
        public InputActionMap Get() { return m_Wrapper.m_GameOver; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameOverActions set) { return set.Get(); }
        public void SetCallbacks(IGameOverActions instance)
        {
            if (m_Wrapper.m_GameOverActionsCallbackInterface != null)
            {
                @Restart.started -= m_Wrapper.m_GameOverActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_GameOverActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_GameOverActionsCallbackInterface.OnRestart;
                @Quit.started -= m_Wrapper.m_GameOverActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_GameOverActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_GameOverActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_GameOverActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public GameOverActions @GameOver => new GameOverActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IDefaultActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IInBetweenMenuActions
    {
        void OnSubmit(InputAction.CallbackContext context);
    }
    public interface IGameOverActions
    {
        void OnRestart(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
