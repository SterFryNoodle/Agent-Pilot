using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys instantiations of enemy explosion vfx
public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float delayDetruction = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,delayDetruction);
    }    
}
