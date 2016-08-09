using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
    // Update is called once per frame
    public GameObject objToFollow;
    public float verticalShift;
	void Update () {
        Vector3 objPosition = objToFollow.transform.position;
        transform.position = new Vector3(objPosition.x, objPosition.y+verticalShift, -10);
	}
}
