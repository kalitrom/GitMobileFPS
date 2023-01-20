using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMobile : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private bool canMove;
    [SerializeField] private float StickToGroundForce = 10;
    [SerializeField] private float gravity = 10;
    private float verticalVelocity;

    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckRadius;

    private bool grounded;

    [Header("Interaction settings")]

    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveInputDeadZone;

    // Touch detection
    private int leftFingerId, rightFingerId;
    private float halfScreenWidth;

    // Camera control
    private Vector2 lookInput;
    private float cameraPitch;

    // Player movement
    private Vector2 moveTouchStartPosition;
    private Vector2 moveInput;

    private CameraBobbing cameraBobbing;

    void Start()
    {
        canMove = true;
        leftFingerId = -1;
        rightFingerId = -1;

        halfScreenWidth = Screen.width / 2;

        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);

        cameraBobbing = GetComponent<CameraBobbing>();
    }

    private void FixedUpdate()
    {
        grounded = Physics.CheckSphere(groundcheck.position, groundCheckRadius, groundLayers);
    }

    void Update()
    {
        GetTouchInput();

        if(canMove == true)
            {
            if (rightFingerId != -1)
            {
                Debug.Log("Rotating");
                LookAround();
            }

            if (leftFingerId != -1)
            {
                Debug.Log("Moving");
                Move();
            }
            else
            {
                cameraBobbing.IsWalking = false;
            }
            VerticalMovement();
        }
    }

    void GetTouchInput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:

                    if (t.position.x < halfScreenWidth && leftFingerId == -1)
                    {
                        leftFingerId = t.fingerId;
                        moveTouchStartPosition = t.position;
                    }
                    else if (t.position.x > halfScreenWidth && rightFingerId == -1)
                    {
                        rightFingerId = t.fingerId;
                    }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    if (t.fingerId == leftFingerId)
                    {
                        leftFingerId = -1;
                        Debug.Log("Stopped tracking left finger");
                    }
                    else if (t.fingerId == rightFingerId)
                    {
                        rightFingerId = -1;
                        Debug.Log("Stopped tracking right finger");
                    }

                    break;
                case TouchPhase.Moved:

                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                    }
                    else if (t.fingerId == leftFingerId)
                    {
                        moveInput = t.position - moveTouchStartPosition;
                    }

                    break;
                case TouchPhase.Stationary:
                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = Vector2.zero;
                    }
                    break;
            }
        }
    }

    void LookAround()
    {
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        transform.Rotate(transform.up, lookInput.x);
    }

    void Move()
    {
        if (moveInput.sqrMagnitude <= moveInputDeadZone)
        {
            cameraBobbing.IsWalking = false;
            return;
        }

        cameraBobbing.IsWalking = true;
        Vector2 movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;
        characterController.Move(transform.right * movementDirection.x + transform.forward * movementDirection.y);
    }

    void VerticalMovement()
    {
        if (grounded && verticalVelocity <= 0) verticalVelocity = -StickToGroundForce * Time.deltaTime;
        else verticalVelocity -= gravity * Time.deltaTime;
        Vector3 verticalMovement = transform.up * verticalVelocity;
        characterController.Move(verticalMovement * Time.deltaTime);
    }

    public void ReduseCameraAndMovespeed(int reductionSpeed)
    {
        GameObject cameraGameObject = cameraTransform.gameObject;
        cameraGameObject.GetComponent<Camera>().nearClipPlane = 0.01f;
        moveSpeed = reductionSpeed;
    }

    public void SwitchPlayerCanMove()
    {
        canMove = !canMove;
    }
}


