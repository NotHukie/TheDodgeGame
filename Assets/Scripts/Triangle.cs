using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private bool decreasing = true;

    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale= Vector3.one * 15f;
    }
    void Update()
    {
        if(transform.localScale.x <= 0.5f && decreasing)
        {
            decreasing = false;
        }


        if(decreasing)
        {
            transform.localScale -= Vector3.one * speed * Time.deltaTime;
        }
        else 
        {
            transform.localScale -= Vector3.one * -speed * Time.deltaTime;
        }
    }
        void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Reflected")
        {
            Destroy(gameObject);
        }
    }
}
