using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    
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

        //float horizontalRotate =  Input.GetAxis("Horizontal");
        //float verticalRotate = Input.GetAxis("Vertical");
        Debug.Log(horizontalRotate);
        Debug.Log(verticalRotate);
    }
}
