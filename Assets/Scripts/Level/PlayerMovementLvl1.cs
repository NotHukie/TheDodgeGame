using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementLvl1 : MonoBehaviour
{
    public static PlayerMovementLvl1 instance;
    
    public Rigidbody2D rb;
    Vector2 movement;
    public float movementSpeedL;
    public bool isDashingL;
    public bool canDieL;
    private float startingHealth = 3f;
    private float currentHealth;
    SpriteRenderer sprite;
    private bool canDashL;
    Animator anim;
    public GameObject dano;

    public GameObject pauseMenu;
    public bool isPaused;

    public AudioSource musicLvl;

    //Cronómetro para spawnar obstáculos
    public float timer;
    public float secondsIncreasedPerFrame = 1f;

    bool gravity = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isDashingL = false;
        canDieL = true;
        canDashL = true;
        currentHealth = startingHealth;

        isPaused = false;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "LVL 3")
        {
            gravity = true;
        }

        timer = 0f;
    }
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(movement.x, movement.y, 0f);
        transform.right = vec;

        timer += secondsIncreasedPerFrame * Time.deltaTime; // Aumentar um a cada segundo no timer

        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }
        rb.velocity = movement * movementSpeedL;

        if (Input.GetKeyDown("space") && canDashL && !isPaused)
        {
            isDashingL = true;
            canDieL = false;
            canDashL = false;
            movementSpeedL = 60f;
            Invoke("DashL", 1f);
            Invoke("DashExitL", .1f);
            Invoke("RecoverDashL", 3f);
            anim.SetTrigger("canDash");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (gravity && timer > 15f)
        {
            rb.gravityScale = -10f;
        }
        if (gravity && timer > 45f)
        {
            rb.gravityScale = 0f;
        }
        if (gravity && timer > 60f)
        {
            rb.gravityScale = 10f;
        }
        if (gravity && timer > 90f)
        {
            rb.gravityScale = 0f;
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
        if (Input.GetKeyDown(KeyCode.R) && !gravity)
        {
            SceneManager.LoadScene(3);
            Destroy(GameObject.FindWithTag("Audio"));
        }

        if (Input.GetKeyDown(KeyCode.R) && gravity)
        {
            SceneManager.LoadScene(5);
            Destroy(GameObject.FindWithTag("Audio"));
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
                dano.SetActive(true);
                Invoke("DisableDamage", 0.15f);
                
            }
        }
        if(col.gameObject.tag == "Circle")
        {
            if(canDieL == true)
            {
                TakeDamage(1);
                canDieL = false;
                Invoke("DashL" ,1f);
                dano.SetActive(true);
                Invoke("DisableDamage", 0.15f);
            }
        }

        if(col.gameObject.tag == "Cura" && currentHealth < 3)
        {
            TakeDamage(-1);
        }
        

    }


    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        musicLvl.Pause();
    }
    void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        musicLvl.UnPause();
    }

    void DisableDamage()
    {
        dano.SetActive(false);
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
        if (currentHealth > 2.5)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
        else if (currentHealth > 1.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.6f);
        }
        else if (currentHealth > 0.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
        }
        else if (currentHealth <= 0 && !gravity)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(4);

            timer = 0f;
            musicLvl.volume = 0.05f;
        }
        else if (currentHealth <= 0 && gravity)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(6);

            timer = 0f;
            musicLvl.volume = 0.05f;
        }
    }
}
