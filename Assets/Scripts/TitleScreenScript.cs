using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
    public int state;
    public GameObject introImage;
    public GameObject tutorialImage;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer
            || Application.platform == RuntimePlatform.BlackBerryPlayer || Application.platform == RuntimePlatform.WP8Player)
        { state = 0; }
        else
        { state = 1;
        Destroy(tutorialImage.gameObject);
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (state < 3 && Input.anyKeyDown)
        {
            if (state == 2)
            {
                introImage.GetComponent<SpriteRenderer>().enabled = false;
                state = 3;
            }
            else if (state == 1)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                state = 2;
                introImage.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (state == 0)
            {
                //tutorialImage.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(tutorialImage.gameObject);
                state = 1;
            }
           
        }
        
	}

    public void SkipAll()
    {
        state = 3;
        Destroy(tutorialImage.gameObject);
        GetComponent<SpriteRenderer>().enabled = false;
        introImage.GetComponent<SpriteRenderer>().enabled = false;
    }
}
