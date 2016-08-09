using UnityEngine;
using System.Collections;

public class DestroyableWallScript : MonoBehaviour {

    Animator anim;
    AudioSource sm;
    void Start()
    {
        sm = SoundManager.instance.GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            float distance = Mathf.Abs(collision.collider.transform.position.x - transform.position.x);
            if (distance<0.16) {
                anim.SetTrigger("Destroy");
                sm.Play();
            }
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
