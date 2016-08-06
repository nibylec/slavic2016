using UnityEngine;
using System.Collections;

public class InvisibleBlockScript : MonoBehaviour {
    Animator anim;
    SpriteRenderer sr;
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Enable()
    {
        sr.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            anim.SetTrigger("Destroy");
        }
    }
}
