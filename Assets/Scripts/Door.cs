using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public float OpenTime, Closetime;
    public float RotationToOpen, RotationToClose;

    private bool TriggerStay;

    private void Awake()
    {
        TriggerStay = false;
    }

    private void Update()
    {
        if(!TriggerStay )
            CloseDoor();
        else if(TriggerStay )
            OpenDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerStay = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerStay = false;
        }
    }
    
    private void OpenDoor()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.EulerAngles(new Vector3(0, RotationToOpen, 0)), OpenTime);
    }

    private void CloseDoor()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.EulerAngles(new Vector3(0, RotationToClose, 0)), Closetime);
    }
}
