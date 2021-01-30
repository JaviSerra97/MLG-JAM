using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightBlink : MonoBehaviour
{
    public float minRange;
    public float maxRange;

    private float timeToBlink;
    private float timer;

    private bool isOn = true;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        timeToBlink = Random.Range(minRange, maxRange);
    }

    private void Update()
    {
        if (isOn)
        {
            timer += Time.deltaTime;
            if(timer >= timeToBlink)
            {
                HideImage();
            }
        }
    }

    void HideImage()
    {
        isOn = false;
        timer = 0;
        timeToBlink = Random.Range(minRange, maxRange);
        image.enabled = false;
        Invoke("ShowImage", 0.05f);
    }

    void ShowImage()
    {
        isOn = true;
        image.enabled = true;
    }


}
