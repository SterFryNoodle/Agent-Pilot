using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float horizontalMove, verticalMove;

    [SerializeField] InputAction movement;
    [SerializeField] InputAction shoot;

    [Header("General Setup Settings")]
    [Tooltip("Stores laser particle effects")] [SerializeField] GameObject[] lasersArray;
    [Tooltip("How fast ship moves on screen")][SerializeField] float controlSpeed = 2f;

    [SerializeField] int maxXRange = 10;
    [SerializeField] int maxYRange = 10;

    [Header("Position based tuning:")]
    [Tooltip("How much ship rotates on local x-axis based on position on screen")]
    [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("How much ship rotates on local y-axis based on positon on screen")]
    [SerializeField] float positionYawFactor = 3f;

    [Header("Player input tuning:")]
    [Tooltip("How much ship rotates on local x-axis based on player input")]
    [SerializeField] float controlPitchFactor = 10f;    
    [Tooltip("How much ship rotates on local z-axis based on player input")]
    [SerializeField] float controlRollFactor = -10f;

    [Header("New Input System Smoothing:")]
    [Tooltip("Smoothing factor of player input for ship movement")] 
    [SerializeField] float smoothInputSpeed = .1f;

    Vector2 currentInputVector;
    Vector2 smoothInputVelocity;

    void OnEnable()
    {
        movement.Enable();
        shoot.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        shoot.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        SmoothController();
        MovePlayer();
        RotatePlayer();
        ProcessFireInput();
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

    void ProcessFireInput()
    {
        
        if (shoot.ReadValue<float>() > 0.5) // bc new input system only reads 0 or 1, comparing to 0.5 value is good.
        {
            ActivateLasers(true);
        }
        else
        {
            ActivateLasers(false);
        }
        
    }

    void ActivateLasers(bool isActive)
    {
        foreach (GameObject laser in lasersArray)       // foreach loop applies statements to EACH stored variable in an array
        {                                               // unlike for loop that reinterates statements a # of times to an array.
            var getEmissionModule = laser.GetComponent<ParticleSystem>().emission;
            getEmissionModule.enabled = isActive;
        }
    }
}