using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public enum BulletStateMachine
    {
        white,
        black
    }
    private BulletStateMachine currentBullet;
    public GameObject bulletW;
    public GameObject bulletB;
    public float time;
    public float speedX;
    public float speedY;
    
    void Start()
    {
        if (StateController.white)
        {
            currentBullet = BulletStateMachine.white;
        }
        else
        {
            currentBullet = BulletStateMachine.black;
        }
        StartCoroutine(FireBoss());
    }

    // Update is called once per frame
    void Update()
    {
        if (StateController.white)
        {
            currentBullet = BulletStateMachine.white;
        }
        else
        {
            currentBullet = BulletStateMachine.black;
        }
    }

    IEnumerator FireBoss()
    {
        while (true)
        {
            GameObject playerShip = GameObject.FindGameObjectWithTag("Player");
            while (currentBullet == BulletStateMachine.black)
            {
                if (playerShip != null)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletW);

                    bullet.transform.position = transform.position;

                    Vector2 direccion = playerShip.transform.position - bullet.transform.position;

                    bullet.GetComponent<EnemyBulletBeheavior>().SetDirection(direccion);
                }

                yield return new WaitForSeconds(time);
            }
            while (currentBullet == BulletStateMachine.white)
            {
                GameObject bullet = (GameObject)Instantiate(bulletB);
                bullet.transform.position = transform.position;
                bullet.GetComponent<BossBulletBeheavior>().xMove = speedX;
                bullet.GetComponent<BossBulletBeheavior>().yMove = speedY;
                yield return new WaitForSeconds(time / 2);
            }
        }
       
    }
}
