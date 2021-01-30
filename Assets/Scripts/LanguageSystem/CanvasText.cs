using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasText : MonoBehaviour
{
    public string englishOption;
    public string spanishOption;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void SetEnglish()
    {
        text.text = englishOption;
    }

    public void SetSpanish()
    {
        text.text = spanishOption;
    }
}
