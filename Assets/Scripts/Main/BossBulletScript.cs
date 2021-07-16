using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    private float x;
    private float y;

    public void Setting(float angle, float speed)
    {
        // x = 3;
        // y = -3;  

        // V Fire to rightward
        // x = Mathf.Cos(0);
        // y = Mathf.Sin(0);
        
        // 2PI = 360 degrees
        // PI = 180 degrees
        // V Fire letfward
        // x = Mathf.Cos(Mathf.PI);
        // y = Mathf.Sin(Mathf.PI);
        
        // PI / 2 = 90 degrees
        // V Fire upward
        x = Mathf.Cos(Mathf.PI / 2); // 90
        y = Mathf.Sin(Mathf.PI / 2); // 90
        
        // PI / 2 = 90 degrees
        // V Fire downward
        // x = Mathf.Cos(-Mathf.PI / 2); // -90
        // y = Mathf.Sin(-Mathf.PI / 2); // -90
        
        x = Mathf.Cos(angle) * speed;
        y = Mathf.Sin(angle) * speed;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position -= new Vector3(0, 6, 0) * Time.deltaTime;
        transform.position += new Vector3(x, y, 0) * Time.deltaTime;
        if (transform.position.x > 8 ||
            transform.position.x < -8 ||
            transform.position.y > 6 ||
            transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
