using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public static LanguageSelector instance;

    public bool english = true;

    private void Awake()
    {
        if (!instance) { instance = this; }
        else { Destroy(gameObject); }
    }

    public void SelectEnglish()
    {
        Debug.Log("English");
    }

    public void SelectSpanish()
    {
        Debug.Log("Spanish");
    }
}
