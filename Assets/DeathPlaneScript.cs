using UnityEngine;
using System.Collections;

public class DeathPlaneScript : MonoBehaviour {
    public delegate void DeathAction();
    public static event DeathAction OnDeath;
    public GameObject titleScreen;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnDeath();
        }
    }
}
