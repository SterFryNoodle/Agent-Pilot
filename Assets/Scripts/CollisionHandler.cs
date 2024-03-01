using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem explosiveFX;

    bool isStartingSequence;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " Triggered with " + other);

        if (isStartingSequence)
        {
            return;
        }
        
        StartCrashSequence();
    }

    void StartCrashSequence()
    {        
        isStartingSequence = true;
        explosiveFX.Play();
        GetComponent<PlayerController>().enabled = false; //Disables the PlayerController script
        Invoke("LoadLevel", delayTime); //Reloads the level after "delayTime" amount of time
    }

    void LoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Gets current scene in the build settings
        SceneManager.LoadScene(currentSceneIndex); //Loads the scene from build index stored in the variable
    }
}
