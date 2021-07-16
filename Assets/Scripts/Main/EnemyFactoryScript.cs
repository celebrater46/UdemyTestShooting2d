using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactoryScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Manufacture", 0.5f, 1f); // Manufacture Enemies every 1s after 0.5s
        Invoke("ManufactureBoss", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Manufacture()
    {
        Vector3 releasePosition = new Vector3(Random.Range(-6, 7), transform.position.y, transform.position.z);
        // Instantiate(enemyPrefab, transform.position, transform.rotation);
        Instantiate(enemyPrefab, releasePosition, transform.rotation);
    }
    
    private void ManufactureBoss()
    {
        Instantiate(bossPrefab, transform.position, transform.rotation);
        CancelInvoke(); // Stop InvokeRepeating()
    }
}
