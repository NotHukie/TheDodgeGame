using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    public GameObject Circle;
    public Vector3 reflection;
    public Transform PlayerPosition;

    void Update()
    {
        reflection = PlayerPosition.position;
        this.transform.position = reflection;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Obstáculo")
        {
            gameObject.SetActive(false);
            Debug.Log("mewiwd");
        }
    }
}
