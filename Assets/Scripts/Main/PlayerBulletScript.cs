using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 3, 0) * Time.deltaTime * 4f;
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
