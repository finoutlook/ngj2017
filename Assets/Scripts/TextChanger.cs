using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    public Text uiText;
    public float fadeDuration = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Text(string text)
    {
        if (!string.IsNullOrEmpty(uiText.text))
        {
            uiText.canvasRenderer.SetAlpha(0.1f);
        }

        uiText.text = text;
        uiText.CrossFadeAlpha(1f, fadeDuration, false);
    }
}
