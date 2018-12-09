using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour {

    public Sounds[] sounds;

    public static MusicManager instance;

    // Use this for initialization
    

    void Awake () {

        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);   //需連續撥放時使用

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}
	void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex.Equals(0))
            Play("main");
       /*( while (!SceneManager.GetActiveScene().buildIndex.Equals(0)){   //需連續撥放時使用

        }*/
    }
	// Update is called once per frame
	public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
