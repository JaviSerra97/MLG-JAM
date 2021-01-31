using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceLanguage : MonoBehaviour
{
    public string spanish;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (!LanguageSelector.instance.english) { text.text = spanish; }
    }
}
