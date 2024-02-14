using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 2f;

    [SerializeField] int maxXRange = 10;
    [SerializeField] int maxYRange = 12;

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
        float horizontalRotate = movement.ReadValue<Vector2>().x; //get value from player input through new
        float verticalRotate = movement.ReadValue<Vector2>().y; //input system.

        float xOffset = horizontalRotate * Time.deltaTime * controlSpeed; //offset value from player original position
        float yOffset = verticalRotate * Time.deltaTime * controlSpeed;

        float newXPos = transform.localPosition.x + xOffset;//stores new position value
        float newYPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(newXPos, -maxXRange, maxXRange); //variables store min/max values of player transform in x/y-axis.
        float clampYPos = Mathf.Clamp(newYPos, -maxYRange, maxYRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z); //allows to move object in local vector3 axis.
    }
}