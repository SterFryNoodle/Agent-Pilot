using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 2f;

    [SerializeField] int maxXRange = 10;
    [SerializeField] int maxYRange = 10;

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
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        float horizontalMove = movement.ReadValue<Vector2>().x; //get value from player input through new
        float verticalMove = movement.ReadValue<Vector2>().y; //input system.

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
        


        transform.localRotation = Quaternion.Euler(-30f, 30f, 0);
    }
}