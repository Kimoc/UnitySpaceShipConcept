// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""e80d03cd-1a00-4418-a200-f7e25a9b63de"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""43d9acca-73fe-4f3a-82d4-49510631637a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateShip"",
                    ""type"": ""Button"",
                    ""id"": ""8647dcc3-69b5-4d0d-87f8-d1e36ebb2730"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""4075bdcd-04ca-41c0-b18a-3bf7198b92b5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""723ad0ef-4400-4463-8cde-64339b9bc044"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6f3ed2ea-ba69-4423-b52e-afda196a31f2"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d65d5a7-78bd-4d79-8e99-459d0fb66d93"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85ad95d2-6e85-4707-b153-2498391cfb3a"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80e8073d-ed17-4e67-b2f4-75c257187912"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.GetActionMap("GamePlay");
        m_GamePlay_Accelerate = m_GamePlay.GetAction("Accelerate");
        m_GamePlay_RotateShip = m_GamePlay.GetAction("RotateShip");
        m_GamePlay_RotateLeft = m_GamePlay.GetAction("RotateLeft");
        m_GamePlay_RotateRight = m_GamePlay.GetAction("RotateRight");
    }

    ~PlayerControls()
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Accelerate;
    private readonly InputAction m_GamePlay_RotateShip;
    private readonly InputAction m_GamePlay_RotateLeft;
    private readonly InputAction m_GamePlay_RotateRight;
    public struct GamePlayActions
    {
        private PlayerControls m_Wrapper;
        public GamePlayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_GamePlay_Accelerate;
        public InputAction @RotateShip => m_Wrapper.m_GamePlay_RotateShip;
        public InputAction @RotateLeft => m_Wrapper.m_GamePlay_RotateLeft;
        public InputAction @RotateRight => m_Wrapper.m_GamePlay_RotateRight;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                Accelerate.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerate;
                Accelerate.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerate;
                Accelerate.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerate;
                RotateShip.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateShip;
                RotateShip.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateShip;
                RotateShip.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateShip;
                RotateLeft.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateLeft;
                RotateLeft.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateLeft;
                RotateLeft.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateLeft;
                RotateRight.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateRight;
                RotateRight.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateRight;
                RotateRight.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateRight;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Accelerate.started += instance.OnAccelerate;
                Accelerate.performed += instance.OnAccelerate;
                Accelerate.canceled += instance.OnAccelerate;
                RotateShip.started += instance.OnRotateShip;
                RotateShip.performed += instance.OnRotateShip;
                RotateShip.canceled += instance.OnRotateShip;
                RotateLeft.started += instance.OnRotateLeft;
                RotateLeft.performed += instance.OnRotateLeft;
                RotateLeft.canceled += instance.OnRotateLeft;
                RotateRight.started += instance.OnRotateRight;
                RotateRight.performed += instance.OnRotateRight;
                RotateRight.canceled += instance.OnRotateRight;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnRotateShip(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
    }
}
