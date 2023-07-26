using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    [SerializeField]
    private bool mobileMode;
    [Space]
    [SerializeField]
    private Joystick mobileJoystick;
    [SerializeField]
    private TouchZone mobileTouchZone;
    [Space]
    //components
    [SerializeField]
    private PlayerController playerController;
    private InputActions inputActions;

    private void Awake()
    {
        Application.targetFrameRate = 144;
        InitializeActions();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void InitializeActions ()
    {
        playerController.ConnectInputManager(this);
        inputActions = new InputActions();
        inputActions.Gameplay.Jump.performed += InputJump;
    }
    public Vector2 MovingVector 
    { 
        get
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (!mobileMode)
            {
                return inputActions.Gameplay.Moving.ReadValue<Vector2>();
            }
            else
            {
                return mobileJoystick.Direction;
            }
#elif UNITY_IPHONE || UNITY_ANDROID
        return mobileJoystick.Direction;
#endif
        }
    }
    public Vector2 RotationVector
    {
        get
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (!mobileMode)
            {
                return inputActions.Gameplay.Rotation.ReadValue<Vector2>();
            }
            else
            {
                return mobileTouchZone.TouchDelta;
            }
#elif UNITY_IPHONE || UNITY_ANDROID
        return mobileTouchZone.TouchDelta;
#endif
        }
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {

    }

    public void Jump()
    {
        playerController.Jump();
    }
    private void InputJump(InputAction.CallbackContext context)
    {
        Jump();
    }



}
