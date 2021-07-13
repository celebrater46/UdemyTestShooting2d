using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingCubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RemoveCube", 1f, 1f); // (Method, StartTime, Interval)
        InvokeRepeating("ShowCube", 1.5f, 1f); // (Method, StartTime, Interval)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RemoveCube()
    {
        gameObject.SetActive(false);
    }
    
    void ShowCube()
    {
        gameObject.SetActive(true);
    }
}
