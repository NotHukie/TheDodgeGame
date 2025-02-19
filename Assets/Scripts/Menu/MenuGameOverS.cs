using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuGameOverS : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(1);
        Destroy(GameObject.FindWithTag("Audio"));
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
        Destroy(GameObject.FindWithTag("Audio"));
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Destroy(GameObject.FindWithTag("Audio"));
    }
}
