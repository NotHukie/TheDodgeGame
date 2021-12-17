using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 15f;
    }

    void Update()
    {
        transform.localScale -= Vector3.one * speed * Time.deltaTime;
        if (transform.localScale.x <= 0.3f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Reflected")
        {
            Destroy(gameObject);
        }
    }
}
