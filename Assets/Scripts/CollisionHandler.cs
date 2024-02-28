using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    
    bool isTransitioning;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " Triggered with " + other);
        
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        GetComponent<PlayerController>().enabled = false;
        Invoke("LoadLevel", delayTime);
    }

    void LoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
