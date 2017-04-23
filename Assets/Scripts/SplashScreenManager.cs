using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
	// Use this for initialization
	void Start () {
        StartCoroutine("Wait");

        AudioSource audioSource = GameObject.FindObjectOfType<AudioSource>();
        audioSource.time = 5.00f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        AudioSource audioSource = GameObject.FindObjectOfType<AudioSource>();

        if (audioSource.time > 7.55f)
        {
            audioSource.Stop();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("Start");
    }
}