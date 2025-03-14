using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static bool canDash;
    Animator anim;
    public bool canReflect;
    public GameObject Damage;
    public GameObject IndicadorReflect;

    public GameObject pauseMenu;
    public bool isPaused;

    public AudioSource music;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isDashing = false;
        canDie = true;
        canDash = true;
        canReflect = false;
        currentHealth = startingHealth;
        isPaused = false;
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
        rb.velocity = movement * movementSpeed;

        if(SpawnerPentagon.timer > 171f)
        {
            rb.gravityScale = 10f;
        }
        if(Input.GetKeyDown("space") && canDash)
        {
            isDashing = true;
            canDie = false;
            canDash = false;
            movementSpeed = 60f;
            Invoke("Dash", 1f);
            Invoke("DashExit", .1f);
            Invoke("RecoverDash", 3f);
            anim.SetTrigger("canDash");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canReflect)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            canReflect = false;
            IndicadorReflect.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Obstáculo")
        {
            if(canDie == true)
            {
                TakeDamage(1);
                canDie = false;
                Invoke("Dash" ,1f);
                Damage.SetActive(true);
                Invoke("DisableDamage", 0.2f);
            }
        }
        if(col.gameObject.tag == "Circle")
        {
            if(canDie == true)
            {
                TakeDamage(1);
                canDie = false;
                Invoke("Dash" ,1f);
                Damage.SetActive(true);
                Invoke("DisableDamage", 0.2f);
            }
        }

        if(col.gameObject.tag == "Cura" && currentHealth < 3)
        {
            TakeDamage(-1);
        }
        if(col.gameObject.tag == "ReflectItem")
        {
            canReflect = true;
            IndicadorReflect.SetActive(true);
        }
        
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        music.Pause();
    }
    void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        music.UnPause();
    }
    void DisableDamage()
    {
        Damage.SetActive(false);
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
    void RecoverDash()
    {
        canDash = true;
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if(currentHealth > 2.5)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
        else if(currentHealth > 1.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.6f);
        }
        else if(currentHealth > 0.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
        }
        else if(currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
            music.volume = 0.01f;
        }
    }
}
