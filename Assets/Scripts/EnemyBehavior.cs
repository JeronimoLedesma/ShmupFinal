using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField] int life;
    public GameObject drop;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        life -=damage;
        if (life <= 0)
        {
            GameObject dropping = (GameObject)Instantiate(drop);
            dropping.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
