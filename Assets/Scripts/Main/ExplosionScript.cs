using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip explosionSound;
    // public AudioClip dedenSound;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(explosionSound);
        Destroy(gameObject, 0.9f); // Delete this 0.5s later
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void DeleteExplosion()
    // {
    //     Destroy(this.gameObject);
    // }
}
