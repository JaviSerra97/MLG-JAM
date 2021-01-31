using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    GameObject HitchInitial;
    

    void Awake()
    {
        HitchInitial = GameObject.FindGameObjectWithTag("HitchInitial");
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            if (!HitchInitial.GetComponent<HitchInitial>().reached)
                HitchInitial.GetComponent<HitchInitial>().Activate();
            

        }
        
    }
}
