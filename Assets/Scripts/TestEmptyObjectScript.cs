using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEmptyObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        // Debug.Log("x: " + x);
        float y = Input.GetAxis("Vertical");
        // Debug.Log("y:" + y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pushed Space.");
        }
    }
}
