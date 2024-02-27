using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + " Collided with " + collision);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " Triggered with " + other);
    }
}
