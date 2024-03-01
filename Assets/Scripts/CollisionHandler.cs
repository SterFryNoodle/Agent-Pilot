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
        HidePlayerChildMesh();
        GetComponent<PlayerController>().enabled = false;
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
}
