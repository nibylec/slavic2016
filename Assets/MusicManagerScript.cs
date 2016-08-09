using UnityEngine;
using System.Collections;

public class MusicManagerScript : MonoBehaviour {
    public AudioSource intro;
    public AudioSource sadChiptune0;
    public AudioSource sadChiptune1;
    public AudioSource sadChiptune2;
    public static MusicManagerScript instance;
	// Use this for initialization
    public void PlaySad0(){
        intro.Stop();
        sadChiptune0.Play();
    }
    public void PlaySad1()
    {
        intro.Stop();
        sadChiptune1.Play();
    }
    public void PlaySad2()
    {
        intro.Stop();
        sadChiptune2.Play();
    }
    void Awake()
    {
        instance = this;
    }
	// Update is called once per frame
	void Update () {
        if (!sadChiptune0.isPlaying && !intro.isPlaying && !sadChiptune1.isPlaying &&  !sadChiptune2.isPlaying)
        {
            intro.Play();
        }
	}
}
