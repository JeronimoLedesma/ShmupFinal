using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject bulletSpawner;
    public GameObject playerBullet;
    public float life;
    bool beingHit;
    public float stun;
    public Slider healthBar;
    void Start()
    {
        beingHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = (GameObject)Instantiate(playerBullet);
            bullet.transform.position = bulletSpawner.transform.position;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;

        pos += new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0f);
        pos.x = Mathf.Clamp(pos.x, -5f, 5f);
        pos.y = Mathf.Clamp(pos.y, -2.5f, 2.5f);
        transform.position = pos;

        healthBar.value = life;
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (!beingHit)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("Boss"))
            {
                life -= 25;
                StartCoroutine(hitStun());
            }
            if (collision.gameObject.CompareTag("White") && !StateController.white)
            {
                life -= 25;
                Destroy(collision.gameObject);
                StartCoroutine(hitStun());
                
            }
            if (collision.gameObject.CompareTag("Black") && StateController.white)
            {
                life -= 25;
                Destroy(collision.gameObject);
                StartCoroutine(hitStun());
            }
            if (life <= 0)
            {
                SceneManager.LoadScene(4);
            }
        }
        if (collision.gameObject.CompareTag("Pickup"))
        {
            StateController.score += 10;
            Destroy(collision.gameObject);
        }

    }

    IEnumerator hitStun()
    {
        beingHit = true;
        yield return new WaitForSeconds(stun);
        beingHit = false;
    }
}
