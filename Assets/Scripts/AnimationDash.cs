using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDash : MonoBehaviour
{
    SpriteRenderer sprite;
    Animator anim; 

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Cooldown");
        }
    }
}
