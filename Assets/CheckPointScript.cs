using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour {
    public bool visited;
    public void Start()
    {
        visited = false;
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player")
            return;
        visited = true;
    }
}
