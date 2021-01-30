using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValue : MonoBehaviour
{
    public TMP_Text text;
    
    private Slider slider;

    public void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeValue()
    {
        text.text = slider.value.ToString();
    }

}
