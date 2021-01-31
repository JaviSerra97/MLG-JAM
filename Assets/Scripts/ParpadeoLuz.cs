using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParpadeoLuz : MonoBehaviour
{
    Light MiLuz;
    float ContadorTiempo = 0f;
    public float intenslu;
    public float rangelu;
    void Start()
    {
        MiLuz = GetComponent<Light>();
    }

    void Update()
    {
        ContadorTiempo += Time.deltaTime;
        if (ContadorTiempo < 1.3)
        {
            MiLuz.intensity = intenslu;
            MiLuz.range = rangelu;
        }
        else
        {
            MiLuz.intensity = 0;
        }
        if (ContadorTiempo > 2)
        {
            ContadorTiempo = 0;
        }

    }
}