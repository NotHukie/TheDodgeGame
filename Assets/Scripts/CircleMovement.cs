using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    public Vector3 direction;
    public Vector3 rotation;
    protected Vector3 destination;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        destination = new Vector3(Random.Range(-3, 3), Random.Range(-1, 1), 0);
        direction = destination - transform.position;
    }

    void FixedUpdate()
    {
        rb.velocity = direction.normalized * speed;
        this.transform.Rotate(rotation * 1 * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Reflection")
        {
            direction = -direction;
            gameObject.tag = "Reflected";
            sprite.color = new Color(0.81f, 0.52f, 0.15f, 1f);
        }
        if(col.gameObject.tag == "Reflected")
        {
            Destroy(gameObject);
        }
    }
}
