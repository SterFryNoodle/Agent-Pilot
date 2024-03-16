using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem explosiveFX;
    [SerializeField] GameObject[] shipPartsArray;
    [SerializeField] AudioClip playerDeath;    

    bool isStartingSequence;
    AudioSource playerDeathAudioSource;

    private void Start()
    {
        playerDeathAudioSource = GetComponent<AudioSource>();
    }

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
        PlayExplosionAudio();
        HidePlayerChildMesh();
        if (gameObject.tag != "Ally")
        {
            GetComponent<PlayerController>().enabled = false;
        }
        GetComponent<BoxCollider>().enabled = false;
        Invoke("LoadLevel", delayTime); //Reloads the level after "delayTime" amount of time
    }

    void HidePlayerChildMesh() //Disables mesh renderer of each player children in the array
    {
        foreach (GameObject child in shipPartsArray)
        {
            var childMesh = child.GetComponentInChildren<MeshRenderer>();
            childMesh.enabled = false;
        }
    }

    void LoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Gets current scene in the build settings
        SceneManager.LoadScene(currentSceneIndex); //Loads the scene from build index stored in the variable
    }

    void PlayExplosionAudio() //Prevents audio from playing again after already being played after collision
    {
        if (!playerDeathAudioSource.isPlaying)
        {
            playerDeathAudioSource.PlayOneShot(playerDeath);            
        }
    }
}
