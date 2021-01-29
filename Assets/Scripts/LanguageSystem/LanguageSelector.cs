using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageSelector : MonoBehaviour
{
    public static LanguageSelector instance;

    public bool english = true;

    public TMP_Dropdown languageDropdown;

    public CanvasText[] listOfCanvasTexts;

    private void Awake()
    {
        if (!instance) { instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);

        listOfCanvasTexts = GameObject.FindObjectsOfType<CanvasText>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { SelectEnglish(); }
        if (Input.GetKeyDown(KeyCode.S)) { SelectSpanish(); }
    }

    public void SelectLanguage()
    {
        if(languageDropdown.value == 0) { SelectEnglish(); }
        else if (languageDropdown.value == 1) { SelectSpanish(); }
    }

    void SelectEnglish()
    {
        english = true;

        foreach(CanvasText CT in listOfCanvasTexts)
        {
            CT.SetEnglish();
        }
    }

    void SelectSpanish()
    {
        english = false;

        foreach(CanvasText CT in listOfCanvasTexts)
        {
            CT.SetSpanish();
        }
    }
}
