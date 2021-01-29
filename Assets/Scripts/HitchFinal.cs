using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitchFinal : MonoBehaviour
{
    GameObject HitchInitial;

    void Awake()
    {
        HitchInitial = GameObject.FindGameObjectWithTag("HitchInitial");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Reached");
            if (!HitchInitial.GetComponent<HitchInitial>().reached)
                HitchInitial.GetComponent<HitchInitial>().Reached();
        }
    }
}
