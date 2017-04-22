using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    public Text uiText;
    public float fadeDuration = 0.3f;

    public string currentText;
    private bool fadeCurrent;
    public void Text(string text)
    {
        if (!string.IsNullOrEmpty(uiText.text))
        {
            fadeCurrent = true;
           
        }

        currentText = text;
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        if(fadeCurrent)
        {
            fadeCurrent = false;
            uiText.CrossFadeAlpha(0f, fadeDuration, false);
            yield return new WaitForSeconds(fadeDuration);
        }
        for (int i = 0; i < (currentText.Length + 1); i++)
        {
            uiText.CrossFadeAlpha(1f, 0, true);
            uiText.text = currentText.Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
    }
}
