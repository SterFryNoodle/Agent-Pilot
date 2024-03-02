using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform effectsSpawner;

    void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity); //Instanstiates FX on position of enemy object w/ no rotation
        vfx.transform.parent = effectsSpawner; //setting the gameobject attached to effectsSpawner to be the parent of gameobject attached to vfx.
        Destroy(gameObject);
    }
}
