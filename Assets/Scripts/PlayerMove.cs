using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float MovementSpeed;
    public float WalkSpeed;
    public float RunSpeed;
    public float JumpForce;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource BoostSound;
    [SerializeField] private AudioSource Grounded;
    [SerializeField] private AudioSource Deathsound;
    // public Animator TransitionAnimation;
    // WaitForSeconds delay = new WaitForSeconds(1);
    public static Vector2 LastCheckPoint = new Vector2(-3,0);
    public int JumpCount;
    int maxJumpCount;
    bool grounded;
    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sr;
    CharacterController cc;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPoint;
        maxJumpCount = JumpCount;
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ani.SetBool("Run",true);
            Run();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ani.SetBool("Run",false);
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

        if (rb.velocity != Vector2.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if (rb.velocity != Vector2.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
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
    
    void Walk()
    {
        MovementSpeed = WalkSpeed;
    }
    void Run()
    {
        MovementSpeed = RunSpeed;
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
        if(collision.gameObject.CompareTag("UMI"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

         if(collision.gameObject.CompareTag("last"))
        {
           GameOverCanva.SetActive(true);
        }
    }
    //  public Text timerText;
    // private bool Finnished = false;
    // public void Finnish()
    // {
    //     Finnished = true;
    //     timerText.color = Color.yellow;
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