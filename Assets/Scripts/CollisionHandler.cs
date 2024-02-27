using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void PlayerCollision(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Debug.Log("Player Ship triggered Enemy collider");

        }
        else if (collision.gameObject.tag == "TerrainTag")
        {
            Debug.Log("Player Ship collided with Bridge");
        }
    }
}
