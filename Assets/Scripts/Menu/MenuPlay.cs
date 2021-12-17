using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    public void PlaySurvive()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayLevel()
    {
        SceneManager.LoadScene(5);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
