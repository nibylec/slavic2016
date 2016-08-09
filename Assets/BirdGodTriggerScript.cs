using UnityEngine;
using System.Collections;

public class BirdGodTriggerScript : MonoBehaviour {
    public GameObject birdGod;
    public GameObject blokada;

	public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("BirdGod Triggered!");
        birdGod.GetComponent<Animator>().SetTrigger("Death");
        GetComponent<BoxCollider2D>().enabled = false;
        MusicManagerScript.instance.PlaySad1();
        Destroy(blokada.gameObject);
    }
}
