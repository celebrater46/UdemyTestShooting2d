using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 2 * Time.deltaTime, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You got him!!");
        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }
}
