using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipScript : MonoBehaviour
{
    public Transform playerGun;
    public GameObject bulletPrefab;
    private AudioSource audioSource;
    public AudioClip shotSound;
    public GameObject explosionPrefab;
    public GameManagerScriptMain gameManagerScriptMain;
    private string shotKey = "space";
    private string shotKey2 = "joystick button 0";
    
    // public AudioClip explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManagerScriptMain = GameObject.Find("GameManager").GetComponent<GameManagerScriptMain>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
    }

    void Move()
    {
        // float x = Input.GetAxis("Horizontal");
        // float y = Input.GetAxis("Vertical");
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        // Debug.Log(x);
        // Debug.Log(y);
        // transform.position += new Vector3(x, y, 0) * Time.deltaTime * 6f; // Time.deltaTime adjust the player speed regardless of Frame rate.
        // x: -6.3 ~ 6.3, y: -4.6 ~ 4.6
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 6f;
        // V Mathf.Clamp(var, min, max) give a var constraint
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -6.3f, 6.3f),
            Mathf.Clamp(nextPosition.y, -4.6f, 4.6f),
            nextPosition.z
            );
        transform.position = nextPosition;
    }
    void Shot()
    {
        if (Input.GetKeyDown(shotKey) || Input.GetKeyDown(shotKey2))
        {
            // Debug.Log("Fire!");
            Instantiate(bulletPrefab, playerGun.position, transform.rotation);
            audioSource.PlayOneShot(shotSound);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManagerScriptMain.GameOver();
        }
    }
}
