using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DoNotDestroy");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        

        DontDestroyOnLoad(this.gameObject);
    }
}
