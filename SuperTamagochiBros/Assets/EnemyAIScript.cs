using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

    bool goingRight = false;
    public float enemySpeed = 1.0f;
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	void Start () {
	        
	}

	void FixedUpdate()
    {
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
	    if(Physics2D.Linecast(transform.position, transform.position + Vector3.left*0.2f, 1 << LayerMask.NameToLayer("Ground")))
        {
            goingRight = true;
        }
        else if (Physics2D.Linecast(transform.position, transform.position + Vector3.right * 0.2f, 1 << LayerMask.NameToLayer("Ground")))
        {
            goingRight = false;
        }
	}

}
