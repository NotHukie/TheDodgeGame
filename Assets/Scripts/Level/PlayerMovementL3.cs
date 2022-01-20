using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementL3 : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    public float movementSpeedL;
    public bool isDashingL;
    public bool canDieL;
    private float startingHealth = 1f;
    private float currentHealth;
    SpriteRenderer sprite;
    private bool canDashL;
    Animator anim;
    public bool canReflectL;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isDashingL = false;
        canDieL = true;
        canDashL = true;
        canReflectL = false;
        currentHealth = startingHealth;
    }
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(movement.x, movement.y, 0f);
        transform.right = vec;

        if(movement.magnitude > 1)
        {
            movement = movement.normalized;
        }
        rb.velocity = movement * movementSpeedL;
        
        if(Input.GetKeyDown("space") && canDashL)
        {
            isDashingL = true;
            canDieL = false;
            canDashL = false;
            movementSpeedL = 60f;
            Invoke("DashL", 1f);
            Invoke("DashExitL", .1f);
            Invoke("RecoverDashL", 4f);
            anim.SetTrigger("canDash");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canReflectL)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            //SetActive Indicador Reflect = false;
            canReflectL = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Obstáculo")
        {
            if(canDieL == true)
            {
                TakeDamage(1);
                canDieL = false;
                Invoke("DashL" ,1f);
            }
        }
        if(col.gameObject.tag == "Circle")
        {
            if(canDieL == true)
            {
                TakeDamage(1);
                canDieL = false;
                Invoke("DashL" ,1f);
            }
        }

        if(col.gameObject.tag == "Cura" && currentHealth < 3)
        {
            TakeDamage(-1);
        }
        if(col.gameObject.tag == "ReflectItem")
        {
            canReflectL = true;
            //SetActive Indicador Reflect 
        }
        
    }
    void DashL()
    {
        isDashingL =  false;
        canDieL = true;
    }
    void DashExitL()
    {
        movementSpeedL = 10f;
    }
    void RecoverDashL()
    {
        canDashL = true;
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if(currentHealth > 0.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
        /*else if(currentHealth > 1.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .6f);
        }
        else if(currentHealth > 0.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .3f);
        }
        else if(currentHealth <= 0)*/
        {
            Destroy(gameObject);
            SceneManager.LoadScene(17);

        }
    }
}
