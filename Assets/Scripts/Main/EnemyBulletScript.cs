using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 5, 0) * Time.deltaTime;
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
