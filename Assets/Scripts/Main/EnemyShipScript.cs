using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManagerScriptMain gameManagerScriptMain;
    
    // Start is called before the first frame update
    void Start()
    {
        // gameManagerScriptMain = GetComponent<GameManagerScriptMain>(); // Could not added
        gameManagerScriptMain = GameObject.Find("GameManager").GetComponent<GameManagerScriptMain>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 2 * Time.deltaTime, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("You got him!!");
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
        Destroy(other.gameObject);
        Destroy(gameObject);
        // if (other.tag == "Player")
        // {
        //     gameManagerScriptMain.AddScore();
        // }
        if (other.CompareTag("Bullet"))
        {
            gameManagerScriptMain.AddScore();
        } else if (other.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);
        }
    }
}
