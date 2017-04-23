using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    AudioSource _audioSource;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("Wait");

        _audioSource = GameObject.FindObjectOfType<AudioSource>();
        _audioSource.time = 5.00f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_audioSource == null)
        {
            _audioSource = GameObject.FindObjectOfType<AudioSource>();
        }

        if (_audioSource.time > 7.62f)
        {
            _audioSource.Stop();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel("Start");
    }
}