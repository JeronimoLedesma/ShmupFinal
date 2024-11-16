using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behavior : MonoBehaviour
{
    [SerializeField] float speed;
    bool derecha;
    [SerializeField] int life;
    public GameObject drop;

    void Start()
    {
        derecha = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.x > max.x)
        {
            derecha = false;
        }
        if (transform.position.x < min.x)
        {
            derecha = true;
        }
        if (derecha)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    public void takeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            GameObject dropping = (GameObject)Instantiate(drop);
            dropping.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
