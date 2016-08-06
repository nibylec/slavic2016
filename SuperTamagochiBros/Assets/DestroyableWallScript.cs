using UnityEngine;
using System.Collections;

public class DestroyableWallScript : MonoBehaviour {

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            anim.SetTrigger("Destroy");
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void DestroyOnAnimation()
    {
        Destroy(gameObject);
    }
}
