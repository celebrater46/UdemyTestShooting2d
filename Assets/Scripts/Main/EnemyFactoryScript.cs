using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactoryScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Manufacture", 0.5f, 1f); // Manufacture Enemies every 1s after 0.5s
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Manufacture()
    {
        Vector3 releasePosition = new Vector3(Random.Range(-6, 7), transform.position.y, transform.position.z);
        // Instantiate(enemyPrefab, transform.position, transform.rotation);
        Instantiate(enemyPrefab, releasePosition, transform.rotation);
    }
}
