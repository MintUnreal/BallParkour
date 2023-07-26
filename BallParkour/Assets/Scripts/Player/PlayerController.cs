using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : PlayerComponentBase
{
    [SerializeField]
    private Rigidbody followTarget;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private CinemachineFreeLook freeLookCamera;
    [SerializeField]
    private PlayerGroundTrigger groundTrigger;

    //components
    private Rigidbody playerRigidbody { get; set; }
    private Transform playerTransform { get; set; }

    //manager
    private InputManager inputManager;
    public void ConnectInputManager(InputManager manager)
    {
        inputManager = manager;
    }
    private void InitializeComponents()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = transform;
    }

    //teleport
    public void Teleport(Vector3 pos) => playerTransform.position = pos;


    //movement
    private Vector3 moveDirection = Vector3.zero;
    private float sensitivity = 0.1f;
    private float moveSpeed = 10f;
    private float jumpForce = 230f;

    private void Movement()
    {
        Quaternion inverseRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, cameraTransform.eulerAngles.z);
        Vector3 localDirection = inverseRotation * new Vector3(moveDirection.x, 0, moveDirection.y);
        float speedMultiplier = 1f;
        if (!groundTrigger.Grounded) speedMultiplier = 0.2f;
        playerRigidbody.AddForce(localDirection.normalized * moveSpeed * speedMultiplier);

#if UNITY_EDITOR
        Debug.DrawLine(transform.position, transform.position + localDirection.normalized * 1f,Color.cyan);
        Debug.DrawLine(transform.position + localDirection.normalized * 1f, (transform.position + localDirection.normalized * 1f)+ Quaternion.LookRotation(localDirection, Vector3.up) * new Vector3(0.2f,0,-0.2f), Color.cyan);
        Debug.DrawLine(transform.position + localDirection.normalized * 1f, (transform.position + localDirection.normalized * 1f)+ Quaternion.LookRotation(localDirection, Vector3.up) * new Vector3(-0.2f, 0,-0.2f), Color.cyan);
#endif

    }
    private void Rotation()
    {
        freeLookCamera.m_YAxis.m_InputAxisValue = inputManager.RotationVector.y * sensitivity;
        freeLookCamera.m_XAxis.m_InputAxisValue = inputManager.RotationVector.x * sensitivity;

        moveDirection = inputManager.MovingVector;
    }
    public void Jump()
    {
        if (groundTrigger.Grounded)
        {
            playerRigidbody.AddForce(jumpForce * Vector3.up);
        }
    }

    //built-in methods
    private void Awake()
    {
        InitializeComponents();
    }

    private void FixedUpdate()
    {
        followTarget.MovePosition(playerTransform.position);
        Movement();
    }

    
    private void Update()
    {
        Rotation();
    }

}
