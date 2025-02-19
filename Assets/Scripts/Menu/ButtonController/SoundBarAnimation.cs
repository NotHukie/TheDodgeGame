using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBarAnimation : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void GoIn()
    {
        anim.SetBool("GoIn", true);
    }
    public void GoOut()
    {
        anim.SetBool("GoIn", false);
    }
}
