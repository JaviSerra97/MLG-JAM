using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaToMoveRope : MonoBehaviour
{
    GameObject HitchInitial;

    void Awake()
    {
        HitchInitial = GameObject.FindGameObjectWithTag("HitchInitial");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!HitchInitial.GetComponent<HitchInitial>().reached)
                HitchInitial.GetComponent<HitchInitial>().Deactivate();
        }
    }
}
