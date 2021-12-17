using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayLevel2()
    {
        Debug.Log("Load Level 2");
    }
    public void PlayLevel3()
    {
        Debug.Log("Load Level 3");
    }
    public void PlayLevel4()
    {
        Debug.Log("Load Level 4");
    }
    public void PlayLevel5()
    {
        Debug.Log("Load Level 5");
    }
    public void PlayLevel6()
    {
        Debug.Log("Load Level 6");
    }
    public void PlayLevel7()
    {
        Debug.Log("Load Level 7");
    }
    public void PlayLevel8()
    {
        Debug.Log("Load Level 8");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(1);
    }
}
