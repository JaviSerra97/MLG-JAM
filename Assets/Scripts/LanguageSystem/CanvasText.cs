using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasText : MonoBehaviour
{
    public string englishText;
    public string spanishText;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void SetEnglish() { text.text = englishText; }
    public void SetSpanish() { text.text = spanishText; }
}
