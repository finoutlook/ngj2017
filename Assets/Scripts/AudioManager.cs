using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    static AudioManager instance;
    private AudioClip CurrentAudio;
    public AudioClip[] MusicArray;
    private AudioSource musicSource;



    private void Awake()
    {
        if(instance)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            musicSource = GetComponent<AudioSource>();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneChange;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneChange;
    }

    void OnSceneChange(Scene scene, LoadSceneMode loadSceneMode)
    {
        int sceneNumber = scene.buildIndex;

        var sceneMusic = MusicArray[sceneNumber];
        if(sceneMusic == CurrentAudio || ! sceneMusic)
        {
            return;
        }

        CurrentAudio = sceneMusic;
        musicSource.clip = CurrentAudio;
        musicSource.loop = true;
        musicSource.volume = 0.5f;
        musicSource.Play();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
