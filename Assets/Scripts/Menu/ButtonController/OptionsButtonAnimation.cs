using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtonAnimation : MonoBehaviour
{
    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void GoOut()
    {
        anim.SetBool("GoOut", true);
    }
    public void GoIn()
    {
        anim.SetBool("GoOut", false);
    }
}
