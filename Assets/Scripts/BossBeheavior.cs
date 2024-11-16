using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBeheavior : MonoBehaviour
{
    public enum BossStateMachine
    {
        IdleWhite,
        IdleBlack,
        MoveWhite,
        MoveBlack
    }
    private BossStateMachine currentState;
    float elapsedTime;
    public float limitTime;
    public float speed;
    public float life;
    // Start is called before the first frame update
    void Start()
    {
        if (StateController.white)
        {
            currentState = BossStateMachine.IdleWhite;
        }
        else
        {
            currentState = BossStateMachine.IdleBlack;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case BossStateMachine.IdleWhite:
                idleWhite();
                break;
            case BossStateMachine.IdleBlack:
                idleBlack();
                break;
            case BossStateMachine.MoveWhite:
                moveWhite();
                break;
            case BossStateMachine.MoveBlack:
                moveBlack();
                break;
        }
        
    }
    void idleWhite()
    {
        elapsedTime += Time.deltaTime;
        if (!StateController.white)
        {
            elapsedTime = 0;
            currentState = BossStateMachine.IdleBlack;
        }
        if (elapsedTime >= limitTime)
        {
            currentState = BossStateMachine.MoveWhite;
        }
    }

    void idleBlack()
    {
        elapsedTime += Time.deltaTime;
        if (StateController.white)
        {
            elapsedTime = 0;
            currentState = BossStateMachine.IdleWhite;
        }
        if (elapsedTime >= limitTime)
        {
            currentState = BossStateMachine.MoveBlack;
        }
    }

    void moveWhite()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y <= min.y)
        {
            SceneManager.LoadScene(4);
        }
        transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);
        if (!StateController.white)
        {
            elapsedTime = 0;
            currentState = BossStateMachine.IdleBlack;
        }
    }

    void moveBlack()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y >= max.y)
        {
            elapsedTime = 0;
            transform.position = new Vector2(transform.position.x, max.y);
            currentState = BossStateMachine.IdleBlack;
        }
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        if (StateController.white)
        {
            elapsedTime = 0;
            currentState = BossStateMachine.IdleWhite;
        }
    }

    public void takeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }
}
