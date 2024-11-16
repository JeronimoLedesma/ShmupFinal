using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBeheavior : MonoBehaviour
{
    [SerializeField]float speed;
    Vector2 direccion;
    bool preparado;

    void Awake()
    {
        preparado = false;   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        direccion = direction.normalized;
        preparado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (preparado)
        {
            Vector2 posicion = transform.position;

            posicion += direccion * speed * Time.deltaTime;

            transform.position = posicion;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if (transform.position.x < min.x || transform.position.x > max.x || transform.position.y < min.y || transform.position.y > max.y)
            {
                Destroy(gameObject);
            }
        }
    }
}
