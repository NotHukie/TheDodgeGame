using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Reflected")
        {
            Destroy(gameObject);
        }
    }
}
