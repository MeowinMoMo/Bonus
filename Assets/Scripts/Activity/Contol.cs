using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contol: MonoBehaviour
{
    public float MovementSpeed;

    public float BoostSpeed;
    public float JumpForce;
    public float BoostTimer;
    public float boostime;
    public bool boosting;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource BoostSound;
    [SerializeField] private AudioSource Grounded;
    [SerializeField] private AudioSource Deathsound;
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject[] ammo;
    private int ammoAmount;
    // public Animator TransitionAnimation;
    // WaitForSeconds delay = new WaitForSeconds(1);
    public static Vector2 LastCheckPoint = new Vector2(-3,0);
    public int JumpCount;
    int maxJumpCount;
    float normalMovement;
    bool grounded;
    public GameObject bulletright , bulletleft;
    Vector2 bulletPos;
    public float fireRate;
    float nextFire;

    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sr;
    CharacterController cc;

    void Start()
    {
        for (int i = 0; i <= 3; i++)
        {
            ammo[i].gameObject.SetActive(false);
        }

        ammoAmount = 0;
        
    }
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPoint;
        maxJumpCount = JumpCount;
        normalMovement = MovementSpeed;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CharacterController>();
        
    }
    private void FixedUpdate()
    {
        // TransformMovement();
        // UpdateAnimationUpdate();
        RigidbodyMovement();
        ani.SetFloat("MovementX", Mathf.Abs(rb.velocity.x));
        ani.SetFloat("MovementY", Mathf.Abs(rb.velocity.y));
        ani.SetBool("grounded", grounded);
    }
    private void Update()
    {
      
         if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("Jump",true);
            jumpSound.Play();
            Jump();
        }
         if (Input.GetKeyUp(KeyCode.Space))
        {
            ani.SetBool("Jump",false);
            Jump();
        }
        // if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        // {
        //     nextFire = Time.time + fireRate;
        //     fire ();
        // }
        if (Input.GetButtonDown("Fire1") && ammoAmount > 0)
        {
            var spawnedBullet = Instantiate(Rock, barrel.position, barrel.rotation);
            spawnedBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500f);
            ammoAmount -= 1;
            ani.SetTrigger("Shoot");
            ammo[ammoAmount].gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.R))
        {
            ammoAmount = 4;
            for (int i = 0; i <= 3; i++)
            {
                ammo[i].gameObject.SetActive(true);
            }
        }
        if (boosting)
        {
            BoostTimer += Time.deltaTime;
            if(BoostTimer >= boostime)
            {
                MovementSpeed = normalMovement;
                BoostTimer = 0;
                boosting = false;
            }
        }
        RigidbodyMovement();
    }

    public void TransformMovement()
    {
        float movementDir = Input.GetAxisRaw("Horizontal");
        transform.position = new Vector2(transform.position.x + (MovementSpeed * movementDir * Time.deltaTime), transform.position.y);

    }
    public void RigidbodyMovement()
    {
        float movementDir = Input.GetAxisRaw("Horizontal");
        
        // Direction = new Vector2(0, movementDir);
        rb.velocity = new Vector2(movementDir * MovementSpeed * Time.deltaTime, rb.velocity.y);
        // cc.Move(rb.velocity * Time.deltaTime);


        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
    }
    void Jump()
    {
        if (JumpCount > 0)
        {
            JumpCount--; // JumpCount = -1 / JumpCount -= 1;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            // ani.Play("JumJum");
        }
    }
    
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            JumpCount = maxJumpCount;
            Grounded.Play();
            grounded = true;
            
        }

    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        // setting the grounded boolean to false when leaving the collision area of  the "Ground"
        if (collision.gameObject.tag.Equals("Ground"))
        {
            grounded = false;
        }
        
       
    }

    public GameObject GameOverCanva;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Boost"))
        {
            Animator an = collision.gameObject.GetComponent<Animator>();
            an.SetBool("Collect",true);
            BoostSound.Play();
            JumpCount++;
            boosting = true;
            MovementSpeed = BoostSpeed+MovementSpeed;
            Destroy(collision.gameObject, 0.75f);

        }
        if(collision.gameObject.tag.Equals("Fell"))
        {
            Deathsound.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(collision.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    // void fire()
    // {
    //     bulletPos = transform.position;
    //     if (rb.velocity.x < 0)
    //     {
    //         bulletPos += new Vector2 (+1f, 1f);
    //         Instantiate (bulletright, bulletPos, Quaternion.identity);
    //     }
    //     else if (rb.velocity.x > 0)
    //     {
    //         bulletPos += new Vector2 (+1f, 0.8f);
    //         Instantiate (bulletleft, bulletPos, Quaternion.identity);
    //     }
    // }
    
     


    // private void UpdateAnimationUpdate()
    // {
    //     MovementState state;

    //     if (dX > 0f)
    //     {
    //         state = MovementState.running;
    //         sprite.flipX = false;
    //     }
    //     else if (dX < 0f)
    //     {
    //         state = MovementState.running;
    //         sprite.flipX = true;
    //     }
    //     else
    //     {
    //         state = MovementState.idle;
    //     }

    //     if (rb.velocity.y > .1f)
    //     {
    //         state = MovementState.jumping;
    //     }
    //     else if (rb.velocity.y < -.1f)
    //     {
    //         state = MovementState.falling;
    //     }

    //     an.SetInteger("state", (int)state);
    // }

    // private bool IsGrounded()
    // {
    //     return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    // }
}