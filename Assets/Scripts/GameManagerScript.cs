using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject logo;
    // Start is called before the first frame update
    void Start()
    {
        logo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            logo.SetActive(true); // Show the logo when pushing Space Key
        }
    }
}
