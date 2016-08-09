using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public void RestartGame()
    {
        Application.LoadLevel(0);
    }
}
