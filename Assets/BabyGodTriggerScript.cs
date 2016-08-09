using UnityEngine;
using System.Collections;

public class BabyGodTriggerScript : MonoBehaviour {

    public GameObject babyGod;

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Baby God Triggered!");
        babyGod.GetComponent<Animator>().SetTrigger("Death");
        GetComponent<BoxCollider2D>().enabled = false;
        MusicManagerScript.instance.PlaySad0();
    }
}
