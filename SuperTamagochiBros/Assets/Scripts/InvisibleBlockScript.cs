using UnityEngine;
using System.Collections;

public class InvisibleBlockScript : MonoBehaviour {
    Animator anim;
    SpriteRenderer sr;
    BoxCollider2D collider;
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void Enable()
    {
        sr.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            collider.isTrigger = false;
            anim.SetTrigger("Destroy");
        }
    }
}
