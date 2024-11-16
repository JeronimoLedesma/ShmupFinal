using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletB;
    public GameObject bulletW;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireBullet()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("Player");
        while (true)
        {
            GameObject bullet;
            if (playerShip != null)
            {
                if (StateController.white)
                {
                    bullet = (GameObject)Instantiate(bulletB);
                }
                else
                {
                    bullet = (GameObject)Instantiate(bulletW);
                }
                

                bullet.transform.position = transform.position;

                Vector2 direccion = playerShip.transform.position - bullet.transform.position;

                bullet.GetComponent<EnemyBulletBeheavior>().SetDirection(direccion);
            }

            yield return new WaitForSeconds(time);
        }
        
    }
}
