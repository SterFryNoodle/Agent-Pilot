using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float horizontalMove, verticalMove;
    
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 2f;

    [SerializeField] int maxXRange = 10;
    [SerializeField] int maxYRange = 10;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -10f;

    [SerializeField] float smoothInputSpeed = .1f;

    Vector2 currentInputVector;
    Vector2 smoothInputVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        SmoothController();
        MovePlayer();
        RotatePlayer();        
    }

    void MovePlayer()
    {        
        float xOffset = horizontalMove * Time.deltaTime * controlSpeed; //offset value from player original position
        float yOffset = verticalMove * Time.deltaTime * controlSpeed;

        float newXPos = transform.localPosition.x + xOffset;//stores new position value
        float newYPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(newXPos, -maxXRange, maxXRange); //variables store min/max values of player transform in x/y-axis.
        float clampYPos = Mathf.Clamp(newYPos, -maxYRange, maxYRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z); //allows to move object in local vector3 axis.
    }

    void RotatePlayer()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromControlInput = verticalMove * controlPitchFactor;
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float rollFromControlInput = horizontalMove * controlRollFactor;

        float pitch = pitchDueToPosition + pitchFromControlInput; //increase factor of pitch,yaw,roll based on both position on                                                                                                               
        float yaw = yawDueToPosition;                             //screen as well as player control inputs.
        float roll = rollFromControlInput;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    // Smooths out input from new input system when moving player around on screen.
    void SmoothController()
    {
        Vector2 throw_ = movement.ReadValue<Vector2>();
        currentInputVector = Vector2.SmoothDamp(currentInputVector, throw_, ref smoothInputVelocity, smoothInputSpeed);
        horizontalMove = currentInputVector.x;
        verticalMove = currentInputVector.y;
    }
}