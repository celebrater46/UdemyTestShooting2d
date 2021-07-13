using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManagerScriptMain gameManagerScriptMain;
    // private AudioSource audioSource;
    // private AudioClip explosionSound; // private var does not appear on the inspector
    // public AudioClip explosionSound;
    // public AudioClip dedenSound;
    
    // Start is called before the first frame update
    void Start()
    {
        // gameManagerScriptMain = GetComponent<GameManagerScriptMain>(); // Could not added. Because this method is valid only when own component.
        gameManagerScriptMain = GameObject.Find("GameManager").GetComponent<GameManagerScriptMain>();
        // audioSource = GetComponent<AudioSource>();
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
        // audioSource.PlayOneShot(explosionSound); // Put "audioSource" before Destroy(). Because it does not play after destroyed this object
        // if (other.tag == "Player")
        // {
        //     gameManagerScriptMain.AddScore();
        // }
        if (other.CompareTag("Bullet"))
        {
            gameManagerScriptMain.AddScore();
            
        } 
        else if (other.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);
            // audioSource.PlayOneShot(explosionSound);
            // audioSource.PlayOneShot(dedenSound);
            // Invoke("gameManagerScriptMain.GameOver", 1.5f);
            // Invoke("GameOver", 1.5f);
            gameManagerScriptMain.GameOver();
        }
        // Destroy(this.gameObject);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
