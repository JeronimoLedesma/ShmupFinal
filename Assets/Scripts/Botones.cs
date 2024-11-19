using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public void inicio()
    {
        SceneManager.LoadScene(1);
    }
    public void volver()
    {
        SceneManager.LoadScene(0);
    }

    public void aprender()
    {
        SceneManager.LoadScene(2);
    }
}
