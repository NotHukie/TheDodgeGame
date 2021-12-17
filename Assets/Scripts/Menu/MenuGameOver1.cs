using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver1 : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(4);
    }
    public void Back()
    {
        SceneManager.LoadScene(5);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
