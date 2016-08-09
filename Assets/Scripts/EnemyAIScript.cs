using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

    bool goingRight = false;
    public float enemySpeed = 1.0f;
    Rigidbody2D rb2d;
    Animator anim;
    bool dead = false;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "Player")
        {
            if (collision.relativeVelocity.y > 0)
            {
               
                collision.gameObject.GetComponent<HeroScript>().BounceOffEnemy();
                anim.SetTrigger("Death");
                dead = true;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    void OnEndOfDeathAnimation()
    {
        Destroy(gameObject);
    }

	void FixedUpdate()
    {
        if (dead)
        {
            return;
        }
        if (goingRight)
        {
            rb2d.MovePosition(transform.position + Vector3.right * enemySpeed);
        }
        else
        {
            rb2d.MovePosition(transform.position + Vector3.left * enemySpeed);
        }
    }

	void Update () {
        RaycastHit2D objectInFront;
        if (goingRight)
        {
            objectInFront = Physics2D.Linecast(transform.position, transform.position + Vector3.right * 0.1f, LayerMask.GetMask("Ground", "Player"));
        }
        else
        {
            objectInFront = Physics2D.Linecast(transform.position, transform.position + Vector3.left * 0.1f, LayerMask.GetMask("Ground", "Player"));
        }
        if (objectInFront)
        {
            if (objectInFront.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                goingRight = !goingRight;
            }
            else if (objectInFront.collider.gameObject.tag == "Player")
            {
                //Application.LoadLevel(0);
            }
        }
        
	}

}
