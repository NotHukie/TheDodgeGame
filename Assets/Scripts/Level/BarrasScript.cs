using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrasScript : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Survive")
        {
            anim.SetBool("Survive", true);
        }

        if (sceneName == "LVL 2")
        {
            anim.SetBool("Lvl2", true);
        }
        if (sceneName == "LVL 3")
        {
            anim.SetBool("Lvl3", true);
        }
    }


}
