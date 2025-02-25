using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMovement : MonoBehaviour
{
    public static CubeMovement instance;

    [Header("DASH")] //DASH
    private bool canDash = true;
    [SerializeField] private float dashingPower = 3f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown;
    public GameObject Blink;
    
    Vector2 movement;

    SpriteRenderer sprite;
    
    //Publics
    public Rigidbody2D rb;
    public BoxCollider2D PlayerCollider;
    public Animator playerAnimator;
    public TrailRenderer trail;
    public GameObject damage;

    //privates
    private bool canBeHitten = true;
    private float movementSpeed = 10f;
    private float startingHealth = 3f;
    private float currentHealth;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        currentHealth = startingHealth;
        Blink.SetActive(false);
    }
    void Update()
    {
        //Start Movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(movement.x, movement.y, 0f);
        transform.right = vec;


        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }
        rb.velocity = movement * movementSpeed;
        //End Movement

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void OnTriggerEnter2D(Collider2D collides)
    {
        if (collides.gameObject.tag == "Enemy" && canBeHitten)
        {
            canBeHitten = false;
            Invoke("CanTakeDamage", 1f);
            TakeDamage(1);
            EnableDamage();
            Invoke("DisableDamage", 0.15f);
        }

        if (collides.gameObject.tag == "Heal" && currentHealth < 3)
        {
            TakeDamage(-1);
        }
    }

    private IEnumerator Dash()
    {
        playerAnimator.SetTrigger("isDashing");
        canDash = false;
        canBeHitten = false;
        movementSpeed = movementSpeed * dashingPower;
        trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        movementSpeed = movementSpeed / dashingPower;
        trail.emitting = false;
        yield return new WaitForSeconds(0.5f);
        canBeHitten = true;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        Blink.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        Blink.SetActive(false);
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
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
        }
        else if (currentHealth > 0.5f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.25f);
        }
    }
        //Damage Effect
    void EnableDamage()
    {
        damage.SetActive(true);
    }
    void DisableDamage()
    {
        damage.SetActive(false);
    }
    void CanTakeDamage()
    {
        canBeHitten = true;
    }
}
