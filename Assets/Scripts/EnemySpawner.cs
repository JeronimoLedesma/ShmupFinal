using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject[] enemies;
    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        while (true)
        {
            GameObject enemy = (GameObject)Instantiate(enemies[Random.Range(0,enemies.Length)]);
            enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

            yield return new WaitForSeconds(time);
        }
        
    }
}
