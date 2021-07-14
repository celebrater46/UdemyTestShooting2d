using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemyShipScript : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManagerScriptMain gameManagerScriptMain;
    public GameObject enemyBulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScriptMain = GameObject.Find("GameManager").GetComponent<GameManagerScriptMain>();
        Shot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        if (other.CompareTag("Bullet"))
        {
            gameManagerScriptMain.AddScore();
        } 
        else if (other.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);
            gameManagerScriptMain.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void Shot()
    {
        Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
    }
}
