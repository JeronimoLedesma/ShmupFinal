using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public static bool white;
    public static int score;
    public TextMeshProUGUI text;
    public GameObject enemySpawner;
    public GameObject boss;
    int bossInScreen;

    void Start()
    {
        score = 0;
        white = false;
        bossInScreen = 0;
    }

    void Update()
    {
        text.text = "Puntaje " + score;
        if (Input.GetMouseButtonDown(1))
        {
            if (!white) 
            { 
                Camera.main.backgroundColor = Color.white;
                white = true;
            }
            else
            {
                Camera.main.backgroundColor= Color.black;
                white = false;
            }
        }

        if (score >= 100)
        {
            while (bossInScreen == 0)
            {
                enemySpawner.SetActive(false);
                GameObject bossfight = (GameObject)Instantiate(boss);
                Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
                bossfight.transform.position = new Vector2(transform.position.x, max.y);
                bossInScreen = 1;
            }
            
        }
    }
}
