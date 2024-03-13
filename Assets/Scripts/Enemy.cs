using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject damageFX;       
    [SerializeField] int increasePoints = 5;
    [SerializeField] int hitPoints = 2;        

    ScoreBoard scoreBoard; //declares variable of Scoreboard type, allowing to communicate w/ the other class.
    GameObject effectsSpawner; 

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); //Finds the first variable of Scoreboard type upon start, which works in this instance b/c there is only one variable of that type.
        effectsSpawner = GameObject.FindWithTag("RuntimeSpawner"); //Setting effectsSpawner as a GameObject of what holds "RuntimeSpawner" tag
        AddRigidBody();        
    }

    void AddRigidBody()
    {
        gameObject.AddComponent<Rigidbody>(); //Adds the rigidbody component to object attached through here
        GetComponent<Rigidbody>().useGravity = false; //Sets gravity to false
    }

    void OnParticleCollision(GameObject other)
    {
        DamageEnemyVFX();

        if(!other.CompareTag("Ally"))
        {
            EnemyHitPoints();   
        }
             
    }

    void EnemyHitPoints() //Gives enemies hp and destroys them once it hits 0
    {
        hitPoints --;        

        if (hitPoints == 0)
        {
            InstantiateEnemyExplosionVFX();
            Destroy(gameObject);
            scoreBoard.ScoreIncrease(increasePoints); //Sends value of 5 to ScoreIncrease function utilizing the class ScoreBoard variable
        }
    }

    void InstantiateEnemyExplosionVFX()
    {
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity); //Instanstiates FX on position of enemy object w/ no rotation
        vfx.transform.parent = effectsSpawner.transform; //setting the transform of what tag effectsSpawner holds to be the parent of
                                                         //the GameObject that vfx is instantiating
    }

    void DamageEnemyVFX()
    {
        GameObject hitVFX = Instantiate(damageFX, transform.position, Quaternion .identity);
        hitVFX.transform.parent = effectsSpawner.transform;
    }
        
}
