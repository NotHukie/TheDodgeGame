using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationDash : MonoBehaviour
{
    SpriteRenderer sprite;
    Animator anim;
    public PlayerMovement playerMovement;
    public PlayerMovementLvl1 playerMovementLvl;

    int level = 0;
    void Start()
    {
        anim = GetComponent<Animator>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "LVL 2")
        {
            level = 2;
        }
        if (sceneName == "LVL 3")
        {
            level = 3;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown("space") && level == 0 && playerMovement.isPaused == false)
        {
            anim.SetBool("CouldownLVL", true);
            Invoke("DashCouldownLVL", 3f);
        }
        if (Input.GetKeyDown("space") && level != 0 && playerMovementLvl.isPaused == false)
        {
            anim.SetBool("CouldownLVL", true);
            Invoke("DashCouldownLVL", 3f);
        }
    }

    void DashCouldown()
    {
        anim.SetBool("Couldown", false);
    }
    void DashCouldownLVL()
    {
        anim.SetBool("CouldownLVL", false);
    }
}
