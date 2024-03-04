using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform effectsSpawner;
    [SerializeField] int increasePoints = 5;

    ScoreBoard scoreBoard; //declares variable of Scoreboard type, allowing to communicate w/ the other class.

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); //Finds the first variable of Scoreboard type upon start, which works in this instance b/c there is only one variable of that type.
    }

    void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity); //Instanstiates FX on position of enemy object w/ no rotation
        vfx.transform.parent = effectsSpawner; //setting the gameobject attached to effectsSpawner to be the parent of gameobject attached to vfx.        
        Destroy(gameObject);
        scoreBoard.ScoreIncrease(increasePoints);
    }
}
