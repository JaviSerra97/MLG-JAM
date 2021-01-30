using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNote : MonoBehaviour
{
    public Note note;

    private bool english;

    private void Start()
    {
        english = LanguageSelector.instance.english;

        if (english) { Debug.Log(note.englishText); }
        else { Debug.Log(note.spanishText); }
    }
}
