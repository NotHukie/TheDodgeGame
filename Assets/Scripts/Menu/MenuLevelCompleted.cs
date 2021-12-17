using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelCompleted : MonoBehaviour
{
    public void Levels()
    {
        SceneManager.LoadScene(5);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
