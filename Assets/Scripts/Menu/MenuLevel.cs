using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene(9);
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene(10);
    }
    public void PlayLevel4()
    {
        SceneManager.LoadScene(11);
    }
    public void PlayLevel5()
    {
        SceneManager.LoadScene(12);
    }
    public void PlayLevel6()
    {
        SceneManager.LoadScene(13);
    }
    public void PlayLevel7()
    {
        SceneManager.LoadScene(14);
    }
    public void PlayLevel8()
    {
        SceneManager.LoadScene(15);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(1);
    }
}
