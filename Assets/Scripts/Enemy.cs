using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform effectsSpawner;
    [SerializeField] int increasePoints = 5;
    [SerializeField] int hitPoints = 2;

    int hitPointsTaken = 1;

    ScoreBoard scoreBoard; //declares variable of Scoreboard type, allowing to communicate w/ the other class.

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); //Finds the first variable of Scoreboard type upon start, which works in this instance b/c there is only one variable of that type.
    }

    void OnParticleCollision(GameObject other)
    {            
        //Instantiate enemy hit FX here.
        EnemyHitPoints();        
    }

    void EnemyHitPoints() //Gives enemies hp and destroys them once it hits 0
    {
        hitPoints -= hitPointsTaken;        

        if (hitPoints == 0 )
        {
            InstantiateEnemyExplosionVFX();
            Destroy(gameObject);
            scoreBoard.ScoreIncrease(increasePoints); //Sends value of 5 to ScoreIncrease function utilizing the class ScoreBoard variable
        }
    }

    void InstantiateEnemyExplosionVFX()
    {
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity); //Instanstiates FX on position of enemy object w/ no rotation
        vfx.transform.parent = effectsSpawner; //setting the gameobject attached to effectsSpawner to be the parent of gameobject attached to vfx.
    }
}
