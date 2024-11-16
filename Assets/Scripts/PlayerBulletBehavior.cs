using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
        
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehavior>().takeDamage(100);
        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            collision.gameObject.GetComponent<Enemy2Behavior>().takeDamage(100);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossBeheavior>().takeDamage(100);
        }
    }
}
