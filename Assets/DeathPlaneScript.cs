using UnityEngine;
using System.Collections;

public class DeathPlaneScript : MonoBehaviour {

    public GameObject titleScreen;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Application.LoadLevel(0);
        }
    }
}
