using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageDropdown : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        //if (!LanguageSelector.instance.english) { dropdown.value = 1; }
    }

    public void ChangeLanguage()
    {
        LanguageSelector.instance.SelectLanguage(dropdown.value);
    }
}
