using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayCubeMakerScript : MonoBehaviour
{
    public GameObject grayCube;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(grayCube); // Create grayCube from prefab
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
