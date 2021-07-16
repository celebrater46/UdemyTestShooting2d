using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManagerScriptMain gameManagerScriptMain;
    // public GameObject bossBulletPrefab;
    public BossBulletScript bossBulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(bossBulletPrefab, transform.position, transform.rotation);
        gameManagerScriptMain = GameObject.Find("GameManager").GetComponent<GameManagerScriptMain>();
        // Shot();
        // Shot(Mathf.PI / 4f); // 45 degrees (right upward)
        // Shot(-Mathf.PI / 4f); // 45 degrees (right downward)
        // Shot(-Mathf.PI / 2f); // 45 degrees (downward)
        
        // 2PI = 360 degrees
        // PI  = 180 degrees
        
        // Right == 0PI(2PI)
        // UP == 0.5PI
        // Left == 1PI
        // Down == 1.5PI
        // Shot(Mathf.PI * 1.75f); // 45 degrees (left downward)
        // Shot(Mathf.PI * 1.5f); // 45 degrees (downward)
        // Shot(Mathf.PI * 1.25f); // 45 degrees (right downward)

        // ShotN(10, 4f);
        // StartCoroutine(ShotBulletsWavy(4, 8));
        StartCoroutine(EnemyCpu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            return;
        }
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

    private void Shot(float angle, float speed)
    {
        BossBulletScript bullet = Instantiate(bossBulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed);
    }

    // private void ShotN(int number, float speed)
    // {
    //     // int number = 8;
    //     for (int i = 0; i < number; i++)
    //     {
    //         float angle = Mathf.PI / number * 2 * i;
    //         Shot(angle, speed);
    //     }
    // }
    
    IEnumerator ShotN(int number, float speed, float delay)
    {
        // int number = 8;
        for (int i = 0; i < number; i++)
        {
            yield return new WaitForSeconds(delay);
            float angle = Mathf.PI / number * 2 * i;
            Shot(angle, speed);
        }
    }

    IEnumerator ShotBulletsWavy(int count, int number, float speed, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(0.3f);
            ShotN(number, speed, delay);
        }
    }

    IEnumerator EnemyCpu()
    {
        while (true)
        {
            yield return ShotBulletsWavy(4, 8, 6, 0);
            yield return new WaitForSeconds(1f);
            yield return ShotBulletsWavy(4, 16, 4, 0);
            yield return new WaitForSeconds(1.5f);
            yield return ShotBulletsWavy(4, 6, 8, 0.2f);
            yield return new WaitForSeconds(1f);
        }
    }
}
