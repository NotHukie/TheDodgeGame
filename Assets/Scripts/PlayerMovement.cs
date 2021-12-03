using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    public float movementSpeed;
    public bool isDashing;
    public bool canDie;
    private float startingHealth = 3;
    private float currentHealth;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        isDashing = false;
        canDie = true;
        currentHealth = startingHealth;
    }
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if(movement.magnitude > 1)
        {
            movement = movement.normalized;
        }
        rb.velocity = movement * movementSpeed;
        
        if(Input.GetKeyDown("space") && !isDashing)
        {
            isDashing = true;
            canDie = false;
            movementSpeed = 60f;
            Invoke("Dash", 1f);
            Invoke("DashExit", .1f);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Obstáculo")
        {
            if(canDie == true)
            {
                TakeDamage(1);
            }
        }
        if(col.gameObject.tag == "Circle")
        {
            if(canDie == true)
            {
                TakeDamage(1);
            }
        }

        if(col.gameObject.tag == "Cura" && currentHealth < 3)
        {
            TakeDamage(-1);
        }
        
    }
    void Dash()
    {
        isDashing =  false;
        canDie = true;
    }
    void DashExit()
    {
        movementSpeed = 10f;
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if(currentHealth > 2.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
        else if(currentHealth > 1.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .6f);
        }
        else if(currentHealth > 0.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .3f);
        }
        else if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
