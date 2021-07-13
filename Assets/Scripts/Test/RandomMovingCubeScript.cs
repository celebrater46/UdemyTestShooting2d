using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovingCubeScript : MonoBehaviour
{
    // Random r = Random.value; // Compile Error
    private int count;

    private float x = 0;

    private float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        while (count < 99)
        {
            // x = Random.value; // 0-1
            // y = Random.value;
            x = Random.Range(-1, 2); // -1 - 1
            y = Random.Range(-1, 2); // -1 - 1
            // transform.Translate(r.Next(1,10), r.Next(1,10), 0); // Compile Error
            transform.Translate(x, y, 0);
            count++;
            yield return null;
        }
    }
}
