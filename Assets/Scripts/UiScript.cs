using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        // text = GetComponent<Text>(); // not need
        text.text = "Hello";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
