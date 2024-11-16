using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletBeheavior : MonoBehaviour
{
    public float xMove;
    public float yMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + xMove * Time.deltaTime, transform.position.y + yMove * Time.deltaTime);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x < min.x || transform.position.x > max.x || transform.position.y < min.y || transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
}
