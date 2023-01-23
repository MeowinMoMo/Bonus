using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MovementSpeed;
    public int Health;
    bool isLookingRight;
    [SerializeField] private float damage;
    // [SerializeField] GameObject bullet;
    
    // float fireRate;
    // float nextFire;

    Rigidbody2D rb;
    SpriteRenderer sr;


    void Start()
    {
        // fireRate = 1f;
        // nextFire = Time.time;
    }

    void Update()
    {
        // CheckIfTimetoFire();
    }
    
    // void CheckIfTimetoFire()
    // {
    //     if (Time.time > nextFire)
    //     {
    //         Instantiate (bullet, transform.position, Quaternion.identity);
    //         nextFire = Time.time + fireRate;
    //     }
    // }

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(isLookingRight)
        {
            rb.velocity = new Vector2(MovementSpeed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-MovementSpeed * Time.deltaTime, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isLookingRight = !isLookingRight;

            if (isLookingRight)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        // if(collision.gameObject.tag.Equals("Player"))
        // {
        //     collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        // }
        if(collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy (collision.gameObject);
            Destroy (gameObject);
        }
    } 

}
