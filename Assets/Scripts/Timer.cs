using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int TimeInSeconds = 120;

    public Text uiText;

    private int timeRemainingInMilliseconds;

	// Use this for initialization
	void Start () {
        timeRemainingInMilliseconds = TimeInSeconds * 1000;
	}
	
	// Update is called once per frame
	void Update () {
        timeRemainingInMilliseconds -= (int)Mathf.Round(Time.deltaTime * 1000);
        
        TimeSpan t = TimeSpan.FromMilliseconds(timeRemainingInMilliseconds);

        //here backslash is must to tell that colon is
        //not the part of format, it just a character that we want in output
        uiText.text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
    }
}
