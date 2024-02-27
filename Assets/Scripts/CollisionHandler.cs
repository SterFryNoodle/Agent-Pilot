using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + " Collided with " + collision); //another way to concatenate using variable the script is attached to
    }                                                    //with the variable of the object being collided with

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " Triggered with " + other);
    }
}
