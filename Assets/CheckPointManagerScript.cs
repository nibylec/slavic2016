using UnityEngine;
using System.Collections;

public class CheckPointManagerScript : MonoBehaviour {
    public GameObject[] checkpoints;
    public GameObject hero;
    [HideInInspector]
   

    public void Start()
    {
        DeathPlaneScript.OnDeath += MoveHeroToLastCheckpoint;        
    }

    void Restart()
    {
        Application.LoadLevel(0);
    }
    void MoveHeroToLastCheckpoint()
    {
        for(int i = checkpoints.Length - 1; i>=0; i--)
        {
            if (checkpoints[i].GetComponent<CheckPointScript>().visited)
            {
                hero.transform.position = checkpoints[i].transform.position;
                return;
            }
        }
    }
}
