using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class LanguageSelector : MonoBehaviour
{
    public static LanguageSelector instance;

    public bool english = true;

    private CanvasText[] listOfCanvasTexts;

    private void Awake()
    {
        if (!instance) { instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);

        listOfCanvasTexts = GameObject.FindObjectsOfType<CanvasText>();
    }

    
    public void SelectLanguage(int val)
    {
       if(val == 0) { SelectEnglish(); }
       if(val == 1) { SelectSpanish(); }
    }

    void SelectEnglish()
    {
        LanguageSelector.instance.english = true;

        foreach (CanvasText CT in listOfCanvasTexts)
        {
            CT.SetEnglish();
        }
    }

    void SelectSpanish()
    {
        LanguageSelector.instance.english = false;

        foreach (CanvasText CT in listOfCanvasTexts)
        {
            CT.SetSpanish();
        }
    }
}
