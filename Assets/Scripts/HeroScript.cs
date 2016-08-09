using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    AudioSource jumpSound;
    public float moveForce = 365f;
    public float maxSpeed = 0.1f;
    public float jumpForce = 0.2f;
    public Transform groundCheck;
    public GameObject titleScreen;
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    float hInput;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(titleScreen.GetComponent<TitleScreenScript>().state < 3)
            return;

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.Log(grounded);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumpSound.Play();
            jump = true;
        }
    }
    
  

    void FixedUpdate()
    {
        if (titleScreen.GetComponent<TitleScreenScript>().state < 3)
            return;

        float h = Input.GetAxis("Horizontal");
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer
            || Application.platform == RuntimePlatform.BlackBerryPlayer || Application.platform == RuntimePlatform.WP8Player)
        {
            h = hInput;
        }


        if (h < 0.1f && h >- 0.1f)
        {
            anim.SetBool("Walking", false);
        }
        else {
            anim.SetBool("Walking", true);
        }
        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    public void BounceOffEnemy()
    {
        anim.SetTrigger("Jump");
        rb2d.AddForce(new Vector2(0f, 2.0f*jumpForce));
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    

    public void MovePlayer(float input)
    {
        hInput = input;
    }

    public void Jump()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer
            || Application.platform == RuntimePlatform.BlackBerryPlayer || Application.platform == RuntimePlatform.WP8Player)
        if (grounded)
        {
            jumpSound.Play();
            jump = true;
        }
    }

}
