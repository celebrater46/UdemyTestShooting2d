using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipScript : MonoBehaviour
{
    public Transform playerGun;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.position += new Vector3(x, y, 0) * Time.deltaTime * 6f; // Time.deltaTime adjust the player speed regardless of Frame rate.
    }
    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Fire!");
            Instantiate(bulletPrefab, playerGun.position, transform.rotation);
        }
    }
}
