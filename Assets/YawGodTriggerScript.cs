using UnityEngine;
using System.Collections;

public class YawGodTriggerScript : MonoBehaviour {
    public GameObject yawGod;
    public void OnTriggerEnter2D(Collider2D col)
    {
        yawGod.GetComponent<Animator>().SetTrigger("Death");
        GetComponent<BoxCollider2D>().enabled = false;
        MusicManagerScript.instance.PlaySad2();
    }
}
