using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver1 : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(5);
    }
    public void RetryLevel1()
    {
        SceneManager.LoadScene(9);
    }
        public void RetryLevel2()
    {
        SceneManager.LoadScene(3);
        Destroy(GameObject.FindWithTag("Audio"));
    }
        public void RetryLevel3()
    {
        SceneManager.LoadScene(5);
        Destroy(GameObject.FindWithTag("Audio"));
    }
        public void RetryLevel4()
    {
        SceneManager.LoadScene(11);
    }
        public void RetryLevel5()
    {
        SceneManager.LoadScene(12);
    }
        public void RetryLevel6()
    {
        SceneManager.LoadScene(13);
    }
        public void RetryLevel7()
    {
        SceneManager.LoadScene(14);
    }
        public void RetryLevel8()
    {
        SceneManager.LoadScene(15);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Destroy(GameObject.FindWithTag("Audio"));
    }
}
