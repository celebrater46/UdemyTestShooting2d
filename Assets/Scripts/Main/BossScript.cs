using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManagerScriptMain gameManagerScriptMain;
    // public GameObject bossBulletPrefab;
    public BossBulletScript bossBulletPrefab;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(bossBulletPrefab, transform.position, transform.rotation);
        gameManagerScriptMain = GameObject.Find("GameManager").GetComponent<GameManagerScriptMain>();
        // player = GameObject.Find("Player").GetComponent<GameObject>();
        // player = GameObject.Find("Player");
        player = GameObject.Find("PlayerShip"); // Needs to be the same name as Hierarchy
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
        // StartCoroutine(ShotBulletsRepeat(4, 8));
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
    
    private IEnumerator ShotNum(int number, float speed, float delay)
    {
        // Debug.Log("ShotN is working");
        // int number = 8;
        for (int i = 0; i < number; i++)
        {
            yield return new WaitForSeconds(delay);
            float angle = Mathf.PI / number * 2 * i;
            Shot(angle, speed);
        }
    }
    
    private IEnumerator ShotNumRepeat(int count, int number, float speed, float delay, float interval)
    {
        // Debug.Log("ShotBulletsRepeat is working");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(interval);
            // yield return ShotN(number, speed, delay);
            yield return ShotNum(number, speed, delay);
        }
    }
    
    private IEnumerator ShotCurve(int number, float speed, float delay)
    {
        for (int i = 0; i < number; i++)
        {
            yield return new WaitForSeconds(delay);
            float angle = Mathf.PI / number * 2 * i;
            Shot(angle - Mathf.PI / 2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
        }
    }
    
    private IEnumerator ShotCurveRepeat(int count, int number, float speed, float delay, float interval)
    {
        // Debug.Log("ShotBulletsRepeat is working");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(interval);
            // yield return ShotN(number, speed, delay);
            yield return ShotCurve(number, speed, delay);
        }
    }
    
    private void ShotAim(float speed)
    {
        Debug.Log("ShotAim() is working");
        Debug.Log(player.transform.position.y);
        // Get relative position from Boss to Player
        Vector3 relativePosition = player.transform.position - transform.position;

        // Arctangent leads the direction
        float direction = Mathf.Atan2(relativePosition.y, relativePosition.x);
        
        Shot(direction, speed);
        
        // for (int i = 0; i < number; i++)
        // {
        //     float angle = Mathf.PI / number * 2 * i;
        //     Shot(angle, speed);
        // }
    }
    
    private IEnumerator ShotAimRepeat(int count, float speed, float interval)
    {
        // Debug.Log("ShotBulletsRepeat is working");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(interval);
            // yield return ShotN(number, speed, delay);
            ShotAim(speed);
        }
    }

    private IEnumerator ShotAimShower(int count, float speed, float interval)
    {
        Vector3 relativePosition = player.transform.position - transform.position;

        // Arctangent leads the direction
        float direction = Mathf.Atan2(relativePosition.y, relativePosition.x);
        int bulletCount = count;
        
        for (int i = 0; i < count; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            yield return new WaitForSeconds(interval);
            // yield return ShotN(number, speed, delay);
            Shot(direction - angle, speed);
        }
    }

    private IEnumerator EnemyCpu()
    {
        while (transform.position.y > 2f)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 3f;
            yield return null; // Wait 0.02s (1 Frame)
        }
        
        // Debug.Log("EnemyCpu is working");
        while (true)
        {
            yield return ShotAimShower(6, 6, 0.1f);
            yield return new WaitForSeconds(1f);
            yield return ShotAimRepeat(16, 8, 0.1f);
            yield return new WaitForSeconds(1f);
            yield return ShotNumRepeat(4, 16, 8, 0.01f, 0.1f);
            yield return new WaitForSeconds(1f);
            yield return ShotCurveRepeat(8, 24, 8, 0.01f, 0.07f);
            yield return new WaitForSeconds(1.5f);
            yield return ShotNumRepeat(16, 6, 16, 0.005f, 0.05f);
            yield return new WaitForSeconds(1f);
        }
    }
}
